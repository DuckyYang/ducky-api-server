using System;

namespace ducky_api_server.DTO.Users
{
    public class UsersDTO
    {
        public string id { get; set; } 
        public string name { get; set; } 
        public string password { get; set; } 
        public string role { get; set; } 
        public string email { get; set; } 
        public string mobile { get; set; } = "";
        public int enabled { get; set; }
        public int locked { get; set; }
        public int errortimes { get; set; }
        public string accesstoken { get; set; }
    }
}