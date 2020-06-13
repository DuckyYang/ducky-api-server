using System.Collections.Generic;
using ducky_api_server.Model.Users;

namespace ducky_api_server.Service.Users
{
    public interface IUsersService
    {
        List<UsersModel> GetUsers(QueryUserModel query);
        (string msg, UsersModel user) SignIn(string account, string password);
        UsersModel GetUser(string accesstoken);
        (UsersModel user,string msg) AddUser(UsersModel model);
        UsersModel UpdateUser(string id, UsersModel model);
        bool UnLockUser(string id);
        bool UpdateRole(string id, string role);
        bool RemoveUser(string id);
        bool EnableUser(string id);
    }
}