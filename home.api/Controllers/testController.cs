using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chloe;
using Chloe.MySql;
using home.api.Model;
using home.dbhelper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AW.ConmonFunc;

namespace home.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class testController : ControllerBase
    {
           
        // GET: api/test
        [HttpGet]
        public List<DB_home_test> Get()
        {
            string connString = dbhelper.DBConfig.HomeMysqlConn;
            MySqlContext context = new MySqlContext(new MySqlConnectionFactory(connString).CreateConnection);

            IQuery<DB_home_test> q = context.Query<DB_home_test>();

            List<DB_home_test> dbhts = q.Where(a => a.no != 4).ToList();

            return dbhts;
        }

        // GET: api/test/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/test
        [HttpPost]
        public List<DB_home_test> Post()
        {
            string connString = dbhelper.DBConfig.HomeMysqlConn;
            MySqlContext context = new MySqlContext(new MySqlConnectionFactory(connString).CreateConnection);

            IQuery<DB_home_test> q = context.Query<DB_home_test>();

            List<DB_home_test> dbhts = q.Where(a => a.no != 4).ToList();

            return dbhts;
        }

        // PUT: api/test/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
