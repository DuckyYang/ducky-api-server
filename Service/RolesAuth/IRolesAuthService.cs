using System.Collections.Generic;
using ducky_api_server.Model.RolesAuth;

namespace ducky_api_server.Service.RolesAuth
{
    public interface IRolesAuthService
    {
        List<RolesAuthModel> GetRolesAuths();
        bool ChangeRoleViewAuth(string id);
        bool ChangeRoleOperateAuth(string id);
    }
}