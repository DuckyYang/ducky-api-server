using ducky_api_server.Core;
using ducky_api_server.DTO;
using ducky_api_server.DTO.Users;
using ducky_api_server.Extensions;
using ducky_api_server.Service.Users;
using Microsoft.AspNetCore.Mvc;

namespace ducky_api_server.Controllers
{
    [Route("[controller]")]
    public class TokenController : BaseController
    {
        public IUsersService UsersService;
        public TokenController(IUsersService usersService)
        {
            UsersService = usersService;
        }
        [HttpPost]
        [Route("")]
        public ResponseDTO SignIn([FromBody]UsersSignInDTO model)
        {
            var (msg,user) = UsersService.SignIn(model.Account, model.Password);
            return user.IsNull() ? Fail(msg) : Success(user);
        }
        [HttpGet]
        [Route("{accesstoken}")]
        public ResponseDTO Verify(string accesstoken)
        {
            var user = UsersService.GetUser(accesstoken);
            return Success(user);
        }
    }
}