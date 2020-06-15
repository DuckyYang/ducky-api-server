using Microsoft.AspNetCore.Mvc;
using ducky_api_server.Model;
using ducky_api_server.Model.Roles;
using ducky_api_server.Service.Roles;
using ducky_api_server.Service.RolesAuth;

namespace ducky_api_server.Controllers
{
    [Route("[controller]")]
    public class RolesController:BaseController
    {
        private IRolesService Service;
        private IRolesAuthService RolesAuthService;
        public RolesController(IRolesService service,IRolesAuthService rolesAuthService)
        {
            Service = service;
            RolesAuthService = rolesAuthService;
        }
        [Route("")]
        [HttpGet]
        public ResponseModel Get([FromQuery]QueryRolesModel query)
        {
            var result = Service.GetList(query);
            return Success(result);
        }
        [Route("menus")]
        [HttpGet]
        public ResponseModel GetRoleMenus()
        {
            var result = RolesAuthService.GetRolesAuths();
            return Success(result);
        }

    }
}