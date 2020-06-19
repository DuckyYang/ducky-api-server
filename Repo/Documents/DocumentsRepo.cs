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
        /// 添加一个collection
        /// </summary>
        /// <param name="serverId">服务ID</param>
        /// <param name="name">集合名称</param>
        /// <param name="path">集合路径，eg: Workflow/Task</param>
        /// <returns></returns>
        public bool AddCollection(string serverId, string name, string path)
        {
            var model = new DocumentsModel
            {
                ID = GUID.New,
                Name = name,
                Collection = true,
                ServerID = serverId,
                Path = path
            };
            return Db.Insert(model);
        }
        /// <summary>
        /// 在服务下添加一个请求文档
        /// </summary>
        /// <param name="serverId">服务ID</param>
        /// <param name="name">请求名称</param>
        /// <param name="path"></param>
        /// <returns></returns>
        public bool AddRequestToServer(string serverId, string name, string path)
        {
            var model = new DocumentsModel
            {
                ID = GUID.New,
                Name = name,
                Collection = false,
                ServerID = serverId,
                Path = path
            };

            return Db.Insert(model);
        }
        /// <summary>
        /// 向集合中添加请求文档
        /// </summary>
        /// <param name="serverId"></param>
        /// <param name="collectionId"></param>
        /// <param name="name"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public bool AddRequestToCollection(string serverId, string collectionId, string name, string path)
        {
            var model = new DocumentsModel
            {
                ID = GUID.New,
                Name = name,
                Collection = false,
                CollectionID = collectionId,
                ServerID = serverId,
                Path = path
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