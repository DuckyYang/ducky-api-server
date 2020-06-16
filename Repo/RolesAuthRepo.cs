using System;
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
        public RolesAuthModel GetRoleAuth(string id)
        {
            return Db.GetSingle(x=>x.id == id);
        }
        public bool UpdateRoleViewAuth(string id,bool viewable)
        {
            int view = viewable ? 1 : 0;
            return Db.Update(new RolesAuthModel{ view = view},x=>x.id == id,x=>new{x.view});
        }
         public bool UpdateRoleOperateAuth(string id,bool operable)
        {
            int operate = operable ? 1 : 0;
            return Db.Update(new RolesAuthModel{ operate = operate},x=>x.id == id,x=>new{x.operate});
        }
        /// <summary>
        /// 给角色添加默认导航权限
        /// </summary>
        /// <param name="role"></param>
        /// <param name="menuIds"></param>
        public bool AddDefault(string role, List<string> menuIds)
        {
            // 
            var list = new List<RolesAuthModel>();
            foreach (var item in menuIds)
            {
                list.Add(new RolesAuthModel
                {
                    id = GUID.New,
                    role = role,
                    menuid = item,
                    view = 0,
                    operate = 0
                });
            }
            return Db.InsertAll(list);
        }
    }
}