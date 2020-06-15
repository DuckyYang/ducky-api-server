using ducky_api_server.Repo;
using ducky_api_server.Model.Servers;
using ducky_api_server.Core;
using System.Collections.Generic;

namespace ducky_api_server.Service.Servers
{
    public class ServersService : IServersService
    {
        private ServersRepo repo;
        private UserServersRepo userServersRepo;
        public ServersService()
        {
            repo = new ServersRepo();
            userServersRepo = new UserServersRepo();
        }
        public bool Add(ServersModel model)
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

        public List<ServersModel> GetList(QueryServersModel query)
        {
            return repo.GetList(query);
        }

        public bool Update(string id, ServersModel model)
        {
            if (id.IsEmpty() || model.IsNull())
            {
                return false;
            }
            model.id = id;
            return repo.Update(model);
        }
    }
}