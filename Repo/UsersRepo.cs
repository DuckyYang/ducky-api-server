using ducky_api_server.Core;
using ducky_api_server.Models;

namespace ducky_api_server.Repo
{
    public class UsersRepo:DbContext<UsersModel>
    {
        public UsersModel GetUser()
        {
            return base.GetSingle();
        }
    }
}