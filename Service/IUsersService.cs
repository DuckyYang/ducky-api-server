using System.Collections.Generic;
using ducky_api_server.Model.Users;

namespace ducky_api_server.Users
{
    public interface IUsersService
    {
        List<UsersModel> GetUsers(QueryUserModel query);
        (string msg, UsersModel user) SignIn(string account, string password);
        UsersModel GetUser(string accesstoken);
        UsersModel AddUser(UsersModel model);
        UsersModel UpdateUser(string id, UsersModel model);
    }
}