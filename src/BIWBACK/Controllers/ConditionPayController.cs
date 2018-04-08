using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BIWBACK.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace BIWBACK.Controllers
{
    public class ConditionPayController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult insert_con_pay(string con_name, string con_pay, string con_num, string con_type) {


            conditionPayModel cp = new conditionPayModel();
            cp.cdt_name = con_name;
            cp.cdt_ref_typ_pay = con_pay;
            cp.cdt_num = con_num;
            cp.cdt_type = con_type;

            cp.insert_con_pay();

            return RedirectToAction("payment","Information");
        }
        [HttpPost]
        public IActionResult update_con_pay(string con_name_edit, string con_pay_edit, string con_num_edit, string con_type_edit, string con_id)
        {


            conditionPayModel cp = new conditionPayModel();
            cp.cdt_name = con_name_edit;
            cp.cdt_ref_typ_pay = con_pay_edit;
            cp.cdt_num = con_num_edit;
            cp.cdt_type = con_type_edit;
            cp.cdt_id = con_id;
            cp.update_con_pay();

            return RedirectToAction("payment", "Information");
        }
        public string select_con_type(string id) {

            conditionPayModel cp = new conditionPayModel();
            cp.select_con_pay("cdt_id = '"+id+"'");

            return cp.cdt_name + "^" + cp.cdt_ref_typ_pay + "^" + cp.cdt_num + "^" + cp.cdt_type;
        }
        public void del_con_pay(string id) {

            conditionPayModel cp = new conditionPayModel();
            cp.cdt_id = id;
            cp.del_con_pay();
        }
    }
}
