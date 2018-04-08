using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace BIWBACK.Controllers
{
    public class reportSaleController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult saleReport()
        {
            return View();
        }
        public IActionResult reportMonth()
        {
            return View();
        }
        public IActionResult reportQuarter() {


            return View();
        }
    }
}
