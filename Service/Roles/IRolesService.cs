using ducky_api_server.DTO.Roles;
using ducky_api_server.DTO.RoleAuths;
using System.Collections.Generic;

namespace ducky_api_server.Service.Roles
{
    public interface IRolesService
    {
         List<RolesDTO> GetList(QueryRolesDTO query);
         List<RolesDTO> GetAll();
        bool AddRole(RolesDTO model);
        List<RoleAuthsDTO> GetRoleAuths();
    }
}