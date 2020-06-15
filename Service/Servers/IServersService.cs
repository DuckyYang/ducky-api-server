using System.Collections.Generic;
using ducky_api_server.Model.Servers;

namespace ducky_api_server.Service.Servers
{
    public interface IServersService
    {
        bool Add(ServersModel model);
        bool Delete(string id);
        bool Update(string id, ServersModel model);
        bool EnableServer(string id);
        bool DisableServer(string id);
        List<ServersModel> GetList(QueryServersModel query);
    }
}