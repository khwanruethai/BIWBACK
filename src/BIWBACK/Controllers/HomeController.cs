using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BIWBACK.Models;

namespace BIWBACK.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            //test ts = new test();

            //ViewData["test"] = ts.test1();

            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
        public IActionResult test()
        {
            return View();
        }
        public JsonResult testJson() {

            test ts = new test();

            var obj = ts.test1();


            return Json(obj);
        }
    }
}
