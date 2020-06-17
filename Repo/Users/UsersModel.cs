using System;
using SqlSugar;

namespace ducky_api_server.Model.Users
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
        public string mobile { get; set; } = "";
        public DateTime inserttime { get; set; } 
        public int enabled { get; set; } = 1;
        public int locked { get; set; } = 0;
        public string accesstoken { get; set; } = "";
        public DateTime expired { get; set; }
        public int errortimes { get; set; }
    }
}