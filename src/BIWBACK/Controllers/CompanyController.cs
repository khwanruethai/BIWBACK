using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BIWBACK.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace BIWBACK.Controllers
{
    public class CompanyController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            CompanyModel cp = new CompanyModel();
            ampuresModel ap = new ampuresModel();
            districts dt = new districts();
            provinceModel pv = new provinceModel();

            cp.select_comp();
            ViewData["comp_address"] = cp.comp_address;
            ViewData["comp_amphur"] = ap.dorp_amphur(cp.comp_amphur);
            ViewData["comp_create_admin_id"] = cp.comp_create_admin_id;
            ViewData["comp_create_date"] = cp.comp_create_date;
            ViewData["comp_district"] = dt.drop_district(cp.comp_district);
            ViewData["comp_edit_date"] = cp.comp_edit_date;
            ViewData["comp_email"] = cp.comp_email;
            ViewData["comp_fax"] = cp.comp_fax;
            ViewData["comp_name"] = cp.comp_name;
            ViewData["comp_name_en"] = cp.comp_name_en;
            ViewData["comp_postcode"] = cp.comp_postcode;
            ViewData["comp_province"] = pv.drop_province(cp.comp_province);
            ViewData["comp_road"] = cp.comp_road;
            ViewData["comp_tax"] = cp.comp_tax;
            ViewData["comp_tel"] = cp.comp_tel;
            ViewData["comp_trade"] = cp.comp_trade;
            ViewData["comp_web"] = cp.comp_web;
            ViewData["comp_edit_admin_id"] = cp.comp_edit_admin_id;


            return View();
        }
        [HttpPost]
        public IActionResult update_company(string comp_name_th, string  comp_name_en,string  comp_address, string comp_road, string comp_district, string comp_amphur, string comp_province, string comp_postcode, string comp_tel, string comp_fax, string comp_trade, string comp_tax, string comp_email, string comp_web) {

            CompanyModel cp = new CompanyModel();

            cp.comp_address = comp_address;
            cp.comp_amphur = comp_amphur;
            cp.comp_create_admin_id = "1";
            cp.comp_create_date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            cp.comp_district = comp_district;
            cp.comp_edit_date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            cp.comp_email = comp_email;
            cp.comp_fax = comp_fax;
            cp.comp_name = comp_name_th;
            cp.comp_name_en = comp_name_en;
            cp.comp_postcode = comp_postcode;
            cp.comp_province = comp_province;
            cp.comp_road = comp_road;
            cp.comp_tax = comp_tax;
            cp.comp_tel = comp_tel;
            cp.comp_trade = comp_trade;
            cp.comp_web = comp_web;
            cp.comp_edit_admin_id = "1";

            cp.update_comp();


            return RedirectToAction("Index","Company");
        }
    }
}
