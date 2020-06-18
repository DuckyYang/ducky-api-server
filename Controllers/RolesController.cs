using Microsoft.AspNetCore.Mvc;
using ducky_api_server.DTO;
using ducky_api_server.Service.Roles;
using ducky_api_server.Service.RoleAuths;
using ducky_api_server.DTO.Roles;

namespace ducky_api_server.Controllers
{
    [Route("[controller]")]
    public class RolesController:BaseController
    {
        private IRolesService Service;
        private IRoleAuthsService RolesAuthService;
        public RolesController(IRolesService service,IRoleAuthsService rolesAuthService)
        {
            Service = service;
            RolesAuthService = rolesAuthService;
        }
        [Route("")]
        [HttpGet]
        public ResponseDTO Get([FromQuery]QueryRolesDTO query)
        {
            var result = Service.GetList(query);
            return Success(result);
        }
        [Route("auths")]
        [HttpGet]
        public ResponseDTO GetRoleAuths()
        {
            var result = Service.GetRoleAuths();
            return Success(result);
        }
        [Route("")]
        [HttpPost]
        public ResponseDTO Post([FromBody]RolesDTO model)
        {
            var result = Service.AddRole(model);
            return result ? Success(model) : Fail();
        }
    }
}