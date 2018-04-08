using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BIWBACK.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace BIWBACK.Controllers
{
    public class LineTranController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult insert_line_tran(string tran_line, string tran_emp, string tran_date)
        {


            line_transport lt = new line_transport();

            lt.emp_tran_ref_emp_id = tran_line;
            lt.emp_tran_ref_line_id = tran_emp;
            lt.emp_tran_create_date = tran_date;

            lt.insert_line_tran();

            return RedirectToAction("typeEmp", "Information");
        }
        [HttpPost]
        public IActionResult update_line_tran(string tran_line_edit, string tran_emp_edit, string tran_date_edit, string tran_line_id)
        {


            line_transport ls = new line_transport();

            ls.emp_tran_ref_emp_id = tran_emp_edit;
            ls.emp_tran_ref_line_id = tran_line_edit;
            ls.emp_tran_create_date = tran_date_edit;
            ls.emp_tran_id = tran_line_id;

            ls.update_line_tran();

            return RedirectToAction("typeEmp", "Information");
        }
        public void del_line_tran(string id)
        {

            line_transport ls = new line_transport();
            ls.emp_tran_id = id;
            ls.del_line_tran();

        }
        public string select_line_tran(string id)
        {
            line_transport ls = new line_transport();
            ls.select_line_tran("emp_tran_id = '" + id + "'");

            return ls.emp_tran_ref_emp_id + "^" + ls.emp_tran_ref_line_id + "^" + ls.emp_tran_create_date;
        }
    }
}
