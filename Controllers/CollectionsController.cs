using ducky_api_server.Service.Collections;
using ducky_api_server.DTO;
using ducky_api_server.DTO.Request;
using Microsoft.AspNetCore.Mvc;

namespace ducky_api_server.Controllers
{
    [Route("[controller]")]
    public class CollectionsController:BaseController
    {
        ICollectionsService Service;
        public CollectionsController(ICollectionsService service)
        {
            Service = service;
        }

        [Route("{id}/request")]
        [HttpPost]
        public ResponseDTO AddRequest(string id,[FromBody]RequestAddDTO dto)
        {
            var result =  Service.AddRequest(id,dto.Name);
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
        public ResponseDTO Rename(string id,[FromBody]RequestAddDTO dto)
        {
            var result = Service.Rename(id,dto.Name);
            return Success(result);
        }
    }
}