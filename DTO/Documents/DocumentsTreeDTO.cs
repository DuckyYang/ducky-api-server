namespace ducky_api_server.DTO.Documents
{
    public class DocumentsTreeDTO
    {
        public string ID { get; set; }
        public string PID { get; set; }
        public string Title { get; set; }
        public bool Open { get; set; }
        public bool IsCollection { get; set; }
        public bool IsServer { get; set; }
        public DocumentsDTO Document { get; set; }

        public string ServerID { get; set; }
        public string CollectionID { get; set; }
    }
}