using System;
using System.Collections.Generic;
using System.Linq;
using ducky_api_server.Core;
using ducky_api_server.DTO.Request;
using ducky_api_server.Extensions;


namespace ducky_api_server.Repo.RequestHeaders
{
    public class RequestHeadersRepo
    {
        private DbContext<RequestHeadersModel> Db = new DbContext<RequestHeadersModel>();

        public bool Add(string requestId, List<RequestHeadersDTO> list)
        {
            var models = list.Each(x =>
            {
                var model = x.Map<RequestHeadersModel>();
                model.ID = GUID.New;
                model.InsertTime = DateTime.Now;
                model.RequestID = requestId;
                return model;
            });
            return Db.InsertAll(models);
        }
        public bool Remove(string requestId)
        {
            return Db.Delete(x => x.RequestID == requestId);
        }
        public List<RequestHeadersDTO> GetAll()
        {
            return Db.GetAll().OrderBy(x => x.InsertTime).MapList<RequestHeadersDTO>();
        }
        public List<RequestHeadersDTO> Get(string requestId)
        {
            return Db.GetAll<RequestHeadersDTO>(x => x.RequestID == requestId);
        }
    }
}
