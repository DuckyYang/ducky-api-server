using System.Data.Common;
using System;
using System.Collections.Generic;
using ducky_api_server.DTO.Request;
using ducky_api_server.Model.Request;
using ducky_api_server.Core;
using ducky_api_server.Extensions;
using System.Linq;

namespace ducky_api_server.Repo.Request
{
    public class RequestRepo
    {
        private DbContext<RequestModel> Db;
        public RequestRepo()
        {
            Db = new DbContext<RequestModel>();
        }
        /// <summary>
        /// 获取所有的接口文档
        /// </summary>
        /// <returns></returns>
        public List<RequestDTO> GetAllDocuments()
        {
            return Db.GetAll().OrderBy(x => x.InsertTime).MapList<RequestDTO>();
        }
        /// <summary>
        /// 向集合中添加请求文档
        /// </summary>
        /// <param name="serverId"></param>
        /// <param name="collectionId"></param>
        /// <param name="name"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public bool AddRequest(string collectionId, string name)
        {
            var model = new RequestModel
            {
                ID = GUID.New,
                Name = name,
                CollectionID = collectionId,
                InsertTime = DateTime.Now
            };

            return Db.Insert(model);
        }

        public RequestDTO Get(string id)
        {
            return Db.GetSingle<RequestDTO>(x => x.ID == id);
        }
        public bool UpdateRequestDocument(string id, RequestDTO dto)
        {
            var model = dto.Map<RequestModel>();

            return Db.Update(model, x => x.ID == id, x => new { x.Address, x.Method, x.ContentType, x.Json, x.Response });
        }
        public bool RemoveDocument(string id)
        {
            return Db.Delete(x => x.ID == id);
        }

        public bool RemoveDocumentByCollectionID(string collectionId)
        {
            return Db.Delete(x => x.CollectionID == collectionId);
        }

        public bool Rename(string id, string name)
        {
            return Db.Update(new RequestModel { Name = name }, x => x.ID == id, x => new { x.Name });
        }
    }
}