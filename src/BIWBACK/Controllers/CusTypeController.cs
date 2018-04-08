using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BIWBACK.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace BIWBACK.Controllers
{
    public class CusTypeController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult insert_cus_type(string type_code, string type_name, string type_vat, string type_pay, string type_discount) {

            customerTypeModel ct = new customerTypeModel();

            ct.type_code = type_code;
            ct.type_name = type_name;
            ct.type_vat = type_vat;
            ct.type_pay = type_pay;
            ct.type_discount = type_discount;

            ct.insert_cus_type();

            return RedirectToAction("customerType","Information");
        }
        [HttpPost]
        public IActionResult update_cus_type(string type_code_edit, string type_name_edit, string type_vat_edit, string type_pay_edit, string type_discount_edit, string type_id) {

            customerTypeModel ct = new customerTypeModel();

            ct.type_code = type_code_edit;
            ct.type_name = type_name_edit;
            ct.type_vat = type_vat_edit;
            ct.type_pay = type_pay_edit;
            ct.type_discount = type_discount_edit;
            ct.type_id = type_id;

            ct.update_cus_type();

            return RedirectToAction("customerType", "Information");
        }
        public string select_cus_type(string id) {

            customerTypeModel ct = new customerTypeModel();

            ct.select_cus_type("type_id = '"+id+"'");

            return ct.type_code + "^" + ct.type_name + "^" + ct.type_vat + "^" + ct.type_pay + "^" + ct.type_discount;
        }
        public void del_cus_type(string id) {

            customerTypeModel ct = new customerTypeModel();
            ct.type_id = id;
            ct.del_cus_type();
        }
    }
}
