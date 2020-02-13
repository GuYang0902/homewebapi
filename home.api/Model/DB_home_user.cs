using Chloe.Annotations;
using System;

using System.Linq;
using System.Threading.Tasks;

namespace home.api.Model
{
    [Table("home_user")]
    public class DB_home_user
    {
        //[ColumnAttribute("Id", IsPrimaryKey = true)]
        public int index { get; set; }
        public string name { get; set; }
        public string authority { get; set; }
        public int if_delete { get; set; }
        public string password { get; set; }

    }
}
