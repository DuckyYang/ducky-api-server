using System.Collections.Generic;

namespace ducky_api_server.DTO.Request
{
    public class RequestDTO
    {
        public string ID { get; set; }
        public string CollectionID { get; set; }
        public string Name { get; set; }
        public string Method { get; set; }
        public string Address { get; set; }
        public List<RequestHeadersDTO> Headers { get; set; } = new List<RequestHeadersDTO>();
        public string ContentType { get; set; }
        public List<RequestParametersDTO> Parameters { get; set; } = new List<RequestParametersDTO>();
        public List<RequestBodyDTO> Body { get; set; } = new List<RequestBodyDTO>();
        public string Json { get; set; }
        public string Response { get; set; }

        /// <summary>
        /// 当前文档所属路径，like： [Workflow,Task,Create]
        /// </summary>
        /// <value></value>
        public List<string> Path { get; set; } = new List<string>();


    }
}