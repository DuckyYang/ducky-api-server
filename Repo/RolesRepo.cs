using ducky_api_server.Core;
using ducky_api_server.Model.Roles;
using System;
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

        public List<RolesModel> GetAll()
        {
            return Db.GetAll();
        }
        public RolesModel GetRole(string role)
        {
            return Db.GetSingle(x=>x.role == role);
        }

        public bool AddRole(RolesModel model)
        {
            model.enabled = 1;
            return Db.Insert(model);
        }
    }
}