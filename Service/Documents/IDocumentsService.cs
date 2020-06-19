using System.Collections.Generic;
using ducky_api_server.DTO.Documents;

namespace ducky_api_server.Service.Documents
{
    public interface IDocumentsService
    {
        List<DocumentsTreeDTO> GetDocuments();
        bool Update(string id, DocumentsDTO dto);
        bool Remove(string id);
    }
}