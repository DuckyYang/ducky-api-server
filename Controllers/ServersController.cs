using ducky_api_server.Model;
using ducky_api_server.Model.Servers;
using ducky_api_server.Service.Servers;
using Microsoft.AspNetCore.Mvc;

namespace ducky_api_server.Controllers
{
    [Route("[controller]")]
    public class ServersController : BaseController
    {
        private IServersService Service;
        public ServersController(IServersService service)
        {
            Service = service;
        }
        [HttpGet]
        [Route("")]
        public ResponseModel GetList([FromQuery] QueryServersModel query)
        {
            var result = Service.GetList(query);
            return Success(result, query.Total);
        }
        [HttpPost]
        [Route("")]
        public ResponseModel Add([FromBody] ServersModel model)
        {
            var result = Service.Add(model);
            return result ? Success(model) : Fail();
        }
        [HttpPut]
        [Route("{id}")]
        public ResponseModel Update(string id, [FromBody] ServersModel model)
        {
            var result = Service.Update(id, model);
            return result ? Success() : Fail();
        }
        [HttpDelete]
        [Route("{id}")]
        public ResponseModel Delete(string id)
        {
            var result = Service.Delete(id);
            return result ? Success() : Fail();
        }

        [HttpPut]
        [Route("{id}/enabled")]
        public ResponseModel Enable(string id)
        {
            var result = Service.EnableServer(id);
            return result ? Success() : Fail();
        }
        [HttpPut]
        [Route("{id}/disabled")]
        public ResponseModel Disable(string id)
        {
            var result = Service.DisableServer(id);
            return result ? Success() : Fail();
        }
    }
}