using SqlSugar;

namespace ducky_api_server.Model.UserServers
{
    [SugarTable("dat_user_servers")]
    public class UserServersModel
    {
        [SugarColumn(IsPrimaryKey=true)]
        public string ID { get; set; }
        public string UserID { get; set; }
        [SugarColumn(ColumnName="server_id")]
        public string ServerID { get; set; }
    }
}