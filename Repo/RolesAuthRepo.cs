using System.Collections.Generic;
using ducky_api_server.Core;
using ducky_api_server.Model.RolesAuth;

namespace ducky_api_server.Repo
{
    public class RolesAuthRepo
    {
        private DbContext<RolesAuthModel> Db;
        public RolesAuthRepo()
        {
            Db = new DbContext<RolesAuthModel>();
        }

        public List<RolesAuthModel> GetRolesAuth()
        {
            var list = Db.GetAll();
            return list;
        }
    }
}