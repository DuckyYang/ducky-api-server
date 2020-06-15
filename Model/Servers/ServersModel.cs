using SqlSugar;

namespace ducky_api_server.Model.Servers
{
    [SugarTable("dat_servers")]
    public class ServersModel
    {
        [SugarColumn(IsPrimaryKey=true)]
        public string id { get; set; }
        public string name { get; set; }
        public string baseurl { get; set; }
        public string default_headers { get; set; }
        public int enabled { get; set; }
        public int order { get; set; }
    }
}