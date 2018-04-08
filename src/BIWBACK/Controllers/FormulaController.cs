using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BIWBACK.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace BIWBACK.Controllers
{
    public class FormulaController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult formula()
        {
            FormulaModel fm = new FormulaModel();
            ViewData["formula"] = fm.list_formula();

            return View();
        }
        public IActionResult addFormula()
        {
            groupPoductModel gp = new groupPoductModel();
            ViewData["group_product"] = gp.drop_gp("");


            groupMaterialModel gm = new groupMaterialModel();
            ViewData["group_material"] = gm.drop_gm("");

            unitModel ut = new unitModel();
            ViewData["unit"] = ut.drop_unit("");

            return View();
        }
        [HttpPost]
        public IActionResult insertFormula(string group_product, string group_material, string unit, string result_width, string result_long, string width_action_a, string width_action_a_val, string width_action_b, string width_action_b_val, string long_action_a, string long_action_a_val, string long_action_b, string long_action_b_val, string result_num, string width_x_long, string use_num) {

            checkVal ck = new checkVal();

            FormulaModel fm = new FormulaModel();
            fm.fm_ref_group_product_id = group_product;
            fm.fm_ref_group_material_id = group_material;
            fm.fm_ref_unit_id = unit;
            fm.fm_result_width = ck.trueORfalse(result_width);
            fm.fm_result_long = ck.trueORfalse(result_long);
            fm.fm_width_action_a = width_action_a;
            fm.fm_width_action_a_val = ck.numIsNull(width_action_a_val);
            fm.fm_width_action_b = width_action_b;
            fm.fm_width_action_b_val = ck.numIsNull(width_action_b_val);
            fm.fm_long_action_a = long_action_a;
            fm.fm_long_action_a_val = ck.numIsNull(long_action_a_val);
            fm.fm_long_action_b = long_action_b;
            fm.fm_long_action_b_val = ck.numIsNull(long_action_b_val);
            fm.fm_result_num = ck.trueORfalse(result_num);
            fm.fm_width_x_long = width_x_long;
            fm.fm_use_num = use_num;

            fm.insert_formula();

            return RedirectToAction("formula","Formula");
        }
        public IActionResult editFormula(string id)
        {
            FormulaModel fm = new FormulaModel();
            fm.select_formula("fm_id = '"+id+"'");

            groupPoductModel gp = new groupPoductModel();
            ViewData["group_product"] = gp.drop_gp(fm.fm_ref_group_product_id);
            
            groupMaterialModel gm = new groupMaterialModel();
            ViewData["group_material"] = gm.drop_gm(fm.fm_ref_group_material_id);

            unitModel ut = new unitModel();
            ViewData["unit"] = ut.drop_unit(fm.fm_ref_unit_id);

            ViewData["fm_id"] = id;

            checkVal ck = new checkVal();

            ViewData["result_width"] = ck.turnTF(fm.fm_result_width);
            ViewData["result_long"] = ck.turnTF(fm.fm_result_long);
            ViewData["width_action_a"] = ck.ckFormula(fm.fm_width_action_a);
            ViewData["width_action_a_val"] = fm.fm_width_action_a_val;
            ViewData["width_action_b"] = ck.ckFormula(fm.fm_width_action_b);
            ViewData["width_action_b_val"] = fm.fm_width_action_b_val;
            ViewData["long_action_a"] = ck.ckFormula(fm.fm_long_action_a);
            ViewData["long_action_a_val"] = fm.fm_long_action_a_val;
            ViewData["long_action_b"] = ck.ckFormula(fm.fm_long_action_b);
            ViewData["long_action_b_val"] = fm.fm_long_action_b_val;
            ViewData["result_num"] = ck.turnTF(fm.fm_result_num);
            ViewData["width_x_long"] = fm.fm_width_x_long;
            ViewData["use_num"] = fm.fm_use_num;
            

            return View();
        }
        public IActionResult viewFormula(string id)
        {
            FormulaModel fm = new FormulaModel();
            fm.select_formula("fm_id = '" + id + "'");

            groupPoductModel gp = new groupPoductModel();
            ViewData["group_product"] = gp.drop_gp(fm.fm_ref_group_product_id);

            groupMaterialModel gm = new groupMaterialModel();
            ViewData["group_material"] = gm.drop_gm(fm.fm_ref_group_material_id);

            unitModel ut = new unitModel();
            ViewData["unit"] = ut.drop_unit(fm.fm_ref_unit_id);

            ViewData["fm_id"] = id;

            checkVal ck = new checkVal();

            ViewData["result_width"] = ck.turnTF(fm.fm_result_width);
            ViewData["result_long"] = ck.turnTF(fm.fm_result_long);
            ViewData["width_action_a"] = ck.ckFormula(fm.fm_width_action_a);
            ViewData["width_action_a_val"] = fm.fm_width_action_a_val;
            ViewData["width_action_b"] = ck.ckFormula(fm.fm_width_action_b);
            ViewData["width_action_b_val"] = fm.fm_width_action_b_val;
            ViewData["long_action_a"] = ck.ckFormula(fm.fm_long_action_a);
            ViewData["long_action_a_val"] = fm.fm_long_action_a_val;
            ViewData["long_action_b"] = ck.ckFormula(fm.fm_long_action_b);
            ViewData["long_action_b_val"] = fm.fm_long_action_b_val;
            ViewData["result_num"] = ck.turnTF(fm.fm_result_num);
            ViewData["width_x_long"] = fm.fm_width_x_long;
            ViewData["use_num"] = fm.fm_use_num;


            return View();
        }
        [HttpPost]
        public IActionResult updateFormula(string fm_id, string group_product, string group_material, string unit, string result_width, string result_long, string width_action_a, string width_action_a_val, string width_action_b, string width_action_b_val, string long_action_a, string long_action_a_val, string long_action_b, string long_action_b_val, string result_num, string width_x_long, string use_num)
        {

            checkVal ck = new checkVal();

            FormulaModel fm = new FormulaModel();

            fm.fm_id = fm_id;

            fm.fm_ref_group_product_id = group_product;
            fm.fm_ref_group_material_id = group_material;
            fm.fm_ref_unit_id = unit;
            fm.fm_result_width = ck.trueORfalse(result_width);
            fm.fm_result_long = ck.trueORfalse(result_long);
            fm.fm_width_action_a = width_action_a;
            fm.fm_width_action_a_val = ck.numIsNull(width_action_a_val);
            fm.fm_width_action_b = width_action_b;
            fm.fm_width_action_b_val = ck.numIsNull(width_action_b_val);
            fm.fm_long_action_a = long_action_a;
            fm.fm_long_action_a_val = ck.numIsNull(long_action_a_val);
            fm.fm_long_action_b = long_action_b;
            fm.fm_long_action_b_val = ck.numIsNull(long_action_b_val);
            fm.fm_result_num = ck.trueORfalse(result_num);
            fm.fm_width_x_long = width_x_long;
            fm.fm_use_num = use_num;

            fm.update_formula();

            return RedirectToAction("formula", "Formula");
        }
        public void del_formula(string id) {

            FormulaModel fm = new FormulaModel();
            fm.fm_id = id;
            fm.del_formula();

        }
    }
}
