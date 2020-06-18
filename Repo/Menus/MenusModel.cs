using SqlSugar;

namespace ducky_api_server.Model.Menus
{
    [SugarTable("dat_menu")]
    public class MenusModel
    {
        [SugarColumn(IsPrimaryKey=true)]
        public string ID { get; set; }
        public string Menu { get; set; }
        public string Path { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        public bool Enabled { get; set; }
        public int Order { get; set; }
    }
}