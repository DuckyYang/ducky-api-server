using SqlSugar;

namespace ducky_api_server.Model.Documents
{
    [SugarTable("dat_documents")]
    public class DocumentsModel
    {
        [SugarColumn(IsPrimaryKey=true)]
        public string ID { get; set; }
        [SugarColumn(ColumnName="server_id")]
        public string ServerID { get; set; }
        public bool Collection { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public string Method { get; set; }
        public string Address { get; set; }
        public string Headers { get; set; }
        [SugarColumn(ColumnName="content_type")]
        public string ContentType { get; set; }
        [SugarColumn(ColumnName="params")]
        public string Parameters { get; set; }
        public string Body { get; set; }
        public string Json { get; set; }
        public string Response { get; set; }
    }
}