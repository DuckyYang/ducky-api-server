namespace ducky_api_server.DTO.Request
{
    public class RequestTreeDTO
    {
        public string ID { get; set; }
        public string PID { get; set; }
        public string Title { get; set; }
        public bool Open { get; set; }
        public bool IsCollection { get; set; }
        public bool IsServer { get; set; }
        public RequestDTO Request { get; set; }

        public string ServerID { get; set; } = "";
        public string CollectionID { get; set; } = "";
    }
}