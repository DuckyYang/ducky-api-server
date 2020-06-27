using System.Collections.Generic;
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
        bool AddCollection(string id, string name);
    }
}