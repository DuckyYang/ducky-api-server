using System.Collections.Generic;
using ducky_api_server.DTO.Users;
using ducky_api_server.DTO.UserServers;

namespace ducky_api_server.Service.Users
{
    public interface IUsersService
    {
        List<UsersDTO> GetUsers(QueryUserDTO query);
        (string msg, UsersDTO user) SignIn(string account, string password);
        UsersDTO GetUser(string accesstoken);
        (UsersDTO user,string msg) AddUser(UsersDTO model);
        UsersDTO UpdateUser(string id, UsersDTO model);
        bool UnLockUser(string id);
        bool UpdateRole(string id, string role);
        bool RemoveUser(string id);
        bool EnableUser(string id);
        bool AddUserServers(string id,List<UserServersDTO> list);
    }
}