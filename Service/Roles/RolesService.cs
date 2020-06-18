using System.Linq;
using System.Collections.Generic;
using ducky_api_server.DTO.Roles;
using ducky_api_server.Repo.RoleAuths;
using ducky_api_server.Repo.Roles;
using ducky_api_server.Repo.Menus;
using ducky_api_server.Extensions;
using ducky_api_server.DTO.RoleAuths;

namespace ducky_api_server.Service.Roles
{
    public class RolesService : IRolesService
    {
        private RolesRepo repo;
        private RoleAuthsRepo authRepo;
        private MenusRepo menusRepo;
        public RolesService()
        {
            repo = new RolesRepo();
            authRepo = new RoleAuthsRepo();
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
        public List<RoleAuthsDTO> GetRoleAuths()
        {
            var list = authRepo.GetRoleAuths();
            
            var menus = menusRepo.GetMenus();

            list.ForEach(x =>
            {
                var menu = menus.FirstOrDefault(r => r.ID == x.MenuID);
                x.Menu = menu?.Name;
                x.MenuPath = menu?.Path;
                x.Order = menu?.Order ?? 0;
            });
            return list.OrderBy(x=>x.Role).ThenBy(x=>x.Order).ToList();
        }
        public bool AddRole(RolesDTO model)
        {
            if (model.IsNull() || model.Role.IsEmpty())
            {
                return false;
            }
            var exists = !repo.GetRole(model.Role).IsNull();
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
                authRepo.AddDefault(model.Role,menus.Select(x=>x.ID).ToList());
            }
            return success;
        }
    }
}