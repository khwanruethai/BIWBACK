using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BIWBACK.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.IO;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace BIWBACK.Controllers
{
    public class ProductController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
        private IHostingEnvironment _hostingEnvironment;

        public ProductController(IHostingEnvironment environment)
        {
            _hostingEnvironment = environment;
        }
        public IActionResult product()
        {

            productModel pd = new productModel();
            ViewData["product"] = pd.list_product();

            return View();
        }
        public IActionResult addProduct()
        {
            groupPoductModel gp = new groupPoductModel();
            ViewData["gp"] = gp.drop_gp("");

            unitModel un = new unitModel();
            ViewData["unit"] = un.drop_unit("");

            return View();
        }
        public IActionResult editProduct(string id)
        {
            productModel pd = new productModel();
            pd.select_product("pd_id = '"+id+"'");

            ViewData["pd_id"] = id;
            ViewData["pd_img"] = pd.pd_img;
            ViewData["pd_code"] = pd.pd_code;
            ViewData["pd_name"] = pd.pd_name;
            ViewData["pd_color"] = pd.pd_color;
            ViewData["pd_width"] = pd.pd_width;
            ViewData["pd_long"] = pd.pd_long;
            ViewData["pd_detail"] = pd.pd_detail;
            ViewData["pd_price"] = pd.pd_price;
            ViewData["pd_sale"] = pd.pd_sale;

            groupPoductModel gp = new groupPoductModel();
            ViewData["gp"] = gp.drop_gp(pd.pd_ref_group_product);
            ViewData["gp_2"] = gp.drop_gp(pd.pd_ref_group_product_sale);

            unitModel un = new unitModel();
            ViewData["unit"] = un.drop_unit(pd.pd_unit);

            return View();
        }
        public IActionResult viewProduct(string id)
        {
            productModel pd = new productModel();
            pd.select_product("pd_id = '" + id + "'");

            ViewData["pd_id"] = id;
            ViewData["pd_img"] = pd.pd_img;
            ViewData["pd_code"] = pd.pd_code;
            ViewData["pd_name"] = pd.pd_name;
            ViewData["pd_color"] = pd.pd_color;
            ViewData["pd_width"] = pd.pd_width;
            ViewData["pd_long"] = pd.pd_long;
            ViewData["pd_detail"] = pd.pd_detail;
            ViewData["pd_price"] = pd.pd_price;
            ViewData["pd_sale"] = pd.pd_sale;

            groupPoductModel gp = new groupPoductModel();
            ViewData["gp"] = gp.drop_gp(pd.pd_ref_group_product);
            ViewData["gp_2"] = gp.drop_gp(pd.pd_ref_group_product_sale);

            unitModel un = new unitModel();
            ViewData["unit"] = un.drop_unit(pd.pd_unit);

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> insert_product(IList<IFormFile> selectFile, string pd_code,string pd_group, string pd_group_sale, string pd_name, string pd_unit, string pd_color, string pd_width, string pd_long, string pd_detail, string pd_price, string pd_sale)
        {

            productModel pd = new productModel();

            var uploads = Path.Combine(_hostingEnvironment.WebRootPath, "product_img");
            int num = selectFile.Count();
            if (num != 0)
            {
                foreach (var file in selectFile)
                {
                    if (file.Length > 0)
                    {

                        var filePath = Path.Combine(uploads, file.FileName);
                        pd.pd_img = file.FileName;

                        using (var fileStream = new FileStream(filePath, FileMode.Create))
                        {
                            await file.CopyToAsync(fileStream);

                        }

                    }
                    else
                    {

                        pd.pd_img = "nopicture.jpg";

                    }
                }
            }
            else
            {

                pd.pd_img = "nopicture.jpg";
            }


            pd.pd_code = pd_code;
            pd.pd_ref_group_product = pd_group;
            pd.pd_ref_group_product_sale = pd_group_sale;
            pd.pd_name = pd_name;
            pd.pd_unit = pd_unit;
            pd.pd_color = pd_color;
            pd.pd_width = pd_width;
            pd.pd_long = pd_long; 
            pd.pd_detail = pd_detail;
            pd.pd_price = pd_price;
            pd.pd_sale = pd_sale;

            pd.insert_product();

            return RedirectToAction("product","Product");
        }
        [HttpPost]
        public async Task<IActionResult> update_product(IList<IFormFile> selectFile,string pd_img, string pd_id, string pd_code, string pd_group, string pd_group_sale, string pd_name, string pd_unit, string pd_color, string pd_width, string pd_long, string pd_detail, string pd_price, string pd_sale)
        {

            productModel pd = new productModel();

            pd.pd_id = pd_id;

            var uploads = Path.Combine(_hostingEnvironment.WebRootPath, "product_img");
            int num = selectFile.Count();
            if (num != 0)
            {
                foreach (var file in selectFile)
                {
                    if (file.Length > 0)
                    {

                        var filePath = Path.Combine(uploads, file.FileName);
                        pd.pd_img = file.FileName;

                        using (var fileStream = new FileStream(filePath, FileMode.Create))
                        {
                            await file.CopyToAsync(fileStream);

                        }

                    }
                    else
                    {

                        pd.pd_img = pd_img;

                    }
                }
            }
            else
            {

                pd.pd_img = pd_img;
            }


            pd.pd_code = pd_code;
            pd.pd_ref_group_product = pd_group;
            pd.pd_ref_group_product_sale = pd_group_sale;
            pd.pd_name = pd_name;
            pd.pd_unit = pd_unit;
            pd.pd_color = pd_color;
            pd.pd_width = pd_width;
            pd.pd_long = pd_long;
            pd.pd_detail = pd_detail;
            pd.pd_price = pd_price;
            pd.pd_sale = pd_sale;

            pd.update_product();

            return RedirectToAction("product", "Product");
        }
        public void del_product(string id) {

            productModel pd = new productModel();
            pd.pd_id = id;
            pd.del_product();

        }
    }
}
