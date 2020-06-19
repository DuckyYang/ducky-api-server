using System.Linq;
using System.Collections.Generic;
using ducky_api_server.Repo.Documents;
using ducky_api_server.Repo.Servers;
using ducky_api_server.DTO.Documents;

namespace ducky_api_server.Service.Documents
{
    public class DocumentsService : IDocumentsService
    {
        private DocumentsRepo repo;
        private ServersRepo serversRepo;
        public DocumentsService()
        {
            repo = new DocumentsRepo();
            serversRepo = new ServersRepo();
        }

        public List<DocumentsTreeDTO> GetDocuments()
        {
            List<DocumentsTreeDTO> result = new List<DocumentsTreeDTO>();
            var all = repo.GetAllDocuments();
            var servers = serversRepo.GetAll().OrderBy(x => x.Order).ToList();
            // 递归组装一下数据
            foreach (var item in servers)
            {
                result.Add(new DocumentsTreeDTO
                {
                    ID = item.ID,
                    PID = "",
                    Title = item.Name,
                    Open = false,
                    Document = null,
                    IsCollection = false,
                    IsServer = true
                });
                // 
                var collections = all.Where(x => x.ServerID == item.ID);
                foreach (var collection in collections)
                {
                    result.Add(new DocumentsTreeDTO
                    {
                        ID = collection.ID,
                        PID = collection.ServerID,
                        Title = collection.Name,
                        Open = false,
                        IsCollection = true,
                        IsServer = false,
                        Document = null
                    });
                    // 
                    var requests = all.Where(x => x.CollectionID == collection.ID);
                    foreach (var req in requests)
                    {
                        result.Add(new DocumentsTreeDTO
                        {
                            ID = req.ID,
                            PID = req.CollectionID,
                            Title = req.Name,
                            Open = false,
                            IsCollection = false,
                            IsServer = false,
                            Document = req
                        });
                    }
                }
            }
            return result;
        }
        public bool Update(string id, DocumentsDTO dto)
        {
            return repo.UpdateRequestDocument(id, dto);
        }
        public bool Remove(string id)
        {
            return repo.RemoveDocument(id);
        }
    }
}