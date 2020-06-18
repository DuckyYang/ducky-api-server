using System.Linq;
using System.Collections.Generic;
using ducky_api_server.DTO.RoleAuths;
using ducky_api_server.Repo.RoleAuths;
using ducky_api_server.Repo.Menus;
using ducky_api_server.Extensions;

namespace ducky_api_server.Service.RoleAuths
{
    public class RoleAuthsService : IRoleAuthsService
    {
        private RoleAuthsRepo repo;
        private MenusRepo menusRepo;
        public RoleAuthsService()
        {
            repo = new RoleAuthsRepo();
            menusRepo = new MenusRepo();
        }

        public bool ChangeRoleOperateAuth(string id)
        {
            var auth = repo.GetRoleAuth(id);
            if (auth.IsNull())
            {
                return false;
            }
            return repo.UpdateRoleOperateAuth(auth.ID, !auth.Operable);
        }

        public bool ChangeRoleViewAuth(string id)
        {
            var auth = repo.GetRoleAuth(id);
            if (auth.IsNull())
            {
                return false;
            }
            return repo.UpdateRoleViewAuth(auth.ID, !auth.Viewable);
        }
    }
}