using System.Linq;
using System.Collections.Generic;
using ducky_api_server.Core;
using ducky_api_server.DTO.Roles;
using ducky_api_server.Repo;

namespace ducky_api_server.Service.Roles
{
    public class RolesService : IRolesService
    {
        private RolesRepo repo;
        private RolesAuthRepo authRepo;
        private MenusRepo menusRepo;
        public RolesService()
        {
            repo = new RolesRepo();
            authRepo = new RolesAuthRepo();
            menusRepo = new MenusRepo();
        }

        public List<RolesDTO> GetList(QueryRolesDTO query)
        {
            return repo.GetAll(query.PageIndex,query.PageSize);
        }

        public List<RolesDTO> GetAll()
        {
            return repo.GetAll();
        }
        public bool AddRole(RolesDTO model)
        {
            if (model.IsNull() || model.role.IsEmpty())
            {
                return false;
            }
            var exists = !repo.GetRole(model.role).IsNull();
            if (exists)
            {
                return false;
            }
            var success = repo.AddRole(model);
            if (success)
            {
                // get all menus 
                var menus = menusRepo.GetMenus();
                // add defaut menus auth
                authRepo.AddDefault(model.role,menus.Select(x=>x.id).ToList());
            }
            return success;
        }
    }
}