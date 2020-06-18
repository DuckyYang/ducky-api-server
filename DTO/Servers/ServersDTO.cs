
namespace ducky_api_server.DTO.Servers
{
    public class ServersDTO
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string BaseUrl { get; set; }
        public string DefaultHeaders { get; set; }
        public int Enabled { get; set; }
        public int Order { get; set; }
    }
}