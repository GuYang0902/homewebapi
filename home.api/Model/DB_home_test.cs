using Chloe.Annotations;
using System;

using System.Linq;
using System.Threading.Tasks;

namespace home.api.Model
{
    [Table("home_test")]
    public class DB_home_test
    {
        //[ColumnAttribute("Id", IsPrimaryKey = true)]
        public int no { get; set; }
        public string name { get; set; }
        public string position { get; set; }
      
        [NotMappedAttribute]
        public string NotMappedProperty { get; set; }

    }
}
