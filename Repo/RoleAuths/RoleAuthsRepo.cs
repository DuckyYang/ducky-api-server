using System;
using System.Collections.Generic;
using ducky_api_server.Core;
using ducky_api_server.DTO.RoleAuths;
using ducky_api_server.Extensions;
using ducky_api_server.Model.RoleAuths;

namespace ducky_api_server.Repo.RoleAuths
{
    public class RoleAuthsRepo
    {
        private DbContext<RoleAuthsModel> Db;
        public RoleAuthsRepo()
        {
            Db = new DbContext<RoleAuthsModel>();
        }

        public List<RoleAuthsDTO> GetRoleAuths()
        {
            var list = Db.GetAll<RoleAuthsDTO>();
            return list;
        }
        public RoleAuthsDTO GetRoleAuth(string id)
        {
            return Db.GetSingle<RoleAuthsDTO>(x => x.ID == id);
        }
        public bool UpdateRoleViewAuth(string id, bool viewable)
        {
            return Db.Update(new RoleAuthsModel { Viewable = viewable }, x => x.ID == id, x => new { x.Viewable });
        }
        public bool UpdateRoleOperateAuth(string id, bool operable)
        {
            return Db.Update(new RoleAuthsModel { Operable = operable }, x => x.ID == id, x => new { x.Operable });
        }
        /// <summary>
        /// 给角色添加默认导航权限
        /// </summary>
        /// <param name="role"></param>
        /// <param name="menuIds"></param>
        public bool AddDefault(string role, List<string> menuIds)
        {
            // 
            var list = new List<RoleAuthsModel>();
            foreach (var item in menuIds)
            {
                list.Add(new RoleAuthsModel
                {
                    ID = GUID.New,
                    Role = role,
                    MenuID = item,
                    Viewable = false,
                    Operable = false
                });
            }
            return Db.InsertAll(list);
        }
    }
}