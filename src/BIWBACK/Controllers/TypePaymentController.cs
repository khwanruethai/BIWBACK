using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BIWBACK.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace BIWBACK.Controllers
{
    public class TypePaymentController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult insert_type_payment(string type_pay) {

            typePaymentModel tp = new typePaymentModel();
            tp.tp_name = type_pay;
            tp.insert_type_payment();

            return RedirectToAction("typePayment","Information");
        }
        [HttpPost]
        public IActionResult update_type_payment(string type_pay_edit, string type_pay_id)
        {

            typePaymentModel tp = new typePaymentModel();
            tp.tp_name = type_pay_edit;
            tp.tp_id = type_pay_id;
            tp.update_type_payment();

            return RedirectToAction("typePayment", "Information");
        }
        public string select_type_payment(string id) {

            typePaymentModel tp = new typePaymentModel();
            tp.select_type_payment("tp_id = '"+id+"'");

            return tp.tp_name;
        }
        public void del_type_payment(string id) {

            typePaymentModel tp = new typePaymentModel();
            tp.tp_id = id;
            tp.del_type_payment();
        }
    }
}
