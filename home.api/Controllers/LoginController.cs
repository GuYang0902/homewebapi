using System.Collections.Generic;
using Chloe;
using Chloe.MySql;
using home.api.Model;
using home.dbhelper;
using Microsoft.AspNetCore.Mvc;

namespace home.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        // POST: api/login
        [HttpPost]
        public API_home_user Post(inputdata IData)
        {

            API_home_user apihu = new API_home_user
            {
                result = new result()
            };

            try
            {
                MySqlContext context = new MySqlContext(new MySqlConnectionFactory(dbhelper.DBConfig.HomeMysqlConn).CreateConnection);
                IQuery<DB_home_user> q = context.Query<DB_home_user>();
                DB_home_user dbhu = q.Where(a => a.if_delete==0 && a.name == IData.user).FirstOrDefault();

                if (dbhu != null && dbhu.password == IData.password)
                {
                    apihu.auth = dbhu.authority;
                    apihu.result.operationResult = true;
                }
                else if (dbhu == null)
                {
                    apihu.auth = "no user";
                    apihu.result.operationResult = false;
                }
                else if (dbhu.password != IData.password)
                {
                    apihu.auth = "password not correct";
                    apihu.result.operationResult = false;
                }
                else
                {
                    apihu.auth = "other reason";
                    apihu.result.operationResult = false;
                }




            }
            catch (System.Exception ex)
            {
                apihu.auth = ex.Message;
                apihu.result.operationResult = false;

            }
            return apihu;

        }



    }


    public class inputdata
    {
        public string user { get; set; }
        public string password { get; set; }    
        public string program { get; set; }

    }
}
