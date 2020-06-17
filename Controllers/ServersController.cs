using ducky_api_server.DTO;
using ducky_api_server.DTO.Servers;
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
        public ResponseDTO GetList([FromQuery] QueryServersDTO query)
        {
            var result = Service.GetList(query);
            return Success(result, query.Total);
        }
        [HttpPost]
        [Route("")]
        public ResponseDTO Add([FromBody] ServersDTO model)
        {
            var result = Service.Add(model);
            return result ? Success(model) : Fail();
        }
        [HttpPut]
        [Route("{id}")]
        public ResponseDTO Update(string id, [FromBody] ServersDTO model)
        {
            var result = Service.Update(id, model);
            return result ? Success() : Fail();
        }
        [HttpDelete]
        [Route("{id}")]
        public ResponseDTO Delete(string id)
        {
            var result = Service.Delete(id);
            return result ? Success() : Fail();
        }

        [HttpPut]
        [Route("{id}/enabled")]
        public ResponseDTO Enable(string id)
        {
            var result = Service.EnableServer(id);
            return result ? Success() : Fail();
        }
        [HttpPut]
        [Route("{id}/disabled")]
        public ResponseDTO Disable(string id)
        {
            var result = Service.DisableServer(id);
            return result ? Success() : Fail();
        }
    }
}