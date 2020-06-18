using System;
using SqlSugar;

namespace ducky_api_server.Model.Users
{
    [SugarTable("dat_user")]
    public class UsersModel
    {
        [SugarColumn(IsPrimaryKey=true)]
        public string ID { get; set; } 
        public string Name { get; set; } 
        public string Password { get; set; } 
        public string Role { get; set; } 
        public string Email { get; set; } 
        public string Mobile { get; set; } = "";
        public DateTime InsertTime { get; set; } 
        public bool Enabled { get; set; } = true;
        public bool Locked { get; set; } = false;
        public string Accesstoken { get; set; } = "";
        public DateTime Expired { get; set; }
        public int ErrorTimes { get; set; }
    }
}