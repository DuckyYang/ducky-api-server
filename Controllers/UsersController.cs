using Microsoft.AspNetCore.Mvc;
using ducky_api_server.Model.Users;
using ducky_api_server.Users;
using System.Collections.Generic;
using ducky_api_server.Model;

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
            return Success(result);
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
    }
}