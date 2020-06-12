using Microsoft.AspNetCore.Mvc;
using ducky_api_server.Model;
using ducky_api_server.Model.Roles;
using ducky_api_server.Service.Roles;

namespace ducky_api_server.Controllers
{
    [Route("[controller]")]
    public class RolesController:BaseController
    {
        private IRolesService Service;
        public RolesController(IRolesService service)
        {
            Service = service;
        }
        [Route("")]
        public ResponseModel Get([FromQuery]QueryRolesModel query)
        {
            var result = Service.GetList(query);
            return Success(result);
        }
    }
}