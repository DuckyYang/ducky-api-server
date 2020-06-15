using ducky_api_server.Core;
using ducky_api_server.Model.Menus;
using System.Collections.Generic;
using System.Linq;

namespace ducky_api_server.Repo
{
    public class MenusRepo
    {
        private DbContext<MenusModel> Db;
        public MenusRepo()
        {
            Db = new DbContext<MenusModel>();
        }

        public List<MenusModel> GetMenus()
        {
            return Db.GetAll().OrderBy(r=>r.order).ToList();
        }
    }
}