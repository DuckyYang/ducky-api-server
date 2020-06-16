using System.Collections.Generic;
using ducky_api_server.Core;
using ducky_api_server.Model.Servers;
using SqlSugar;

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
            model.ID = GUID.New;
            model.Enabled = 1;
            return Db.Insert(model);
        }

        public List<ServersModel> GetList(QueryServersModel query)
        {
            var sqlExp = Db.GetQueryExpression();

            sqlExp.WhereIF(!query.Filter.IsEmpty(),r=>r.Name.Contains(query.Filter));
            sqlExp.OrderBy(x=>x.Order,OrderByType.Desc);

            int total = 0;
            var list = Db.GetList(sqlExp, query.PageIndex,query.PageSize,ref total);
            query.Total = total;
            return list;
        }
        public bool EnableServer(string id)
        {
            return Db.Update(new ServersModel { Enabled = 1 },x=>x.ID==id,x=>new { x.Enabled });
        }
        public bool DisableServer(string id)
        {
            return Db.Update(new ServersModel { Enabled = 0 },x=>x.ID==id,x=>new { x.Enabled });
        }
        public bool Delete(string id)
        {
            return Db.Delete(x=>x.ID == id);
        }
        public bool Update(ServersModel model)
        {
            var detail = Db.GetSingle(x=>x.ID == model.ID);
            if (detail != null)
            {
                detail.Name = model.Name.IsEmpty() ? detail.Name : model.Name;
                detail.BaseUrl = model.BaseUrl.IsEmpty() ? detail.BaseUrl : model.BaseUrl;
                detail.DefaultHeaders = model.DefaultHeaders.IsEmpty() ? detail.DefaultHeaders :model.DefaultHeaders;
                detail.Order = model.Order;
                return Db.Update(detail,x=>x.ID == detail.ID,x=>new{x.Name,x.BaseUrl,x.DefaultHeaders,x.Order});
            }
            return false;
        }
    }
}