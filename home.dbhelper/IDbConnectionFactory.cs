using System.Data;

namespace home.dbhelper
{
    interface IDbConnectionFactory
    {
        public abstract IDbConnection CreateConnection();
    }
}
