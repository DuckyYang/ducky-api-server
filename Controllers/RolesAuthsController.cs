using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ducky_api_server.Model.RolesAuth;
using ducky_api_server.Service.RolesAuth;
using ducky_api_server.Model;

namespace ducky_api_server.Controllers
{
    [Route("[controller]")]
    public class RolesAuthsController: BaseController
    {
        private IRolesAuthService Service;
        public RolesAuthsController(IRolesAuthService service)
        {
            Service = service;
        }

        [Route("{id}/viewable")]
        [HttpPut]
        public ResponseModel ChangeRoleViewAuth(string id)
        {
            var result = Service.ChangeRoleViewAuth(id);
            return Success(result);
        }
        [Route("{id}/operable")]
        [HttpPut]
        public ResponseModel ChangeRoleOperateAuth(string id)
        {
            var result = Service.ChangeRoleOperateAuth(id);
            return Success(result);
        }
    }
}