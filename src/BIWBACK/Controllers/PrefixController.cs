using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BIWBACK.Models;
// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace BIWBACK.Controllers
{
    public class PrefixController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult insert_prefix(string prefix_name, string prefix_ending)
        {

            prefixModel px = new prefixModel();
            px.prefix_name = prefix_name;
            px.prefix_ending = prefix_ending;
            px.insert_prefix();

            return RedirectToAction("prefix", "Information");
        }
        public string select_prefix(string id)
        {
            prefixModel px = new prefixModel();

            px.select_prefix("prefix_id = '" + id + "'");

            return px.prefix_name + "^" + px.prefix_ending;
        }
        [HttpPost]
        public IActionResult update_prefix(string prefix_name_edit, string prefix_ending_edit, string prefix_id)
        {

            prefixModel px = new prefixModel();
            px.prefix_name = prefix_name_edit;
            px.prefix_ending = prefix_ending_edit;
            px.prefix_id = prefix_id;
            px.update_prefix();

            return RedirectToAction("prefix", "Information");
        }
        public void del_prefix(string id)
        {
            prefixModel px = new prefixModel();
            px.prefix_id = id;
            px.del_prefix();
        }
        public string prefix_end(string id) {

            prefixModel px = new prefixModel();

            px.select_prefix("prefix_id = '" + id + "'");

            return px.prefix_ending;

        }
    }
}
