using System.Collections.Generic;
using ducky_api_server.Model.Menus;

namespace ducky_api_server.Service.Menus
{
    public interface IMenusService
    {
        List<MenusModel> GetMenus();
    }
}