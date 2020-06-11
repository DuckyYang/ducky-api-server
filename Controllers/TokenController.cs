using ducky_api_server.Core;
using ducky_api_server.Model;
using ducky_api_server.Model.Users;
using ducky_api_server.Users;
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
        public ResponseModel SignIn([FromBody]UsersSignInModel model)
        {
            var (msg,user) = UsersService.SignIn(model.Account, model.Password);
            return user.IsNull() ? Fail(msg) : Success(user);
        }
        [HttpGet]
        [Route("{accesstoken}")]
        public ResponseModel Verify(string accesstoken)
        {
            var user = UsersService.GetUser(accesstoken);
            return Success(user);
        }
    }
}