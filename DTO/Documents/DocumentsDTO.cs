namespace ducky_api_server.DTO.Documents
{
    public class DocumentsDTO
    {
        public string ID { get; set; }
        public string CollectionID { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public string Method { get; set; }
        public string Address { get; set; }
        public string Headers { get; set; }
        public string ContentType { get; set; }
        public string Parameters { get; set; }
        public string Body { get; set; }
        public string Json { get; set; }
        public string Response { get; set; }
    }
}