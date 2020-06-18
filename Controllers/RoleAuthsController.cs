using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ducky_api_server.Service.RoleAuths;
using ducky_api_server.DTO;

namespace ducky_api_server.Controllers
{
    [Route("[controller]")]
    public class RoleAuthsController: BaseController
    {
        private IRoleAuthsService Service;
        public RoleAuthsController(IRoleAuthsService service)
        {
            Service = service;
        }

        [Route("{id}/viewable")]
        [HttpPut]
        public ResponseDTO ChangeRoleViewAuth(string id)
        {
            var result = Service.ChangeRoleViewAuth(id);
            return Success(result);
        }
        [Route("{id}/operable")]
        [HttpPut]
        public ResponseDTO ChangeRoleOperateAuth(string id)
        {
            var result = Service.ChangeRoleOperateAuth(id);
            return Success(result);
        }
    }
}