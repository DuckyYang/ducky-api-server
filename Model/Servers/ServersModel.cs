using SqlSugar;

namespace ducky_api_server.Model.Servers
{
    [SugarTable("dat_servers")]
    public class ServersModel
    {
        [SugarColumn(IsPrimaryKey=true)]
        public string ID { get; set; }
        public string Name { get; set; }
        [SugarColumn(ColumnName="base_url")]
        public string BaseUrl { get; set; }
        [SugarColumn(ColumnName="default_headers")]
        public string DefaultHeaders { get; set; }
        public int Enabled { get; set; }
        public int Order { get; set; }
    }
}