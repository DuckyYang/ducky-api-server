using System;
using System.Collections.Generic;
using System.Linq;
using ducky_api_server.Core;
using ducky_api_server.DTO.Users;
using ducky_api_server.DTO.UserServers;
using ducky_api_server.Repo;

namespace ducky_api_server.Service.Users
{
    public class UsersService : IUsersService
    {
        private UsersRepo userRepo;
        private UserServersRepo userServersRepo;
        public UsersService()
        {
            userRepo = new UsersRepo();
            userServersRepo = new UserServersRepo();
        }
        public List<UsersDTO> GetUsers(QueryUserDTO query)
        {
            return userRepo.GetUsers(query).Select(r => { r.password = "***"; return r; }).ToList();
        }
        public (string msg, UsersDTO user) SignIn(string account, string password)
        {
            if (account.IsEmpty() || password.IsEmpty())
            {
                return ("用户名密码不能为空", null);
            }
            // 明文密码md5
            password = Md5.Encrypt(password.Trim(), 32);
            var user = userRepo.GetUserByAccount(account);
            if (!user.IsNull())
            {
                // 比较密码
                if (password != user.password)
                {
                    user.errortimes++;
                    // 
                    if (user.errortimes > 8)
                    {
                        userRepo.LockUser(user.id);
                        return ("密码错误次数过多,账户已被锁定,请联系管理员解锁!", null);
                    }
                    else
                    {
                        userRepo.UpdateErrorTimes(user.id,user.errortimes);
                    }
                    return ("用户名或密码错误!", null);
                }
                user.accesstoken = GUID.New;
                userRepo.UpdateUserToken(user.id,user.accesstoken);

                user.password = "***";
                return ("", user);
            }

            return ("用户名或密码错误!", null);

        }
        public UsersDTO GetUser(string accesstoken)
        {
            if (accesstoken.IsEmpty())
            {
                return null;
            }
            var user = userRepo.GetUser(accesstoken);
            user.password = "***";
            return user;
        }
        public (UsersDTO user, string msg) AddUser(UsersDTO model)
        {
            if (model.IsNull() || model.name.IsEmpty() || model.email.IsEmpty() || model.password.IsEmpty() || model.role.IsEmpty())
            {
                return (null, "缺少关键参数");
            }
            var user = userRepo.AddUser(model);
            user.password = "***";
            return (user, "");
        }
        public UsersDTO UpdateUser(string id, UsersDTO model)
        {
            if (model == null || id.IsEmpty())
            {
                return null;
            }
            model.id = id;
            var user = userRepo.UpdateUser(model);
            user.password = "***";
            return user;
        }
        public bool UnLockUser(string id)
        {
            var user = userRepo.GetUserById(id);
            if (!user.IsNull())
            {
                bool success;
                if (user.locked == 1)
                {
                    success = userRepo.UnLockUser(id);
                }
                else
                {
                    success = userRepo.LockUser(id);
                }
                return success;
            }
            return false;
        }
        public bool EnableUser(string id)
        {
            var user = userRepo.GetUserById(id);
            if (!user.IsNull())
            {
                bool success;
                if (user.enabled == 1)
                {
                    success = userRepo.DisableUser(id);
                }
                else
                {
                    success = userRepo.EnableUser(id);
                }
                return success;
            }
            return false;
        }
        public bool UpdateRole(string id, string role)
        {
            bool success = userRepo.UpdateRole(id, role);
            return success;
        }
        public bool RemoveUser(string id)
        {
            bool success = userRepo.RemoveUser(id);
            return success;
        }

        public bool AddUserServers(string id,List<UserServersDTO> list)
        {
            if (list.IsNull() || list.Count <= 0)
            {
                return false;
            }
            var user = userRepo.GetUserById(id);
            if (user.IsNull())
            {
                return false;
            }
            list.ForEach(x =>
            {
                x.userid = user.id;
            });
            return userServersRepo.AddUserServers(list);
        }
    }
}