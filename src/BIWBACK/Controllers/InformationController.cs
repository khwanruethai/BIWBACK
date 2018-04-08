using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BIWBACK.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace BIWBACK.Controllers
{
    public class InformationController : Controller
    {
        // GET: /<controller>/
        
        public IActionResult Index()
        {  
            return View();
        }
        
        public IActionResult customerType()
        {
            customerTypeModel ct = new customerTypeModel();
            ct.selectCode();
            ViewData["type_code"] = ct.type_code;
            ViewData["cus_type"] = ct.list_cus_type();
            

            return View();
        }
        public IActionResult typeMaterial()
        {
            typeMaterialModel tm = new typeMaterialModel();
            ViewData["type_material"] = tm.list_type_material();


            return View();
        }
        [HttpPost]
        public IActionResult insert_tm(string tm_name) {

            typeMaterialModel tm = new typeMaterialModel();
            tm.tm_name = tm_name;
            tm.insert_type_material();

            return RedirectToAction("typeMaterial","Information");
        }
        [HttpPost]
        public IActionResult update_tm(string tm_name_edit, string tm_id)
        {

            typeMaterialModel tm = new typeMaterialModel();
            tm.tm_id = tm_id;
            tm.tm_name = tm_name_edit;
            tm.update_type_material();

            return RedirectToAction("typeMaterial", "Information");
        }
        public string select_tm(string id) {

            typeMaterialModel tm = new typeMaterialModel();
            tm.select_type_material("tm_id = '"+id+"'");


            return tm.tm_name;
        }
        public void del_tm(string id) {

            typeMaterialModel tm = new typeMaterialModel();
            tm.tm_id = id;
            tm.del_type_material();
        }
        public IActionResult groupMaterial()
        {
            groupMaterialModel gm = new groupMaterialModel();
            ViewData["gm"] = gm.list_gm();
            gm.create_code();
            ViewData["gm_code"] = gm.gm_code;

            typeMaterialModel tm = new typeMaterialModel();
            ViewData["tm"] = tm.drop_type_material("");

            unitModel ut = new unitModel();
            ViewData["unit"] = ut.drop_unit("");


            return View();
        }
        [HttpPost]
        public IActionResult insert_gm(string gm_name, string gm_type, string gm_unit) {

            groupMaterialModel gm = new groupMaterialModel();
            gm.create_code();
            gm.gm_name = gm_name;
            gm.gm_ref_type_material = gm_type;
            gm.gm_ref_unit = gm_unit;
            gm.insert_gm();
            
            return RedirectToAction("groupMaterial","Information");
        }
        [HttpPost]
        public IActionResult update_gm(string gm_name_edit, string gm_type_edit, string gm_unit_edit, string gm_id)
        {

            groupMaterialModel gm = new groupMaterialModel();
            gm.gm_id = gm_id;
            gm.gm_name = gm_name_edit;
            gm.gm_ref_type_material = gm_type_edit;
            gm.gm_ref_unit = gm_unit_edit;
            gm.update_gm();

            return RedirectToAction("groupMaterial", "Information");
        }
        public string select_gm(string id) {

            groupMaterialModel gm = new groupMaterialModel();
            gm.select_gm("gm_id = '"+id+"'");

            return gm.gm_code+"^"+gm.gm_name+"^"+gm.gm_ref_type_material+"^"+gm.gm_ref_unit;
        }
        public void del_gm(string id) {

            groupMaterialModel gm = new groupMaterialModel();
            gm.gm_id = id;
            gm.del_gm();
        }
      
        public IActionResult shelf()
        {
            shelfModel sh = new shelfModel();
            sh.create_code();

            ViewData["sh_code"] = sh.shelf_code;
            ViewData["shelf"] = sh.list_shelf();

            StoreModel st = new StoreModel();
            ViewData["store"] = st.drop_store("");

            return View();
        }
        [HttpPost]
        public IActionResult insert_shelf(string sh_store, string sh_name) {

            shelfModel sh = new shelfModel();
            sh.create_code();
            sh.shelf_name = sh_name;
            sh.shelf_ref_store = sh_store;
            sh.insert_shelf();

            return RedirectToAction("shelf","Information");
        }
        [HttpPost]
        public IActionResult update_shelf(string sh_store_edit, string sh_name_edit, string sh_id)
        {

            shelfModel sh = new shelfModel();
            sh.shelf_id = sh_id;
            sh.shelf_name = sh_name_edit;
            sh.shelf_ref_store = sh_store_edit;
            sh.update_shelf();

            return RedirectToAction("shelf", "Information");
        }
        public string select_shelf(string id) {

            shelfModel sh = new shelfModel();
            sh.select_shelf("shelf_id = '"+id+"'");

            return sh.shelf_code + "^" + sh.shelf_ref_store + "^" + sh.shelf_name;
        }
        public void del_shelf(string id) {

            shelfModel sh = new shelfModel();
            sh.shelf_id = id;
            sh.del_shelf();
        }
        public IActionResult warehouse()
        {
            StoreModel st = new StoreModel();
            st.create_code();
            ViewData["st_code"] = st.store_code;
            ViewData["store"] = st.list_store();
            return View();
        }
        [HttpPost]
        public IActionResult insert_store(string st_name) {

            StoreModel st = new StoreModel();
            st.create_code();
            st.store_name = st_name;
            st.insert_store();

            return RedirectToAction("warehouse","Information");
        }
        [HttpPost]
        public IActionResult update_store(string st_name_edit, string st_id)
        {

            StoreModel st = new StoreModel();
            st.store_id = st_id;
            st.store_name = st_name_edit;
            st.update_store();

            return RedirectToAction("warehouse", "Information");
        }
        public string select_store(string id) {

            StoreModel st = new StoreModel();
            st.select_store("store_id = '"+id+"'");

            return st.store_code + "^" +st.store_name;
        }
        public void del_store(string id) {

            StoreModel st = new StoreModel();
            st.store_id = id;
            st.del_store();

        }
       
      
        public IActionResult modelProduct()
        {
            modelProductModel mp = new modelProductModel();
            ViewData["mp"] = mp.list_mp(); ;


            return View();
        }
        [HttpPost]
        public IActionResult insert_mp(string mp_name) {

            modelProductModel mp = new modelProductModel();
            mp.mp_name = mp_name;
            mp.insert_mp();
            
            return RedirectToAction("modelProduct","Information");
        }
        [HttpPost]
        public IActionResult updateMP(string mp_name_edit, string mp_id)
        {
            modelProductModel mp = new modelProductModel();
            mp.mp_id = mp_id;
            mp.mp_name = mp_name_edit;
            mp.update_mp();

            return RedirectToAction("modelProduct", "Information");
        }
        public string select_mp(string id) {

            modelProductModel mp = new modelProductModel();
            mp.select_mp("mp_id = '"+id+"'");

            return mp.mp_name;
        }
        public void del_mp(string id) {

            modelProductModel mp = new modelProductModel();
            mp.mp_id = id;
            mp.del_mp();

        }
      
     
        public IActionResult payment()
        {

            typePaymentModel tp = new typePaymentModel();
            ViewData["type_payment"] = tp.drop_type_payment("");

            conditionPayModel cp = new conditionPayModel();
            ViewData["conditionPay"] = cp.list_con_pay();

            return View();
        }
        public IActionResult position()
        {
            positionModel ps = new positionModel();
            ViewData["position"] = ps.list_position();

            return View();
        }
        [HttpPost]
        public IActionResult insert_position(string ps_code, string ps_name) {

            positionModel ps = new positionModel();
            ps.ps_code = ps_code;
            ps.ps_name = ps_name;

            ps.insert_position();

            return RedirectToAction("position", "Information");
        }
        [HttpPost]
        public IActionResult edit_position(string ps_code_edit, string ps_name_edit, string ps_id) {

            positionModel ps = new positionModel();
            ps.ps_code = ps_code_edit;
            ps.ps_name = ps_name_edit;
            ps.ps_id = ps_id;

            ps.update_position();


            return RedirectToAction("position", "Information");
        }
        public string view_position(string id) {

            positionModel ps = new positionModel();
            ps.select_position("ps_id = '" + id + "'");

            return ps.ps_code + "^" + ps.ps_name;
        }
        public void del_positon(string id) {

            positionModel ps = new positionModel();
            ps.ps_id = id;
            ps.del_position();
        }
        public IActionResult unit()
        {
            unitModel ut = new unitModel();

            ViewData["unit"] = ut.list_unit();

            return View();
        }
        public IActionResult prefix()
        {
            prefixModel px = new prefixModel();
            ViewData["prefix"] = px.list_prefix();

            return View();
        }
        public IActionResult province()
        {
            provinceModel pv = new provinceModel();

            ViewData["province"] = pv.list_province();

            return View();
        }
        public IActionResult line()
        {
            lineModel ln = new lineModel();
            ViewData["line"] = ln.list_line();

            return View();
        }
        [HttpPost]
        public IActionResult insert_line(string line_code, string line_name) {

            lineModel ln = new lineModel();
            ln.line_code = line_code;
            ln.line_name = line_name;
            ln.insert_line();

            return RedirectToAction("line", "Information");
        }
        [HttpPost]
        public IActionResult update_line(string line_code_edit, string line_name_edit, string line_id) {

            lineModel ln = new lineModel();
            ln.line_id = line_id;
            ln.line_name = line_name_edit;
            ln.line_code = line_code_edit;
            ln.update_line();

            return RedirectToAction("line","Information");
        }
        public IActionResult typePayment()
        {
            typePaymentModel tp = new typePaymentModel();
            ViewData["type_payment"] = tp.list_type_payment();

            return View();
        }
        public IActionResult employee()
        {
            employeeModel emp = new employeeModel();
            ViewData["employee"] = emp.list_emp();

            return View();
        }
        public IActionResult addEmployee()
        {
            provinceModel pv = new provinceModel();
            ViewData["province"] = pv.drop_province("1");
            ampuresModel am = new ampuresModel();
            ViewData["amphur"] = am.dorp_amphur("1");
            districts dt = new districts();
            ViewData["district"] = dt.drop_district("1");
            positionModel pt = new positionModel();
            ViewData["position_list"] = pt.drop_position();
            prefixModel px = new prefixModel();
            ViewData["prefix"] = px.drop_prefix("");

            return View();
        }
        public IActionResult typeEmp()
        {
            lineModel ln = new lineModel();
            employeeModel emp = new employeeModel();
            line_saleModel ls = new line_saleModel();
            line_transport lt = new line_transport();

            ViewData["line"] = ln.drop_line("");
            ViewData["employee"] = emp.drop_emp("");
            ViewData["line_sale"] = ls.list_line_sale();
            ViewData["line_tran"] = lt.list_line_tran();
 
            return View();
        }
        public IActionResult groupProduct()
        {

            unitModel un = new unitModel();
            ViewData["unit"] = un.drop_unit("");

            groupPoductModel gp = new groupPoductModel();
            ViewData["gp"] = gp.list_gp();

            
            return View();
        }
        public string gp_code(string id) {

            groupPoductModel gp = new groupPoductModel();
            gp.gp_code = id;
            gp.check_code();

            return gp.count;
        }
        [HttpPost]
        public IActionResult insert_gp(string gp_code, string gp_name, string gp_unit, string gp_cal) {

            groupPoductModel gp = new groupPoductModel();
            gp.gp_code = gp_code;
            gp.gp_name = gp_name;
            gp.gp_unit = gp_unit;
            gp.gp_type_cal = gp_cal;
            gp.insert_gp();

            return RedirectToAction("groupProduct","Information");
        }
        [HttpPost]
        public IActionResult update_gp(string gp_code_edit, string gp_name_edit, string gp_unit_edit, string gp_cal_edit, string gp_id)
        {

            groupPoductModel gp = new groupPoductModel();
            gp.gp_id = gp_id;
            gp.gp_code = gp_code_edit;
            gp.gp_name = gp_name_edit;
            gp.gp_unit = gp_unit_edit;
            gp.gp_type_cal = gp_cal_edit;
            gp.update_gp();

            return RedirectToAction("groupProduct", "Information");
        }
        public string select_gp(string id) {

            groupPoductModel gp = new groupPoductModel();
            gp.select_gp("gp_id = '"+id+"'");

            return gp.gp_code + "^" + gp.gp_name + "^" + gp.gp_unit + "^" + gp.gp_type_cal;
        }
        public void del_gp(string id) {

            groupPoductModel gp = new groupPoductModel();
            gp.gp_id = id;
            gp.del_gp();

        }
        
    }
}
