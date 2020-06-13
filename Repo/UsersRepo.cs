using System.Collections.Generic;
using ducky_api_server.Core;
using ducky_api_server.Model.Users;
using System.Linq.Expressions;
using System;
using System.Linq;

namespace ducky_api_server.Repo
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
        public List<UsersModel> GetUsers(QueryUserModel query)
        {
            int total = 0;

            var exp = Db.SqlExpression;

            exp.AndIF(!string.IsNullOrEmpty(query.Filter), r => r.name.Contains(query.Filter));
            exp.AndIF(!string.IsNullOrEmpty(query.Role), r => r.role.Contains(query.Role));
            var list = Db.GetList(exp, query.PageIndex, query.PageSize, ref total);
            query.Total = total;
            return list;
        }
        public UsersModel GetUserByAccount(string account)
        {
            var user = Db.GetSingle(r => r.email == account.Trim());
            return user;
        }
        public bool UpdateErrorTimes(UsersModel user)
        {

            return Db.Update(user, r => r.id == user.id, r => new { r.errortimes });
        }
        public bool LockUser(UsersModel user)
        {
            // 锁定账号
            user.errortimes = 0;
            user.locked = 1;
            return Db.Update(user, r => r.id == user.id, r => new { r.locked, r.errortimes });
        }
        public bool UpdateUserToken(UsersModel user)
        {
            return Db.Update(user, r => r.id == user.id, r => new { r.accesstoken, r.expired });
        }
        public UsersModel GetUser(string accesstoken)
        {
            var user = Db.GetSingle(r => r.accesstoken == accesstoken.Trim());
            return user;
        }
        public UsersModel GetUserById(string id)
        {
            var user = Db.GetSingle(r => r.id == id.Trim());
            return user;
        }
        public UsersModel AddUser(UsersModel model)
        {
            model.id = GUID.New;
            model.password = Md5.Encrypt(model.password, 32);
            model.inserttime = DateTime.Now;
            if (Db.Insert(model))
            {
                return model;
            }
            return null;
        }

        public UsersModel UpdateUser(UsersModel model)
        {
            var user = Db.GetSingle(r => r.id == model.id);
            if (user.IsNull())
            {
                return null;
            }
            user.name = model.name.IsEmpty() ? user.name : model.name;
            user.email = model.email.IsEmpty() ? user.email : model.email;
            user.mobile = model.mobile.IsEmpty() ? user.mobile : model.mobile;
            user.password = model.password.IsEmpty() || model.password == "***" ? user.password : Md5.Encrypt(model.password, 32);
            user.role = model.role.IsEmpty() ? user.role : model.role;

            if (Db.Update(user, r => r.id == user.id, r => new { r.name, r.email, r.mobile,r.password,r.role }))
            {
                return user;
            }
            return null;
        }

        public bool UpdateRole(string id, string role)
        {
            return Db.Update(new UsersModel { role = role }, r => r.id == id, r => new { r.role });
        }

        public bool UnLockUser(string id)
        {
            return Db.Update(new UsersModel { locked = 0 }, r => r.id == id, r => new { r.locked });
        }
        public bool LockUser(string id)
        {
            return Db.Update(new UsersModel { locked = 1 }, r => r.id == id, r => new { r.locked });
        }
        public bool RemoveUser(string id)
        {
            return Db.Delete(r => r.id == id);
        }

        public bool DisableUser(string id)
        {
           return Db.Update(new UsersModel { enabled = 0 }, r => r.id == id, r => new { r.enabled });
        }

        public bool EnableUser(string id)
        {
            return Db.Update(new UsersModel { enabled = 1 }, r => r.id == id, r => new { r.enabled });
        }
    }
}