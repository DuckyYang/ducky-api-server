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
        /// <param name="serverId"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool AddCollection(string serverId, string name)
        {
            var model = new DocumentsModel
            {
                ID = GUID.New,
                Name = name,
                Collection = true,
                ServerID = serverId
            };
            return Db.Insert(model);
        }
        /// <summary>
        /// 添加一个请求文档
        /// </summary>
        /// <param name="serverId"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
        public bool AddRequest(string serverId, DocumentsDTO dto)
        {
            var model = dto.Map<DocumentsModel>();
            model.ID = GUID.New;
            model.Collection = false;
            model.ServerID = serverId;

            return Db.Insert(model);
        }
    }
}