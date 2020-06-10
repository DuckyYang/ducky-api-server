using SqlSugar;

namespace ducky_api_server.Models
{
    [SugarTable("dat_user")]
    public class UsersModel
    {
        [SugarColumn(IsPrimaryKey=true)]
        public string id { get; set; } 
        public string name { get; set; } 
        public string password { get; set; } 
        public string role { get; set; } 
        public string email { get; set; } 
        public string mobile { get; set; } 
        public string inserttime { get; set; } 
        public string enabled { get; set; } 
        public string locked { get; set; } 
    }
}