using Microsoft.AspNetCore.Mvc;
using ducky_api_server.DTO;
using ducky_api_server.Service.Request;
using ducky_api_server.DTO.Request;

namespace ducky_api_server.Controllers
{
    [Route("[controller]")]
    public class RequestController : BaseController
    {
        private IRequestService Service;
        public RequestController(IRequestService service)
        {
            Service = service;
        }

        [Route("")]
        [HttpGet]
        public ResponseDTO GetAll()
        {
            var result = Service.GetDocuments();
            return Success(result);
        }
        [Route("{id}")]
        [HttpPut]
        public ResponseDTO Update(string id, [FromBody] RequestDTO dto)
        {
            var result = Service.Update(id, dto);
            return Success(result);
        }

        [Route("{id}")]
        [HttpDelete]
        public ResponseDTO Remove(string id)
        {
            var result = Service.Remove(id);
            return Success(result);
        }
        [Route("{id}/name")]
        [HttpPut]
        public ResponseDTO Rename(string id,[FromBody] RequestDTO dto)
        {
            var result = Service.Rename(id,dto.Name);
            return Success(result);
        }

        [Route("{id}/send")]
        [HttpGet]
        public ResponseDTO Send(string id)
        {
            var result = Service.Send(id);
            return result.success ? Success(result.msg) : Fail(result.msg);
        }
    }
}