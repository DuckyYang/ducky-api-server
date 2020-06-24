using SqlSugar;
using ducky_api_server.DTO.Collections;
using ducky_api_server.Extensions;
using ducky_api_server.Core;
using System.Collections.Generic;
using System.Linq;
using System;

namespace ducky_api_server.Repo.Collections
{
    public class CollectionsRepo
    {
        private DbContext<CollectionsModel> Db;
        public CollectionsRepo()
        {
            Db = new DbContext<CollectionsModel>();
        }
        public bool Add(string serverId,string name)
        {
            var model = new CollectionsModel
            {
                ID = GUID.New,
                ServerID = serverId,
                Name = name,
                InsertTime = DateTime.Now
            };
            return Db.Insert(model);
        }

        public CollectionsDTO Get(string collectionId)
        {
            return Db.GetSingle<CollectionsDTO>(x=>x.ID == collectionId);
        }

        public bool Rename(string id,string name)
        {
            var old = Db.GetSingle(x=>x.ID == id);
            if (!old.IsNull())
            {
                old.Name = name ?? old.Name;
                return Db.Update(old,x=>x.ID == id,x=>new{x.Name});
            }
            return false;
        }
        public List<CollectionsDTO> GetAll()
        {
            return Db.GetAll().OrderBy(x=>x.InsertTime).MapList<CollectionsDTO>();
        }
    }
}