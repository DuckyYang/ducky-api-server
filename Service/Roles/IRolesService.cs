using ducky_api_server.Model.Roles;
using System.Collections.Generic;

namespace ducky_api_server.Service.Roles
{
    public interface IRolesService
    {
         List<RolesModel> GetList(QueryRolesModel query);
    }
}