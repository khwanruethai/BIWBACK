using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace BIWBACK.Controllers
{
    public class SaleController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Quotation()
        {
            return View();
        }
        public IActionResult production()
        {
            return View();
        }
        public IActionResult transport_search()
        {
            return View();
        }
        public IActionResult transport_add()
        {
            return View();
        }
    }
}
