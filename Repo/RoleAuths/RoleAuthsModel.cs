using SqlSugar;

namespace ducky_api_server.Model.RoleAuths
{
    [SugarTable("dat_role_auth")]
    public class RoleAuthsModel
    {
        [SugarColumn(IsPrimaryKey=true)]
        public string ID { get; set; }
        public string Role { get; set; }
        public string MenuID { get; set; }
        public bool Viewable { get; set; }
        public bool Operable { get; set; }
    }
}