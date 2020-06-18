using System.Collections.Generic;
using ducky_api_server.Repo.Menus;
using ducky_api_server.Model.Menus;

namespace ducky_api_server.Service.Menus
{
    public class MenusService:IMenusService
    {
        private MenusRepo repo;
        public MenusService()
        {
            repo = new MenusRepo();
        }

        public List<MenusModel> GetMenus()
        {
            return repo.GetMenus();
        }
    }
}