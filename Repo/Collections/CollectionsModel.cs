using System;
using SqlSugar;

namespace ducky_api_server.Repo.Collections
{
    [SugarTable("dat_collection")]
    public class CollectionsModel
    {
        [SugarColumn(IsPrimaryKey = true)]
        public string ID { get; set; }
        public string Name { get; set; }
        public DateTime InsertTime { get; set; }
        [SugarColumn(ColumnName = "server_id")]
        public string ServerID { get; set; }
    }
}