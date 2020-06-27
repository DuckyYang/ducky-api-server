using System.Collections.Generic;
using ducky_api_server.DTO.Request;

namespace ducky_api_server.Service.Request
{
    public interface IRequestService
    {
        List<RequestTreeDTO> GetDocuments();
        bool Update(string id, RequestDTO dto);
        bool Remove(string id);
        bool Rename(string id, string name);
    }
}