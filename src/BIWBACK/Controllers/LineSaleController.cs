using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BIWBACK.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace BIWBACK.Controllers
{
    public class LineSaleController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult insert_line_sale(string sale_line, string sale_emp ,string sale_date) {


            line_saleModel ls = new line_saleModel();

            ls.emp_sale_ref_emp_id = sale_emp;
            ls.emp_sale_ref_line_id = sale_line;
            ls.emp_sale_create_date = sale_date;

            ls.insert_line_sale();

            return RedirectToAction("typeEmp","Information");
        }
        [HttpPost]
        public IActionResult update_line_sale(string sale_line_edit, string sale_emp_edit, string sale_date_edit, string sale_line_id )
        {


            line_saleModel ls = new line_saleModel();

            ls.emp_sale_ref_emp_id = sale_emp_edit;
            ls.emp_sale_ref_line_id = sale_line_edit;
            ls.emp_sale_create_date = sale_date_edit;
            ls.emp_sale_id = sale_line_id;

            ls.update_line_sale();

            return RedirectToAction("typeEmp", "Information");
        }
        public void del_line_sale(string id) {

            line_saleModel ls = new line_saleModel();
            ls.emp_sale_id = id;
            ls.del_line_sale();

        }
        public string select_line_sale(string id) {

            line_saleModel ls = new line_saleModel();
            ls.select_line_sale("emp_sale_id = '"+id+"'");

            return ls.emp_sale_ref_emp_id+"^"+ls.emp_sale_ref_line_id+"^"+ls.emp_sale_create_date;
        }
    }
}
