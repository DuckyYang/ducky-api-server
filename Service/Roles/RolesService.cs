using System.Collections.Generic;
using ducky_api_server.Model.Roles;
using ducky_api_server.Repo;

namespace ducky_api_server.Service.Roles
{
    public class RolesService : IRolesService
    {
        private RolesRepo repo;
        public RolesService()
        {
            repo = new RolesRepo();
        }

        public List<RolesModel> GetList(QueryRolesModel query)
        {
            return repo.GetAll(query.PageIndex,query.PageSize);
        }
    }
}