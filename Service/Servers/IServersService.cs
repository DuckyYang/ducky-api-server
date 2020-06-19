using System.Collections.Generic;
using ducky_api_server.DTO.Documents;
using ducky_api_server.DTO.Servers;

namespace ducky_api_server.Service.Servers
{
    public interface IServersService
    {
        bool Add(ServersDTO model);
        bool Delete(string id);
        bool Update(string id, ServersDTO model);
        bool EnableServer(string id);
        bool DisableServer(string id);
        List<ServersDTO> GetList(QueryServersDTO query);
        bool AddCollection(string id, DocumentAddDTO dto);
        bool AddRequestToServer(string id, DocumentAddDTO dto);
        bool AddRequestToCollection(string id, string collectionId, DocumentAddDTO dto);
    }
}