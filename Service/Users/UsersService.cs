using System;
using System.Collections.Generic;
using System.Linq;
using ducky_api_server.Core;
using ducky_api_server.Model.Users;
using ducky_api_server.Repo;

namespace ducky_api_server.Service.Users
{
    public class UsersService : IUsersService
    {
        private UsersRepo userRepo;
        public UsersService()
        {
            userRepo = new UsersRepo();
        }
        public List<UsersModel> GetUsers(QueryUserModel query)
        {
            return userRepo.GetUsers(query).Select(r => { r.password = "***"; return r; }).ToList();
        }
        public (string msg, UsersModel user) SignIn(string account, string password)
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
                        user.locked = 1;
                        user.errortimes = 0;
                        userRepo.LockUser(user);
                        return ("密码错误次数过多,账户已被锁定,请联系管理员解锁!", null);
                    }
                    else
                    {
                        userRepo.UpdateErrorTimes(user);
                    }
                    return ("用户名或密码错误!", null);
                }
                user.accesstoken = GUID.New;
                user.expired = DateTime.Now.AddDays(1);
                userRepo.UpdateUserToken(user);

                user.password = "***";
                return ("", user);
            }

            return ("用户名或密码错误!", null);

        }
        public UsersModel GetUser(string accesstoken)
        {
            if (accesstoken.IsEmpty())
            {
                return null;
            }
            var user = userRepo.GetUser(accesstoken);
            user.password = "***";
            return user;
        }
        public (UsersModel user, string msg) AddUser(UsersModel model)
        {
            if (model.IsNull() || model.name.IsEmpty() || model.email.IsEmpty() || model.password.IsEmpty() || model.role.IsEmpty())
            {
                return (null, "缺少关键参数");
            }
            var user = userRepo.AddUser(model);
            user.password = "***";
            return (user, "");
        }
        public UsersModel UpdateUser(string id, UsersModel model)
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
    }
}