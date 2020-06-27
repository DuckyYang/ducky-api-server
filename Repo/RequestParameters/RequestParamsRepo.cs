using System;
using System.Collections.Generic;
using System.Linq;
using ducky_api_server.Core;
using ducky_api_server.DTO.Request;
using ducky_api_server.Extensions;

namespace ducky_api_server.Repo.RequestParameters
{
    public class RequestParamsRepo
    {
        private DbContext<RequestParamsModel> Db = new DbContext<RequestParamsModel>();

        public bool Add(string requestId, List<RequestParametersDTO> list)
        {
            var models = list.Each(x =>
            {
                var model = x.Map<RequestParamsModel>();
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
        public List<RequestParametersDTO> GetAll()
        {
            return Db.GetAll().OrderBy(x => x.InsertTime).MapList<RequestParametersDTO>();
        }
    }
}
