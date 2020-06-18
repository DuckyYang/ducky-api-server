using System;
using System.Collections.Generic;
using System.Linq;
using ducky_api_server.DTO.Users;
using ducky_api_server.DTO.UserServers;
using ducky_api_server.Extensions;
using ducky_api_server.Repo.Users;
using ducky_api_server.Repo.UserServers;

namespace ducky_api_server.Service.Users
{
    public class UsersService : IUsersService
    {
        private UsersRepo repo;
        private UserServersRepo userServersRepo;
        public UsersService()
        {
            repo = new UsersRepo();
            userServersRepo = new UserServersRepo();
        }
        public List<UsersDTO> GetUsers(QueryUserDTO query)
        {
            return repo.GetUsers(query);
        }
        public (string msg, UsersDTO user) SignIn(string account, string password)
        {
            if (account.IsEmpty() || password.IsEmpty())
            {
                return (SystemMessage.AccountOrPasswordCanNotBeEmpty, null);
            }
            // 明文密码md5
            password = Md5.Encrypt(password.Trim(), 32);

            return repo.UserSignIn(account, password);
        }
        public UsersDTO GetUser(string accesstoken)
        {
            if (accesstoken.IsEmpty())
            {
                return null;
            }
            var user = repo.GetUser(accesstoken);
            return user;
        }
        public (string msg, UsersDTO user) AddUser(UsersDTO model)
        {
            if (model.IsNull() || model.Name.IsEmpty() || model.Email.IsEmpty() || model.Role.IsEmpty())
            {
                return (SystemMessage.MissingKeyParameters, null);
            }
            var user = repo.AddUser(model);
            return ("", user);
        }
        public UsersDTO UpdateUser(string id, UsersDTO model)
        {
            if (model == null || id.IsEmpty())
            {
                return null;
            }
            model.ID = id;
            var user = repo.UpdateUser(model);
            return user;
        }
        public bool UnLockUser(string id)
        {
            var user = repo.GetUserById(id);
            if (!user.IsNull())
            {
                bool success;
                if (user.Locked)
                {
                    success = repo.UnLockUser(id);
                }
                else
                {
                    success = repo.LockUser(id);
                }
                return success;
            }
            return false;
        }
        public bool EnableUser(string id)
        {
            var user = repo.GetUserById(id);
            if (!user.IsNull())
            {
                bool success;
                if (user.Enabled)
                {
                    success = repo.DisableUser(id);
                }
                else
                {
                    success = repo.EnableUser(id);
                }
                return success;
            }
            return false;
        }
        public bool UpdateRole(string id, string role)
        {
            bool success = repo.UpdateRole(id, role);
            return success;
        }
        public bool RemoveUser(string id)
        {
            bool success = repo.RemoveUser(id);
            return success;
        }

        public bool AddUserServers(string id, List<UserServersDTO> list)
        {
            if (list.IsNull() || list.Count <= 0)
            {
                return false;
            }
            var user = repo.GetUserById(id);
            if (user.IsNull())
            {
                return false;
            }
            list.ForEach(x =>
            {
                x.UserID = user.ID;
            });
            return userServersRepo.AddUserServers(list);
        }
    }
}