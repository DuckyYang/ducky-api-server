using System;
using ducky_api_server.Extensions;

namespace ducky_api_server.DTO.Users
{
    public class UsersDTO
    {
        public string ID { get; set; } 
        public string Name { get; set; } 
        [IgnoreMap]
        public string Password { get; set; } 
        public string Role { get; set; } 
        public string Email { get; set; } 
        public string Mobile { get; set; } = "";
        public bool Enabled { get; set; }
        public bool Locked { get; set; }
        public int ErrorTimes { get; set; }
        public string Accesstoken { get; set; }
    }
}