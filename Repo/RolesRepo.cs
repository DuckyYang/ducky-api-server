using ducky_api_server.Core;
using ducky_api_server.Model.Roles;
using System.Collections.Generic;

namespace ducky_api_server.Repo
{
    public class RolesRepo
    {
        private DbContext<RolesModel> Db;
        public RolesRepo()
        {
            Db = new DbContext<RolesModel>();
        }

        public List<RolesModel> GetAll(int pageIndex,int pageSize)
        {
            return Db.GetList(r=>r.enabled == 1,pageIndex,pageSize);
        }

        
    }
}