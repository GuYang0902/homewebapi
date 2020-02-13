using MySql.Data.MySqlClient;
using System.Data;


namespace home.dbhelper
{
    public class MySqlConnectionFactory : IDbConnectionFactory
    {
        string _connString = null;
        public MySqlConnectionFactory(string connString)
        {
            this._connString = connString;
        }


        public IDbConnection CreateConnection()
        {
            IDbConnection conn = new MySqlConnection(this._connString);
            /*如果有必要需要包装一下驱动的 MySqlConnection*/
            //conn = new Chloe.MySql.ChloeMySqlConnection(conn); 
            return conn;

        }
    }
}
