using System.Collections.Generic;
using ducky_api_server.Core;
using ducky_api_server.Model.Users;
using System;
using ducky_api_server.DTO.Users;
using ducky_api_server.Extensions;

namespace ducky_api_server.Repo.Users
{
    public class UsersRepo
    {
        public DbContext<UsersModel> Db;
        public UsersRepo()
        {
            Db = new DbContext<UsersModel>();
        }
        public UsersModel GetUser()
        {
            return Db.GetSingle();
        }
        public List<UsersDTO> GetUsers(QueryUserDTO query)
        {
            int total = 0;

            var exp = Db.GetQueryExpression();

            exp.WhereIF(!string.IsNullOrEmpty(query.Filter), r => r.Name.Contains(query.Filter));
            exp.WhereIF(!string.IsNullOrEmpty(query.Role), r => r.Role.Contains(query.Role));
            exp.OrderByDescending(x=>x.InsertTime);
            var list = Db.GetList<UsersDTO>(exp, query.PageIndex, query.PageSize, ref total);
            query.Total = total;
            return list;
        }
        public (string msg,UsersDTO user) UserSignIn(string account,string password)
        {
            var user = Db.GetSingle(x=>x.Email ==  account);
            if (!user.IsNull())
            {
                if (user.Locked)
                {
                    return (SystemMessage.AccountHasBeenLocked,null);
                }
                // 比较密码
                if (user.Password.ToLower() == password.ToLower())
                {
                    return ("",user.Map<UsersDTO>());                   
                }
                else
                {
                    user.ErrorTimes++;
                    if (user.ErrorTimes > 8)
                    {
                        LockUser(user.ID);
                        return (SystemMessage.AccountOrPasswordErrorTooMuchAndBeLocked,null);
                    }
                    else
                    {
                        UpdateErrorTimes(user.ID,user.ErrorTimes);
                    }
                }
            }
            return (SystemMessage.AccountOrPasswordError,null);;
        }
        public UsersDTO GetUserByAccount(string account)
        {
            var user = Db.GetSingle<UsersDTO>(r => r.Email == account.Trim());
            return user;
        }
        public bool UpdateErrorTimes(string id, int errortimes)
        {
            return Db.Update(new UsersModel { ErrorTimes = errortimes }, r => r.ID == id, r => new { r.ErrorTimes });
        }
        public bool LockUser(string id)
        {
            // 锁定账号
            return Db.Update(new UsersModel { ErrorTimes = 0, Locked = true }, r => r.ID == id, r => new { r.Locked, r.ErrorTimes });
        }
        public bool UpdateUserToken(string id, string accesstoken)
        {
            return Db.Update(new UsersModel { Accesstoken = accesstoken, Expired = DateTime.Now.AddDays(1) }, r => r.ID == id, r => new { r.Accesstoken, r.Expired });
        }
        public UsersDTO GetUser(string accesstoken)
        {
            var user = Db.GetSingle<UsersDTO>(r => r.Accesstoken == accesstoken.Trim());
            return user;
        }
        public UsersDTO GetUserById(string id)
        {
            var user = Db.GetSingle<UsersDTO>(r => r.ID == id.Trim());
            return user;
        }
        public UsersDTO AddUser(UsersDTO dto)
        {
            var model = dto.Map<UsersModel>();
            model.ID = GUID.New;
            if (dto.Password.IsEmpty())
            {
                // 如果没有手动设置密码,则生成默认密码
                dto.Password = "junior@123";
            }
            model.Password = Md5.Encrypt(dto.Password, 32);
            model.InsertTime = DateTime.Now;
            if (Db.Insert(model))
            {
                return model.Map<UsersDTO>();
            }
            return null;
        }

        public UsersDTO UpdateUser(UsersDTO model)
        {
            var user = Db.GetSingle(r => r.ID == model.ID);
            if (user.IsNull())
            {
                return null;
            }
            user.Name = model.Name.IsEmpty() ? user.Name : model.Name;
            user.Email = model.Email.IsEmpty() ? user.Email : model.Email;
            user.Mobile = model.Mobile.IsEmpty() ? user.Mobile : model.Mobile;
            user.Password = model.Password.IsEmpty() || model.Password == "***" ? user.Password : Md5.Encrypt(model.Password, 32);
            user.Role = model.Role.IsEmpty() ? user.Role : model.Role;

            if (Db.Update(user, r => r.ID == user.ID, r => new { r.Name, r.Email, r.Mobile, r.Password, r.Role }))
            {
                return user.Map<UsersDTO>();
            }
            return null;
        }

        public bool UpdateRole(string id, string role)
        {
            return Db.Update(new UsersModel { Role = role }, r => r.ID == id, r => new { r.Role });
        }

        public bool UnLockUser(string id)
        {
            return Db.Update(new UsersModel { Locked = false }, r => r.ID == id, r => new { r.Locked });
        }
        public bool RemoveUser(string id)
        {
            return Db.Delete(r => r.ID == id);
        }
        public bool DisableUser(string id)
        {
            return Db.Update(new UsersModel { Enabled = false }, r => r.ID == id, r => new { r.Enabled });
        }
        public bool EnableUser(string id)
        {
            return Db.Update(new UsersModel { Enabled = true }, r => r.ID == id, r => new { r.Enabled });
        }
    }
}