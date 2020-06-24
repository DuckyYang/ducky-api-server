using System.Data.Common;
using System;
using System.Collections.Generic;
using ducky_api_server.DTO.Documents;
using ducky_api_server.Model.Documents;
using ducky_api_server.Core;
using ducky_api_server.Extensions;

namespace ducky_api_server.Repo.Documents
{
    public class DocumentsRepo
    {
        private DbContext<DocumentsModel> Db;
        public DocumentsRepo()
        {
            Db = new DbContext<DocumentsModel>();
        }
        /// <summary>
        /// 获取所有的接口文档
        /// </summary>
        /// <returns></returns>
        public List<DocumentsDTO> GetAllDocuments()
        {
            return Db.GetAll<DocumentsDTO>();
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
            var model = new DocumentsModel
            {
                ID = GUID.New,
                Name = name,
                CollectionID = collectionId
            };

            return Db.Insert(model);
        }

        public DocumentsDTO Get(string collectionId)
        {
            return Db.GetSingle<DocumentsDTO>(x => x.ID == collectionId);
        }

        public bool UpdateRequestDocument(string id, DocumentsDTO dto)
        {
            var model = dto.Map<DocumentsModel>();

            return Db.Update(model, x => x.ID == id, x => new { x.Address, x.Method, x.Headers, x.ContentType, x.Parameters, x.Body, x.Json, x.Response });
        }
        public bool RemoveDocument(string id)
        {
            return Db.Delete(x => x.ID == id);
        }
    }
}