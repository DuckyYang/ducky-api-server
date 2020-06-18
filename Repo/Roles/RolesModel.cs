using SqlSugar;

namespace ducky_api_server.Model.Roles
{
    [SugarTable("dat_role")]
    public class RolesModel
    {
        [SugarColumn(IsPrimaryKey=true)]
        public string Role { get; set; }
        public bool Enabled { get; set; }
    }
}