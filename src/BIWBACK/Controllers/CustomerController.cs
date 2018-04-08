using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BIWBACK.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace BIWBACK.Controllers
{
    public class CustomerController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
           

            return View();
        }
        public IActionResult customer() {

            CustomerModel cus = new CustomerModel();
            ViewData["customer"] = cus.list_customer();
            
            return View();
        }
        public IActionResult addCustomer() {

            customerTypeModel ct = new customerTypeModel();
            ViewData["cus_type"] = ct.drop_cus_type_code();

            prefixModel px = new prefixModel();
            ViewData["prefix"] = px.drop_prefix("");

            provinceModel pv = new provinceModel();
            ampuresModel am = new ampuresModel();
            districts dt = new districts();

            ViewData["province"] = pv.drop_province("");
            ViewData["amphur"] = am.dorp_amphur("");
            ViewData["district"] = dt.drop_district("");

            conditionPayModel cd = new conditionPayModel();
            ViewData["condition"] = cd.drop_con_pay("");


            lineModel ln = new lineModel();
            ViewData["line"] = ln.drop_line("");

            line_saleModel ls = new line_saleModel();
            ViewData["line_sale"] = ls.drop_line_sale("");

            return View();
        }
        public IActionResult editcustomer(string cus) {

            ViewData["cus_id"] = cus;

            CustomerModel  ctm = new CustomerModel();
            ctm.select_customer(" cus_id = '"+cus+"'");
            ViewData["cus_code"] = ctm.cus_code;
            ViewData["cus_name"] = ctm.cus_name;
            ViewData["cus_name_contact"] = ctm.cus_name_contact;
            ViewData["cus_trade"] = ctm.cus_trade;
            ViewData["cus_tax"] = ctm.cus_tax;

            customerTypeModel ct = new customerTypeModel();
            ViewData["cus_type"] = ct.drop_cus_type_code(ctm.cus_ref_type_id);

            prefixModel px = new prefixModel();
            ViewData["prefix"] = px.drop_prefix(ctm.cus_ref_prefix_id);
            px.select_prefix("prefix_id = '"+ ctm.cus_ref_prefix_id + "'");
            ViewData["last_name"] = px.prefix_ending;


            CustomerAddressModel ca = new CustomerAddressModel();
            ca.select_address("add_ref_cus_id = '"+cus+"'");
            ViewData["add_num"] = ca.add_num;
            ViewData["add_alley"] = ca.add_alley;
            ViewData["add_road"] = ca.add_road;
            ViewData["add_postcode"] = ca.add_poscode;
            ViewData["add_status"] = ca.add_type_status;
            ViewData["add_branch"] = ca.add_branch;
            ViewData["add_id"] = ca.add_id;

            provinceModel pv = new provinceModel();
            ampuresModel am = new ampuresModel();
            districts dt = new districts();

            ViewData["province"] = pv.drop_province(ca.add_province);
            ViewData["amphur"] = am.dorp_amphur(ca.add_amphur);
            ViewData["district"] = dt.drop_district(ca.add_district);


            CustomerContactModel c_t = new CustomerContactModel();
            c_t.select_contact("ct_ref_cus_id = '"+cus+"'");
            ViewData["ct_tel"] = c_t.ct_tel;
            ViewData["ct_fax"] = c_t.ct_fax;
            ViewData["ct_email"] = c_t.ct_email;
            ViewData["ct_web"] = c_t.ct_web;
            ViewData["ct_id"] = c_t.ct_id;


            CustomerCreditModel crd = new CustomerCreditModel();
            crd.select_credit("credit_ref_cus_id = '"+cus+"'");
            ViewData["credit_money"] = crd.credit_money;
            ViewData["credit_id"] = crd.credit_id;

            conditionPayModel cd = new conditionPayModel();
            ViewData["condition"] = cd.drop_con_pay(crd.credit_ref_condition);


            CustomerLineSaleModel cl = new CustomerLineSaleModel();
            cl.select_cus_line("cs_ref_cus_id = '"+cus+"'");
            ViewData["sale_name"] = cl.cs_sale_name;
            ViewData["sale_id"] = cl.cs_id;

            lineModel ln = new lineModel();
            ViewData["line"] = ln.drop_line(cl.cs_ref_line_id);

            line_saleModel ls = new line_saleModel();
            ViewData["line_sale"] = ls.drop_line_sale("");


            CustomerTransportModel ts = new CustomerTransportModel();
            ts.select_cus_tran("at_ref_cus_id = '"+cus+"'");
            ViewData["name_ts"] = ts.at_customer_name;
            ViewData["num_ts"] = ts.at_num;
            ViewData["alley_ts"] = ts.at_alley;
            ViewData["road_ts"] = ts.at_road;
            ViewData["postcode_ts"] = ts.at_postcode;

            ViewData["province_ts"] = pv.drop_province(ts.at_province);
            ViewData["amphur_ts"] = am.dorp_amphur(ts.at_amphur);
            ViewData["district_ts"] = dt.drop_district(ts.at_district);
            ViewData["ts_id"] = ts.at_id;


            return View();
        }
        public IActionResult viewCustomer(string cus)
        {

            ViewData["cus_id"] = cus;

            CustomerModel ctm = new CustomerModel();
            ctm.select_customer(" cus_id = '" + cus + "'");
            ViewData["cus_code"] = ctm.cus_code;
            ViewData["cus_name"] = ctm.cus_name;
            ViewData["cus_name_contact"] = ctm.cus_name_contact;
            ViewData["cus_trade"] = ctm.cus_trade;
            ViewData["cus_tax"] = ctm.cus_tax;

            customerTypeModel ct = new customerTypeModel();
            ViewData["cus_type"] = ct.drop_cus_type_code(ctm.cus_ref_type_id);

            prefixModel px = new prefixModel();
            ViewData["prefix"] = px.drop_prefix(ctm.cus_ref_prefix_id);
            px.select_prefix("prefix_id = '" + ctm.cus_ref_prefix_id + "'");
            ViewData["last_name"] = px.prefix_ending;


            CustomerAddressModel ca = new CustomerAddressModel();
            ca.select_address("add_ref_cus_id = '" + cus + "'");
            ViewData["add_num"] = ca.add_num;
            ViewData["add_alley"] = ca.add_alley;
            ViewData["add_road"] = ca.add_road;
            ViewData["add_postcode"] = ca.add_poscode;
            ViewData["add_status"] = ca.add_type_status;
            ViewData["add_branch"] = ca.add_branch;
            ViewData["add_id"] = ca.add_id;

            provinceModel pv = new provinceModel();
            ampuresModel am = new ampuresModel();
            districts dt = new districts();

            ViewData["province"] = pv.drop_province(ca.add_province);
            ViewData["amphur"] = am.dorp_amphur(ca.add_amphur);
            ViewData["district"] = dt.drop_district(ca.add_district);


            CustomerContactModel c_t = new CustomerContactModel();
            c_t.select_contact("ct_ref_cus_id = '" + cus + "'");
            ViewData["ct_tel"] = c_t.ct_tel;
            ViewData["ct_fax"] = c_t.ct_fax;
            ViewData["ct_email"] = c_t.ct_email;
            ViewData["ct_web"] = c_t.ct_web;
            ViewData["ct_id"] = c_t.ct_id;


            CustomerCreditModel crd = new CustomerCreditModel();
            crd.select_credit("credit_ref_cus_id = '" + cus + "'");
            ViewData["credit_money"] = crd.credit_money;
            ViewData["credit_id"] = crd.credit_id;

            conditionPayModel cd = new conditionPayModel();
            ViewData["condition"] = cd.drop_con_pay(crd.credit_ref_condition);


            CustomerLineSaleModel cl = new CustomerLineSaleModel();
            cl.select_cus_line("cs_ref_cus_id = '" + cus + "'");
            ViewData["sale_name"] = cl.cs_sale_name;
            ViewData["sale_id"] = cl.cs_id;

            lineModel ln = new lineModel();
            ViewData["line"] = ln.drop_line(cl.cs_ref_line_id);

            line_saleModel ls = new line_saleModel();
            ViewData["line_sale"] = ls.drop_line_sale("");


            CustomerTransportModel ts = new CustomerTransportModel();
            ts.select_cus_tran("at_ref_cus_id = '" + cus + "'");
            ViewData["name_ts"] = ts.at_customer_name;
            ViewData["num_ts"] = ts.at_num;
            ViewData["alley_ts"] = ts.at_alley;
            ViewData["road_ts"] = ts.at_road;
            ViewData["postcode_ts"] = ts.at_postcode;

            ViewData["province_ts"] = pv.drop_province(ts.at_province);
            ViewData["amphur_ts"] = am.dorp_amphur(ts.at_amphur);
            ViewData["district_ts"] = dt.drop_district(ts.at_district);
            ViewData["ts_id"] = ts.at_id;


            return View();
        }
        [HttpPost]
        public IActionResult inert_customer(string cus_type, string cus_prefix, string cus_name, string cus_lastname, string cus_name_contact, string cus_trade, string cus_tax, string add_num, string add_alley, string add_road, string add_province, string add_amphur, string add_distict, string add_postcode, string add_type_status, string add_branch, string ct_tel, string ct_fax, string ct_email, string ct_web, string credit_money, string credit_condition, string line_sale, string name_sale, string at_customer_name, string at_num, string at_alley, string at_road, string at_province, string at_amphur, string at_district, string at_postcode) {

            customerTypeModel c_tp = new customerTypeModel();
            c_tp.type_id = cus_type;
            c_tp.select_cus_type();


            CustomerModel cus = new CustomerModel();

            cus.cus_ref_type_id = c_tp.type_code;
            cus.cus_ref_prefix_id = cus_prefix;
            cus.cus_name = cus_name;
            cus.cus_name_contact = cus_name_contact;
            cus.cus_trade = cus_trade;
            cus.cus_tax = cus_tax;
            cus.insert_customer();

            string cus_id = cus.cus_id;

            CustomerAddressModel add = new CustomerAddressModel();
            add.add_num = add_num;
            add.add_alley = add_alley;
            add.add_road = add_road;
            add.add_province = add_province;
            add.add_amphur = add_amphur;
            add.add_district = add_distict;
            add.add_poscode = add_postcode;
            add.add_type_status = add_type_status;
            add.add_branch = add_branch;
            add.add_ref_cus_id = cus_id;
            add.insert_address();

            CustomerContactModel ct = new CustomerContactModel();
            ct.ct_tel = ct_tel;
            ct.ct_fax = ct_fax;
            ct.ct_email = ct_email;
            ct.ct_web = ct_web;
            ct.ct_ref_cus_id = cus_id;
            ct.insert_contact();

            CustomerCreditModel cd = new CustomerCreditModel();
            cd.credit_money = credit_money;
            cd.credit_ref_condition = credit_condition;
            cd.credit_ref_cus_id = cus_id;
            cd.insert_credit();

            CustomerLineSaleModel ls = new CustomerLineSaleModel();
            ls.cs_ref_line_id = line_sale;
            ls.cs_sale_name = name_sale;
            ls.cs_ref_cus_id = cus_id;
            ls.insert_cus_line();

            CustomerTransportModel tp = new CustomerTransportModel();
            tp.at_customer_name = at_customer_name;
            tp.at_num = at_num;
            tp.at_alley = at_alley;
            tp.at_road = at_road;
            tp.at_province = at_province;
            tp.at_amphur = at_amphur;
            tp.at_district = at_district;
            tp.at_postcode = at_postcode;
            tp.at_ref_cus_id = cus_id;
            tp.insert_cus_tran();


            return RedirectToAction("customer","Information", new { last = cus_id});
        }
        [HttpPost]
        public IActionResult update_customer(string cus_id,string add_id, string ct_id, string credit_id, string sale_id, string ts_id, string cus_type, string cus_prefix, string cus_name, string cus_lastname, string cus_name_contact, string cus_trade, string cus_tax, string add_num, string add_alley, string add_road, string add_province, string add_amphur, string add_distict, string add_postcode, string add_type_status, string add_branch, string ct_tel, string ct_fax, string ct_email, string ct_web, string credit_money, string credit_condition, string line_sale, string name_sale, string at_customer_name, string at_num, string at_alley, string at_road, string at_province, string at_amphur, string at_district, string at_postcode)
        {
            customerTypeModel c_tp = new customerTypeModel();
            c_tp.type_id = cus_type;
            c_tp.select_cus_type();


            CustomerModel cus = new CustomerModel();
            cus.cus_id = cus_id;
            cus.cus_ref_type_id = c_tp.type_code;
            cus.cus_ref_prefix_id = cus_prefix;
            cus.cus_name = cus_name;
            cus.cus_name_contact = cus_name_contact;
            cus.cus_trade = cus_trade;
            cus.cus_tax = cus_tax;
            cus.update_customer();
            
            CustomerAddressModel add = new CustomerAddressModel();
            add.add_id = add_id;
            add.add_num = add_num;
            add.add_alley = add_alley;
            add.add_road = add_road;
            add.add_province = add_province;
            add.add_amphur = add_amphur;
            add.add_district = add_distict;
            add.add_poscode = add_postcode;
            add.add_type_status = add_type_status;
            add.add_branch = add_branch;
            add.add_ref_cus_id = cus_id;
            add.update_address();

            CustomerContactModel ct = new CustomerContactModel();
            ct.ct_id = ct_id;
            ct.ct_tel = ct_tel;
            ct.ct_fax = ct_fax;
            ct.ct_email = ct_email;
            ct.ct_web = ct_web;
            ct.ct_ref_cus_id = cus_id;
            ct.update_contact();

            CustomerCreditModel cd = new CustomerCreditModel();
            cd.credit_id = credit_id;
            cd.credit_money = credit_money;
            cd.credit_ref_condition = credit_condition;
            cd.credit_ref_cus_id = cus_id;
            cd.update_credit();

            CustomerLineSaleModel ls = new CustomerLineSaleModel();
            ls.cs_id = sale_id;
            ls.cs_ref_line_id = line_sale;
            ls.cs_sale_name = name_sale;
            ls.cs_ref_cus_id = cus_id;
            ls.update_cus_line();

            CustomerTransportModel tp = new CustomerTransportModel();
            tp.at_id = ts_id;
            tp.at_customer_name = at_customer_name;
            tp.at_num = at_num;
            tp.at_alley = at_alley;
            tp.at_road = at_road;
            tp.at_province = at_province;
            tp.at_amphur = at_amphur;
            tp.at_district = at_district;
            tp.at_postcode = at_postcode;
            tp.at_ref_cus_id = cus_id;
            tp.update_cus_tran();



            return RedirectToAction("customer", "Customer", new { add = add.add_id});
        }
        public void del_cus(string id) {

            CustomerModel cus = new CustomerModel();
            cus.cus_id = id;
            cus.del_customer();

        }
    }
    
}
