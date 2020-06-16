using SqlSugar;

namespace ducky_api_server.Model.RolesAuth
{
    [SugarTable("dat_role_auth")]
    public class RolesAuthModel
    {
        [SugarColumn(IsPrimaryKey=true)]
        public string id { get; set; }
        public string role { get; set; }
        public string menuid { get; set; }
        public int view { get; set; }
        public int operate { get; set; }

        /// <summary>
        /// menu name
        /// </summary>
        /// <value></value>
        [SugarColumn(IsIgnore=true)]
        public string menu { get; set; }
        [SugarColumn(IsIgnore=true)]
        public string menu_path { get; set; }
        [SugarColumn(IsIgnore=true)]
        public int order { get; set; }
    }
}