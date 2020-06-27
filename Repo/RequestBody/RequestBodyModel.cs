using System;
using SqlSugar;

namespace ducky_api_server.Repo.RequestBody
{
    [SugarTable("dat_request_body")]
    public class RequestBodyModel
    {
        public string ID { get; set; }
        [SugarColumn(ColumnName = "request_id")]
        public string RequestID { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
        public DateTime InsertTime { get; set; }
    }
}