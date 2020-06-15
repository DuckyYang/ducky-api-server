using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ducky_api_server.Model.Menus;
using ducky_api_server.Model;
using ducky_api_server.Core;
using ducky_api_server.Service.Menus;

namespace ducky_api_server.Controllers
{
    [Route("[controller]")]
    public class MenusController:BaseController
    {
        private IMenusService Service;
        public MenusController(IMenusService service)
        {
            Service = service;
        }

        [HttpGet]
        [Route("")]
        public ResponseModel Get()
        {
            var result = Service.GetMenus();
            return Success(result);
        }
    }
}