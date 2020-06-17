using ducky_api_server.Core;
using ducky_api_server.DTO.Roles;
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

        public List<RolesDTO> GetAll(int pageIndex,int pageSize)
        {
            return Db.GetList(r=>r.enabled == 1,pageIndex,pageSize).MapList<RolesDTO>();
        }

        public List<RolesDTO> GetAll()
        {
            return Db.GetAll().MapList<RolesDTO>();
        }
        public RolesDTO GetRole(string role)
        {
            return Db.GetSingle(x=>x.role == role).Map<RolesDTO>();
        }

        public bool AddRole(RolesDTO dto)
        {
            var model = dto.Map<RolesModel>();
            model.enabled = 1;
            return Db.Insert(model);
        }
    }
}