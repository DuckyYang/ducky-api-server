using System;
using SqlSugar;

namespace ducky_api_server.Model.Request
{
    [SugarTable("dat_request")]
    public class RequestModel
    {
        [SugarColumn(IsPrimaryKey=true)]
        public string ID { get; set; }
        [SugarColumn(ColumnName="collection_id")]
        public string CollectionID { get; set; } = "";
        public string Name { get; set; }
        public string Method { get; set; } = "";
        public string Address { get; set; } = "";
        [SugarColumn(ColumnName="content_type")]
        public string ContentType { get; set; } = "";
        public string Json { get; set; } = "";
        public string Response { get; set; } = "";
        public DateTime InsertTime { get; set; }
    }
}