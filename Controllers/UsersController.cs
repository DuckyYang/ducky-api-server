using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ducky_api_server.Model;
using ducky_api_server.Service.Users;
using ducky_api_server.Model.Users;
using ducky_api_server.Core;

namespace ducky_api_server.Controllers
{
    [Route("[controller]")]
    public class UsersController : BaseController
    {
        public IUsersService UsersService;
        public UsersController(IUsersService usersService)
        {
            UsersService = usersService;
        }
        [HttpGet]
        [Route("")]
        public ResponseModel Get([FromQuery] QueryUserModel query)
        {
            var result = UsersService.GetUsers(query);
            return Success(result, query.Total);
        }
        [HttpPost]
        [Route("")]
        public ResponseModel Post([FromBody] UsersModel model)
        {
            var result = UsersService.AddUser(model);
            return result.user.IsNull() ? Fail(result.msg) : Success(result.user);
        }
        [HttpPut]
        [Route("{id}")]
        public ResponseModel Put(string id, [FromBody] UsersModel model)
        {
            var result = UsersService.UpdateUser(id, model);
            return Success(result);
        }
        [HttpPut]
        [Route("{id}/locked")]
        public ResponseModel UnLockUser(string id)
        {
            var result = UsersService.UnLockUser(id);
            return Success(result);
        }
        [HttpPut]
        [Route("{id}/enabled")]
        public ResponseModel EnableUser(string id)
        {
            var result = UsersService.EnableUser(id);
            return Success(result);
        }
        [HttpDelete]
        [Route("{id}")]
        public ResponseModel RemoveUser(string id)
        {
            var result = UsersService.RemoveUser(id);
            return result ? Success(id) : Fail();
        }
    }
}