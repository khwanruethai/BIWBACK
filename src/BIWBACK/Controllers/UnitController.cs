using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BIWBACK.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace BIWBACK.Controllers
{
    public class UnitController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult insert_unit(string unit) {

            unitModel ut = new unitModel();
            ut.unit_name = unit;
            ut.insert_unit();

            return RedirectToAction("unit", "Information");
        }
        public string select_unit(string id) {

            unitModel ut = new unitModel();

            ut.select_unit("unit_id = '"+id+"'");

            return ut.unit_name;
        }
        [HttpPost]
        public IActionResult update_unit(string unit_edit, string unit_id) {

            unitModel ut = new unitModel();

            ut.unit_name = unit_edit;
            ut.unit_id = unit_id;

            ut.update_unit();

            return RedirectToAction("unit", "Information");
        }
        public void del_unit(string id) {

            unitModel ut = new unitModel();

            ut.unit_id = id;
            ut.del_unit();
        }
    }
}
