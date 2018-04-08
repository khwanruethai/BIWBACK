using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BIWBACK.Models;

namespace BIWBACK.Models
{
    public class test
    {
        DatabaseClass db = new DatabaseClass();

        public List<object> test1() {

            List<object> obj = new List<object>();

            List<object> col = new List<object>();
            col.Add(new { a = "aa"});
            col.Add(new { b = "bb"});
            
          

            return obj;
        }
    }
}
