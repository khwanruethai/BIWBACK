using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BIWBACK.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace BIWBACK.Controllers
{
    public class SuplierController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult agent()
        {
            SuplierModel sp = new SuplierModel();

            ViewData["suplier"] = sp.list_suplier();
            return View();
        }

        public IActionResult addAgent()
        {
            conditionPayModel cd = new conditionPayModel();
            ViewData["credit"] = cd.drop_con_pay("");

            prefixModel px = new prefixModel();
            ViewData["prefix"] = px.drop_prefix("");

            districts dt = new districts();
            ViewData["distict"] = dt.drop_district("");

            ampuresModel am = new ampuresModel();
            ViewData["amphur"] = am.dorp_amphur("");

            provinceModel pv = new provinceModel();
            ViewData["province"] = pv.drop_province("");

            return View();
        }
        [HttpPost]
        public IActionResult insert_suplier(string sup_code, string sup_prefix, string sup_name, string sup_lastname , string sup_name_contact, string sup_num, string sup_road, string sup_district, string sup_amphur, string sup_province, string sup_postcode, string sup_tel, string sup_fax, string sup_trade, string sup_tax, string sup_email, string sup_web , string sup_credit_money, string sup_credit ) {

            SuplierModel sp = new SuplierModel();

            sp.sup_prefix_id = sup_prefix;
            sp.sup_name = sup_name;
            sp.sup_name_contact = sup_name_contact;
            sp.sup_num = sup_num;
            sp.sup_road = sup_road;
            sp.sup_district = sup_district;
            sp.sup_amphur = sup_amphur;
            sp.sup_province = sup_province;
            sp.sup_postcode = sup_postcode;
            sp.sup_tel = sup_tel;
            sp.sup_fax = sup_fax;
            sp.sup_trade = sup_trade;
            sp.sup_tax = sup_tax;
            sp.sup_email = sup_email;
            sp.sup_web = sup_web;
            sp.sup_credit_money = sup_credit_money;
            sp.sup_credit_id = sup_credit;

            sp.create_code();
            
            sp.insert_suplier();

            return RedirectToAction("agent","Suplier");
        }
        [HttpPost]
        public IActionResult update_suplier(string sup_id,string sup_code, string sup_prefix, string sup_name, string sup_lastname, string sup_name_contact, string sup_num, string sup_road, string sup_district, string sup_amphur, string sup_province, string sup_postcode, string sup_tel, string sup_fax, string sup_trade, string sup_tax, string sup_email, string sup_web, string sup_credit_money, string sup_credit)
        {

            SuplierModel sp = new SuplierModel();

            sp.sup_id = sup_id;

            sp.sup_prefix_id = sup_prefix;
            sp.sup_name = sup_name;
            sp.sup_name_contact = sup_name_contact;
            sp.sup_num = sup_num;
            sp.sup_road = sup_road;
            sp.sup_district = sup_district;
            sp.sup_amphur = sup_amphur;
            sp.sup_province = sup_province;
            sp.sup_postcode = sup_postcode;
            sp.sup_tel = sup_tel;
            sp.sup_fax = sup_fax;
            sp.sup_trade = sup_trade;
            sp.sup_tax = sup_tax;
            sp.sup_email = sup_email;
            sp.sup_web = sup_web;
            sp.sup_credit_money = sup_credit_money;
            sp.sup_credit_id = sup_credit;

           
            sp.update_suplier();

            return RedirectToAction("agent", "Suplier");
        }
        public IActionResult viewAgent(string id) {

            SuplierModel sp = new SuplierModel();
            sp.select_suplier("sup_id = '"+id+"'");

            ViewData["sup_code"] = sp.sup_code;
            ViewData["sup_name"] = sp.sup_name;
            ViewData["sup_name_contact"] = sp.sup_name_contact;
            ViewData["sup_tel"] = sp.sup_tel;
            ViewData["sup_fax"] = sp.sup_fax;
            ViewData["sup_email"] = sp.sup_email;
            ViewData["sup_web"] = sp.sup_web;
            ViewData["sup_trade"] = sp.sup_trade;
            ViewData["sup_tax"] = sp.sup_tax;
            ViewData["sup_num"] = sp.sup_num;
            ViewData["sup_road"] = sp.sup_road;
            ViewData["sup_postcode"] = sp.sup_postcode;
            ViewData["sup_credit_money"] = sp.sup_credit_money;
            ViewData["sup_credit"] = sp.credit_name;
            ViewData["sup_district"] = sp.district_name;
            ViewData["sup_amphur"] = sp.amphur_name;
            ViewData["sup_province"] = sp.province_name;
            ViewData["sup_prefix"] = sp.prefix_name;
            ViewData["sup_prefix_end"] = sp.prefix_end;

            return View();
        }
        public IActionResult editAgent(string id)
        {
            SuplierModel sp = new SuplierModel();
            sp.select_suplier("sup_id = '" + id + "'");

            ViewData["sup_id"] = id;
            ViewData["sup_code"] = sp.sup_code;
            ViewData["sup_name"] = sp.sup_name;
            ViewData["sup_name_contact"] = sp.sup_name_contact;
            ViewData["sup_tel"] = sp.sup_tel;
            ViewData["sup_fax"] = sp.sup_fax;
            ViewData["sup_email"] = sp.sup_email;
            ViewData["sup_web"] = sp.sup_web;
            ViewData["sup_trade"] = sp.sup_trade;
            ViewData["sup_tax"] = sp.sup_tax;
            ViewData["sup_num"] = sp.sup_num;
            ViewData["sup_road"] = sp.sup_road;
            ViewData["sup_postcode"] = sp.sup_postcode;
            ViewData["sup_credit_money"] = sp.sup_credit_money;
            ViewData["sup_credit"] = sp.credit_name;
            ViewData["sup_distict"] = sp.district_name;
            ViewData["sup_amphur"] = sp.amphur_name;
            ViewData["sup_province"] = sp.province_name;
            ViewData["sup_prefix"] = sp.prefix_name;
            ViewData["sup_prefix_end"] = sp.prefix_end;

            conditionPayModel cd = new conditionPayModel();
            ViewData["credit"] = cd.drop_con_pay(sp.sup_credit_id);

            prefixModel px = new prefixModel();
            ViewData["prefix"] = px.drop_prefix(sp.sup_prefix_id);

            districts dt = new districts();
            ViewData["distict"] = dt.drop_district(sp.sup_district);

            ampuresModel am = new ampuresModel();
            ViewData["amphur"] = am.dorp_amphur(sp.sup_amphur);

            provinceModel pv = new provinceModel();
            ViewData["province"] = pv.drop_province(sp.sup_province);

            return View();
        }
        public void del_sup(string id) {

            SuplierModel sp = new SuplierModel();
            sp.sup_id = id;
            sp.del_suplier();

        }
    }
}
