using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ducky_api_server.Model;
using ducky_api_server.Service.Users;
using ducky_api_server.Model.Users;

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
            return Success(result,query.Total);
        }
        [HttpPost]
        [Route("")]
        public ResponseModel Post([FromBody] UsersModel model)
        {
            var result = UsersService.AddUser(model);
            return Success(result);
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
        [Route("{id}/role")]
        public ResponseModel UpdateRole(string id, string role)
        {
            var result = UsersService.UpdateRole(id, role);
            return Success(result);
        }
    }
}