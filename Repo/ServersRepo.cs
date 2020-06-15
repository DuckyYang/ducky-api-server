using System.Collections.Generic;
using ducky_api_server.Core;
using ducky_api_server.Model.Servers;

namespace ducky_api_server.Repo
{
    public class ServersRepo
    {
        private DbContext<ServersModel> Db;
        public ServersRepo()
        {
            Db = new DbContext<ServersModel>();
        }

        public bool Add(ServersModel model)
        {
            model.id = GUID.New;
            model.enabled = 1;
            return Db.Insert(model);
        }

        public List<ServersModel> GetList(QueryServersModel query)
        {
            var sqlExp = Db.GetQueryExpression();

            sqlExp.WhereIF(!query.Filter.IsEmpty(),r=>r.name.Contains(query.Filter));
            sqlExp.OrderBy(x=>x.order);

            int total = 0;
            var list = Db.GetList(sqlExp, query.PageIndex,query.PageSize,ref total);
            query.Total = total;
            return list;
        }
        public bool EnableServer(string id)
        {
            return Db.Update(new ServersModel { enabled = 1 },x=>x.id==id,x=>new { x.enabled });
        }
        public bool DisableServer(string id)
        {
            return Db.Update(new ServersModel { enabled = 0 },x=>x.id==id,x=>new { x.enabled });
        }
        public bool Delete(string id)
        {
            return Db.Delete(x=>x.id == id);
        }
        public bool Update(ServersModel model)
        {
            var detail = Db.GetSingle(x=>x.id == model.id);
            if (detail != null)
            {
                detail.name = model.name.IsEmpty() ? detail.name : model.name;
                detail.baseurl = model.baseurl.IsEmpty() ? detail.baseurl : model.baseurl;
                detail.default_headers = model.default_headers.IsEmpty() ? detail.default_headers :model.default_headers;
                detail.order = model.order;
                return Db.Update(detail,x=>x.id == detail.id,x=>new{x.name,x.baseurl,x.default_headers,x.order});
            }
            return false;
        }
    }
}