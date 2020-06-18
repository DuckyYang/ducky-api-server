namespace ducky_api_server.DTO.RoleAuths
{
    public class RoleAuthsDTO
    {
         public string ID { get; set; }
        public string Role { get; set; }
        public string MenuID { get; set; }
        public bool Viewable { get; set; }
        public bool Operable { get; set; }

        /// <summary>
        /// menu name
        /// </summary>
        /// <value></value>
        public string Menu { get; set; }
        public string MenuPath { get; set; }
        public int Order { get; set; }
    }
}