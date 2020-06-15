using SqlSugar;

namespace ducky_api_server.Model.UserServers
{
    [SugarTable("dat_user_servers")]
    public class UserServersModel
    {
        [SugarColumn(IsPrimaryKey=true)]
        public string id { get; set; }
        public string userid { get; set; }
        public string server_id { get; set; }
    }
}