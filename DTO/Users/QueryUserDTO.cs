namespace ducky_api_server.DTO.Users
{
    public class QueryUserDTO:QueryBaseDTO
    {
        public string Filter { get; set; }

        public string Role { get; set; }
    }
}