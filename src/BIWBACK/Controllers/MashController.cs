using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BIWBACK.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace BIWBACK.Controllers
{
    public class MashController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult mash()
        {
            MashModel ms = new MashModel();
            ViewData["mash"] = ms.list_mash();

            productModel pd = new productModel();
            ViewData["product"] = pd.drop_product("");

            MaterialModel mt = new MaterialModel();
            ViewData["material"] = mt.drop_mtr("");


            return View();
        }
        
        public IActionResult addMash()
        {
            productModel pd = new productModel();
            ViewData["product"] = pd.drop_product("");
            ViewData["product_list"] = pd.list_product();

            MaterialModel mt = new MaterialModel();
            ViewData["material"] = mt.drop_mtr("");
            
            return View();
        }
        public IActionResult modelMash()
        {
            MashModelProductModel mmp = new MashModelProductModel();
            ViewData["mmp"] = mmp.list_mmp();

            MaterialModel mt = new MaterialModel();
            ViewData["material"] = mt.drop_mtr("");

            modelProductModel mpd = new modelProductModel();
            ViewData["modelProduct"] = mpd.drop_mp("");

            return View();
        }
        public IActionResult addModelMash()
        {

            MaterialModel mt = new MaterialModel();
            ViewData["material"] = mt.drop_mtr("");

            modelProductModel mpd = new modelProductModel();
            ViewData["modelProduct"] = mpd.drop_mp("");
            ViewData["modelProduct_list"] = mpd.list_mp();
            

            return View();
        }
        [HttpPost]
        public IActionResult insertMash(IEnumerable<string> material_id, IEnumerable<string> product_id) {

            int length = material_id.Count();

            List<string> product = new List<string>();
            List<string> material = new List<string>();

            foreach (string p in product_id) {

                product.Add(p);

            }
            foreach (string m in material_id)
            {

                material.Add(m);

            }

            int i = 0;
            for (i = 0; i < length; i++) {

                MashModel ms = new MashModel();
                ms.mash_ref_product_id = product[i];
                ms.mash_ref_material_id = material[i];
                ms.insert_mash();
            }
            


            return RedirectToAction("mash","Mash");
        }
        public string select_mash(string id) {

            MashModel ms = new MashModel();
            ms.select_mash("mash_id = '"+id+"'");

            return ms.mash_ref_product_id + "^" + ms.mash_ref_material_id;
        }
        public void del_mash(string id) {


            MashModel ms = new MashModel();
            ms.mash_id = id;
            ms.del_mash();
        }
        [HttpPost]
        public IActionResult update_mash(string product, string material, string mash_id) {

            MashModel ms = new MashModel();
            ms.mash_id = mash_id;
            ms.mash_ref_product_id = product;
            ms.mash_ref_material_id = material;
            ms.update_mash();
            
            return RedirectToAction("mash","Mash");
        }
        ///mash model product
        ///
        [HttpPost]
        public IActionResult insertModelMash(IEnumerable<string> material_id, IEnumerable<string> modelproduct_id)
        {
         
            int length = material_id.Count();

            List<string> modelProduct = new List<string>();
            List<string> material = new List<string>();

            foreach (string mp in modelproduct_id)
            {

                modelProduct.Add(mp);

            }
            foreach (string m in material_id)
            {

                material.Add(m);

            }

            int i = 0;
            for (i = 0; i < length; i++)
            {
                MashModelProductModel mmp = new MashModelProductModel();

                mmp.mmp_ref_material_id = material[i];
                mmp.mmp_ref_model_product_id = modelProduct[i];

                mmp.insert_mmp();
            }



            return RedirectToAction("modelMash", "Mash");
        }
        [HttpPost]
        public IActionResult update_mmp(string material, string modelProduct, string mmp_id) {


            MashModelProductModel mmp = new MashModelProductModel();
            mmp.mmp_id = mmp_id;
            mmp.mmp_ref_model_product_id = modelProduct;
            mmp.mmp_ref_material_id = material;
            mmp.update_mmp();


            return RedirectToAction("modelMash","Mash");
        }
        public string select_mmp(string id) {

            MashModelProductModel mmp = new MashModelProductModel();
            mmp.select_mmp("mmp_id = '"+id+"'");


            return mmp.mmp_ref_material_id + "^" + mmp.mmp_ref_model_product_id;
        }
        public void del_mmp(string id) {

            MashModelProductModel mmp = new MashModelProductModel();
            mmp.mmp_id = id;
            mmp.del_mmp();

        }
    }
}
