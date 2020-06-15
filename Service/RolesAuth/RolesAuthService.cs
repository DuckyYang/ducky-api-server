using System.Linq;
using System.Collections.Generic;
using ducky_api_server.Model.RolesAuth;
using ducky_api_server.Repo;
using ducky_api_server.Service.Roles;
using ducky_api_server.Service.Menus;

namespace ducky_api_server.Service.RolesAuth
{
    public class RolesAuthService: IRolesAuthService
    {
        private RolesAuthRepo repo;
        private IRolesService RolesService ;
        private IMenusService MenusService;
        public RolesAuthService(IRolesService rolesService,IMenusService menusService)
        {
            repo = new RolesAuthRepo();
            RolesService = rolesService;
            MenusService = menusService;
        }       

        public List<RolesAuthModel> GetRolesAuths()
        {
            var list = repo.GetRolesAuth();

            // get roles name and menus name
            var menus = MenusService.GetMenus();

            list.ForEach(x=>
            {
                x.menu = menus.FirstOrDefault(r=>r.id == x.menuid)?.name;
            });
            return list;
        }       
    }
}