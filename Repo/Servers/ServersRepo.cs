using System;
using System.Collections.Generic;
using ducky_api_server.Core;
using ducky_api_server.DTO.Servers;
using ducky_api_server.Extensions;
using ducky_api_server.Model.Servers;
using SqlSugar;

namespace ducky_api_server.Repo.Servers
{
    public class ServersRepo
    {
        private DbContext<ServersModel> Db;
        public ServersRepo()
        {
            Db = new DbContext<ServersModel>();
        }

        public bool Add(ServersDTO dto)
        {
            var model = dto.Map<ServersModel>();
            model.ID = GUID.New;
            model.Enabled = true;
            return Db.Insert(model);
        }
        public List<ServersDTO> GetAll()
        {
            return Db.GetAll<ServersDTO>(x => x.Enabled);
        }

        public List<ServersDTO> GetList(QueryServersDTO query)
        {
            var sqlExp = Db.GetQueryExpression();

            sqlExp.WhereIF(!query.Filter.IsEmpty(), r => r.Name.Contains(query.Filter));
            sqlExp.OrderBy(x => x.Order, OrderByType.Desc);

            int total = 0;
            var list = Db.GetList(sqlExp, query.PageIndex, query.PageSize, ref total);
            query.Total = total;
            return list.MapList<ServersDTO>();
        }
        public bool EnableServer(string id)
        {
            return Db.Update(new ServersModel { Enabled = true }, x => x.ID == id, x => new { x.Enabled });
        }
        public bool DisableServer(string id)
        {
            return Db.Update(new ServersModel { Enabled = false }, x => x.ID == id, x => new { x.Enabled });
        }
        public bool Delete(string id)
        {
            return Db.Delete(x => x.ID == id);
        }
        public bool Update(ServersDTO model)
        {
            var detail = Db.GetSingle(x => x.ID == model.ID);
            if (detail != null)
            {
                detail.Name = model.Name.IsEmpty() ? detail.Name : model.Name;
                detail.BaseUrl = model.BaseUrl.IsEmpty() ? detail.BaseUrl : model.BaseUrl;
                detail.DefaultHeaders = model.DefaultHeaders.IsEmpty() ? detail.DefaultHeaders : model.DefaultHeaders;
                detail.Order = model.Order;
                return Db.Update(detail, x => x.ID == detail.ID, x => new { x.Name, x.BaseUrl, x.DefaultHeaders, x.Order });
            }
            return false;
        }

        public ServersDTO Get(string id)
        {
            return Db.GetSingle<ServersDTO>(x=>x.ID == id);
        }
    }
}