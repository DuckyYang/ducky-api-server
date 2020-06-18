using System.Collections.Generic;
using ducky_api_server.Repo.Documents;
using ducky_api_server.DTO.Documents;

namespace ducky_api_server.Service.Documents
{
    public class DocumentsService:IDocumentsService
    {
        private DocumentsRepo repo;
        public DocumentsService()
        {
            repo = new DocumentsRepo();
        }

        public List<DocumentsDTO> GetDocuments()
        {
            var all = repo.GetAllDocuments();

            // 组装一下
            return all;
        }
    }
}