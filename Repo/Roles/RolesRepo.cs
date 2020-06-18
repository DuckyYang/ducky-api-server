using ducky_api_server.Core;
using ducky_api_server.DTO.Roles;
using ducky_api_server.Extensions;
using ducky_api_server.Model.Roles;
using System;
using System.Collections.Generic;

namespace ducky_api_server.Repo.Roles
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
            return Db.GetList<RolesDTO>(r=>r.Enabled == true,pageIndex,pageSize);
        }

        public List<RolesDTO> GetAll()
        {
            return Db.GetAll<RolesDTO>();
        }
        public RolesDTO GetRole(string role)
        {
            return Db.GetSingle<RolesDTO>(x=>x.Role == role);
        }

        public bool AddRole(RolesDTO dto)
        {
            var model = dto.Map<RolesModel>();
            model.Enabled = true;
            return Db.Insert(model);
        }
    }
}