using Microsoft.AspNetCore.Mvc;
using ducky_api_server.DTO;
using ducky_api_server.Service.Documents;
using ducky_api_server.DTO.Documents;

namespace ducky_api_server.Controllers
{
    [Route("[controller]")]
    public class DocumentsController : BaseController
    {
        private IDocumentsService Service;
        public DocumentsController(IDocumentsService service)
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
        public ResponseDTO Update(string id, [FromBody] DocumentsDTO dto)
        {
            var result = Service.Update(id, dto);
            return Success(result);
        }

        [Route("{id}")]
        [HttpDelete]
        public ResponseDTO Update(string id)
        {
            var result = Service.Remove(id);
            return Success(result);
        }


    }
}