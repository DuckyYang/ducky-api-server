using System;
using System.Collections.Generic;
using System.Linq;
using ducky_api_server.Core;
using ducky_api_server.DTO.Request;
using ducky_api_server.Extensions;

namespace ducky_api_server.Repo.RequestBody
{
    public class RequestBodyRepo
    {
        private DbContext<RequestBodyModel> Db = new DbContext<RequestBodyModel>();

        public bool Add(string requestId, List<RequestBodyDTO> list)
        {
            var models = list.Each(x =>
            {
                var model = x.Map<RequestBodyModel>();
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
        public List<RequestBodyDTO> GetAll()
        {
            return Db.GetAll().OrderBy(x => x.InsertTime).MapList<RequestBodyDTO>();
        }
    }
}