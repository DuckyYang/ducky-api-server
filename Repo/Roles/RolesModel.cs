using SqlSugar;

namespace ducky_api_server.Model.Roles
{
    [SugarTable("dat_role")]
    public class RolesModel
    {
        [SugarColumn(IsPrimaryKey=true)]
        public string role { get; set; }
        public int enabled { get; set; }
    }
}