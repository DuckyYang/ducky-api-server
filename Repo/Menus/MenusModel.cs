using SqlSugar;

namespace ducky_api_server.Model.Menus
{
    [SugarTable("dat_menu")]
    public class MenusModel
    {
        [SugarColumn(IsPrimaryKey=true)]
        public string id { get; set; }
        public string menu { get; set; }
        public string path { get; set; }
        public string name { get; set; }
        public string icon { get; set; }
        public int enabled { get; set; }
        public int order { get; set; }
    }
}