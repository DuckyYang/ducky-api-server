using System;
using System.Collections.Generic;
using ducky_api_server.Core;
using ducky_api_server.Model.Users;
using ducky_api_server.Repo;

namespace ducky_api_server.Users
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
            return userRepo.GetUsers(query);
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
                    // 
                    userRepo.UpdateErrorTimes(user);
                    if (user.locked == 1)
                    {
                        return ("密码错误次数过多,账户已被锁定,请联系管理员解锁!", null);
                    }
                    return ("用户名或密码错误!", null);
                }
                user.accesstoken = GUID.New;
                user.expired = DateTime.Now.AddDays(1);
                userRepo.UpdateUserToken(user);

                user.password = "";
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
            return user;
        }
        public UsersModel AddUser(UsersModel model)
        {
            var user = userRepo.AddUser(model);
            return user;
        }
        public UsersModel UpdateUser(string id, UsersModel model)
        {
            if (model == null)
            {
                return null;
            }
            model.id = id;
            var user = userRepo.UpdateUser(model);
            return user;
        }
    }
}