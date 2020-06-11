namespace ducky_api_server.Model.Users
{
    public class QueryUserModel:QueryBaseModel
    {
        public string Filter { get; set; }

        public string Role { get; set; }
    }
}