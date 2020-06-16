using System.Linq;
using System.Collections.Generic;
using ducky_api_server.Model.RolesAuth;
using ducky_api_server.Repo;
using ducky_api_server.Service.Roles;
using ducky_api_server.Service.Menus;
using ducky_api_server.Core;

namespace ducky_api_server.Service.RolesAuth
{
    public class RolesAuthService : IRolesAuthService
    {
        private RolesAuthRepo repo;
        private MenusRepo menusRepo;
        public RolesAuthService()
        {
            repo = new RolesAuthRepo();
            menusRepo = new MenusRepo();
        }

        public bool ChangeRoleOperateAuth(string id)
        {
            var auth = repo.GetRoleAuth(id);
            if (auth.IsNull())
            {
                return false;
            }
            return repo.UpdateRoleOperateAuth(auth.id, auth.operate != 1);
        }

        public bool ChangeRoleViewAuth(string id)
        {
            var auth = repo.GetRoleAuth(id);
            if (auth.IsNull())
            {
                return false;
            }
            return repo.UpdateRoleViewAuth(auth.id, auth.view != 1);
        }

        public List<RolesAuthModel> GetRolesAuths()
        {
            var list = repo.GetRolesAuth();

            // get roles name and menus name
            var menus = menusRepo.GetMenus();

            list.ForEach(x =>
            {
                var menu = menus.FirstOrDefault(r => r.id == x.menuid);
                x.menu = menu?.name;
                x.menu_path = menu?.path;
                x.order = menu?.order ?? 0;
            });
            return list.OrderBy(x=>x.role).ThenBy(x=>x.order).ToList();
        }
    }
}