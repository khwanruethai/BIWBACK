using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace BIWBACK.Controllers
{
    public class StockController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult add_stock()
        {
            return View();
        }
        public IActionResult addStock1()
        {
            return View();
        }
        public IActionResult getStock()
        {
            return View();
        }
        public IActionResult extract()
        {
            return View();
        }
        public IActionResult addExtract()
        {
            return View();
        }
        public IActionResult turn()
        {
            return View();
        }
        public IActionResult addTurn()
        {
            return View();
        }
        public IActionResult repairStock()
        {
            return View();
        }
        public IActionResult addRepair()
        {
            return View();
        }
    }
}
