using SqlSugar;

namespace ducky_api_server.core
{
    public class DbFactory
    {
        public static SqlSugarClient OpenDb()
        {
            SqlSugarClient db = new SqlSugarClient(new ConnectionConfig()
            {
                ConnectionString = "Server=.xxxxx",
                DbType = DbType.SqlServer,
                IsAutoCloseConnection = true,
                InitKeyType = InitKeyType.Attribute
            });
            //Print sql
            db.Aop.OnLogExecuting = (sql, pars) =>
            {
                // Console.WriteLine(sql + "\r\n" + db.Utilities.SerializeObject(pars.ToDictionary(it => it.ParameterName, it => it.Value)));
                // Console.WriteLine();
            };
            return db;
        }
    }
}