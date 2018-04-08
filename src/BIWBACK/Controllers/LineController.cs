using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BIWBACK.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace BIWBACK.Controllers
{
    public class LineController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
        public string select_line(string id) {

            lineModel ln = new lineModel();
            ln.select_line("line_id = '"+id+"'");

            return ln.line_code + "^" + ln.line_name;
        }
        public void del_line(string id) {

            lineModel ln = new lineModel();
            ln.line_id = id;
            ln.del_line();
        }
    }
}
