using System.Collections.Generic;
using ducky_api_server.Core;
using ducky_api_server.Model.UserServers;

namespace ducky_api_server.Repo
{
    public class UserServersRepo
    {
        private DbContext<UserServersModel> Db;
        public UserServersRepo()
        {
            Db = new DbContext<UserServersModel>();
        }

        public bool AddUserServers(List<UserServersModel> list)
        {
            return Db.InsertAll(list);
        }
        public bool RemoveUserServer(string serverId)
        {
            return Db.Delete(x=>x.server_id == serverId);
        }
    }
}