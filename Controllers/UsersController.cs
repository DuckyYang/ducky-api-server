using Microsoft.AspNetCore.Mvc;
using ducky_api_server.Models;
using ducky_api_server.Repo;

namespace ducky_api_server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController: ControllerBase
    {
        [HttpGet]
        public object Get()
        {
            var user =new UsersRepo().GetUser();
            return user;
        }
    }
}