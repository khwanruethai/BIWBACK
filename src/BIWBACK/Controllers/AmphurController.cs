using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BIWBACK.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace BIWBACK.Controllers
{
    public class AmphurController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
        public string option_amphur(string id) {

            ampuresModel ap = new ampuresModel();


            return ap.option_amphur(id);
        }
    }
}
