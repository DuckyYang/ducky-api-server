using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ducky_api_server.DTO;
using ducky_api_server.Service.Users;
using ducky_api_server.DTO.Users;
using ducky_api_server.Core;
using ducky_api_server.DTO.UserServers;

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
        public ResponseDTO Get([FromQuery] QueryUserDTO query)
        {
            var result = UsersService.GetUsers(query);
            return Success(result, query.Total);
        }
        [HttpPost]
        [Route("")]
        public ResponseDTO Post([FromBody] UsersDTO model)
        {
            var result = UsersService.AddUser(model);
            return result.user.IsNull() ? Fail(result.msg) : Success(result.user);
        }
        [HttpPut]
        [Route("{id}")]
        public ResponseDTO Put(string id, [FromBody] UsersDTO model)
        {
            var result = UsersService.UpdateUser(id, model);
            return Success(result);
        }
        [HttpPut]
        [Route("{id}/locked")]
        public ResponseDTO UnLockUser(string id)
        {
            var result = UsersService.UnLockUser(id);
            return Success(result);
        }
        [HttpPut]
        [Route("{id}/enabled")]
        public ResponseDTO EnableUser(string id)
        {
            var result = UsersService.EnableUser(id);
            return Success(result);
        }
        [HttpDelete]
        [Route("{id}")]
        public ResponseDTO RemoveUser(string id)
        {
            var result = UsersService.RemoveUser(id);
            return result ? Success(id) : Fail();
        }

        [HttpPost]
        [Route("{id}/servers")]
        public ResponseDTO AddUserServers(string id,[FromBody]List<UserServersDTO> list)
        {
            var result = UsersService.AddUserServers(id,list);
            return result ? Success() : Fail();
        }
    }
}