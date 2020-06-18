using ducky_api_server.Repo.Documents;
using ducky_api_server.DTO.Servers;
using System.Collections.Generic;
using ducky_api_server.DTO.Documents;
using ducky_api_server.Repo.Servers;
using ducky_api_server.Repo.UserServers;
using ducky_api_server.Extensions;

namespace ducky_api_server.Service.Servers
{
    public class ServersService : IServersService
    {
        private ServersRepo repo;
        private DocumentsRepo documentsRepo;
        private UserServersRepo userServersRepo;
        public ServersService()
        {
            repo = new ServersRepo();
            userServersRepo = new UserServersRepo();
            documentsRepo = new DocumentsRepo();
        }
        public bool Add(ServersDTO model)
        {
            if (model.IsNull())
            {
                return false;
            }
            return repo.Add(model);
        }

        public bool Delete(string id)
        {
            if (id.IsEmpty())
            {
                return false;
            }
            bool success = repo.Delete(id);
            if (success)
            {
                // remove from user servers
                userServersRepo.RemoveUserServer(id);
            }
            return success;
        }

        public bool DisableServer(string id)
        {
            if (id.IsEmpty())
            {
                return false;
            }
            return repo.DisableServer(id);
        }

        public bool EnableServer(string id)
        {
            if (id.IsEmpty())
            {
                return false;
            }
            return repo.EnableServer(id);
        }

        public List<ServersDTO> GetList(QueryServersDTO query)
        {
            return repo.GetList(query);
        }

        public bool Update(string id, ServersDTO model)
        {
            if (id.IsEmpty() || model.IsNull())
            {
                return false;
            }
            model.ID = id;
            return repo.Update(model);
        }
        public bool AddCollection(string id, DocumentsDTO dto)
        {
            if (dto.IsNull() || dto.Name.IsEmpty())
            {
                return false;
            }
            return documentsRepo.AddCollection(id,dto.Name);
        }
    }
}