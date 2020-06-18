using System.Collections.Generic;
using ducky_api_server.DTO.RoleAuths;

namespace ducky_api_server.Service.RoleAuths
{
    public interface IRoleAuthsService
    {
        bool ChangeRoleViewAuth(string id);
        bool ChangeRoleOperateAuth(string id);
    }
}