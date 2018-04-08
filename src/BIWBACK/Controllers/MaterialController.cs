using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.IO;
using BIWBACK.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace BIWBACK.Controllers
{
    public class MaterialController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult material()
        {
            MaterialModel mtr = new MaterialModel();
            ViewData["material"] = mtr.list_mtr();

            return View();
        }
        public IActionResult addMaterial()
        {
            groupMaterialModel gm = new groupMaterialModel();
            ViewData["group_material"] = gm.drop_gm("");

            unitModel un = new unitModel();
            ViewData["unit"] = un.drop_unit("");


            stickerModel stk = new stickerModel();
            ViewData["sticker"] = stk.drop_con_pay("");

            shelfModel sh = new shelfModel();
            ViewData["shelf"] = sh.drop_shelf("");

            return View();
        }
        private IHostingEnvironment _hostingEnvironment;

        public MaterialController(IHostingEnvironment environment)
        {
            _hostingEnvironment = environment;
        }
        [HttpPost]
        public async Task<IActionResult> insert_mtr(IList<IFormFile> selectFile,string mtr_tm, string mtr_code, string mtr_name, string mtr_detail, string mtr_shelf, string mtr_unit_get, string mtr_keep_num, string mtr_unit_expose, string mtr_width, string mtr_long, string mtr_side, string mtr_roll, string mtr_noti, string mtr_noti_min, string mtr_noti_max, string mtr_sticker)
        {

            MaterialModel mtr = new MaterialModel();

            

            var uploads = Path.Combine(_hostingEnvironment.WebRootPath, "material_img");
            int num = selectFile.Count();
            if (num != 0)
            {


                foreach (var file in selectFile)
                {
                    if (file.Length > 0)
                    {

                        var filePath = Path.Combine(uploads, file.FileName);
                        mtr.mtr_img = file.FileName;

                        using (var fileStream = new FileStream(filePath, FileMode.Create))
                        {
                            await file.CopyToAsync(fileStream);

                        }

                    }
                    else
                    {

                        mtr.mtr_img = "nopicture.jpg";

                    }
                }
            }
            else
            {

                mtr.mtr_img = "nopicture.jpg";
            }


            
            mtr.mtr_ref_tm_id = mtr_tm;
            mtr.mtr_code = mtr_code;
            mtr.mtr_name = mtr_name;
            mtr.mtr_detail = mtr_detail;
            mtr.mtr_shelf = mtr_shelf;
            mtr.mtr_unit_get = mtr_unit_get;
            mtr.mtr_keep_num = mtr_keep_num;
            mtr.mtr_unit_expose = mtr_unit_expose;
            mtr.mtr_width = mtr_width;
            mtr.mtr_long = mtr_long;
            mtr.mtr_side = mtr_side;
            mtr.mtr_roll = mtr_roll;
            mtr.mtr_noti = mtr_noti;
            mtr.mtr_noti_min = mtr_noti_min;
            mtr.mtr_noti_max = mtr_noti_max;
            mtr.mtr_sticker = mtr_sticker;

            mtr.insert_mtr();

            
            return RedirectToAction("material","Material");
        }
        public IActionResult editMaterial(string id) {

            ViewData["mtr_id"] = id;

            MaterialModel mt = new MaterialModel();
            mt.select_mtr("mtr_id = '" + id + "'");
            ViewData["mtr_img"] = mt.mtr_img;
            ViewData["mtr_code"] = mt.mtr_code;
            ViewData["mtr_name"] = mt.mtr_name;
            ViewData["mtr_detail"] = mt.mtr_detail;
            ViewData["mtr_keep_num"] = mt.mtr_keep_num;
            ViewData["mtr_width"] = mt.mtr_width;
            ViewData["mtr_long"] = mt.mtr_long;
            ViewData["mtr_side"] = mt.mtr_side;
            ViewData["mtr_roll"]= mt.mtr_roll;
            ViewData["mtr_noti"] = mt.mtr_noti;
            ViewData["mtr_noti_min"] = mt.mtr_noti_min;
            ViewData["mtr_noti_max"] = mt.mtr_noti_max;



            groupMaterialModel gm = new groupMaterialModel();
            ViewData["group_material"] = gm.drop_gm(mt.mtr_ref_tm_id);

            unitModel un = new unitModel();
            ViewData["unit_get"] = un.drop_unit(mt.mtr_unit_get);
            ViewData["unit_expose"] = un.drop_unit(mt.mtr_unit_expose);


            stickerModel stk = new stickerModel();
            ViewData["sticker"] = stk.drop_con_pay(mt.mtr_sticker);

            shelfModel sh = new shelfModel();
            ViewData["shelf"] = sh.drop_shelf(mt.mtr_shelf);

            return View();
        }
        public IActionResult viewMaterial(string id)
        {

            ViewData["mtr_id"] = id;

            MaterialModel mt = new MaterialModel();
            mt.select_mtr("mtr_id = '" + id + "'");
            ViewData["mtr_img"] = mt.mtr_img;
            ViewData["mtr_code"] = mt.mtr_code;
            ViewData["mtr_name"] = mt.mtr_name;
            ViewData["mtr_detail"] = mt.mtr_detail;
            ViewData["mtr_keep_num"] = mt.mtr_keep_num;
            ViewData["mtr_width"] = mt.mtr_width;
            ViewData["mtr_long"] = mt.mtr_long;
            ViewData["mtr_side"] = mt.mtr_side;
            ViewData["mtr_roll"] = mt.mtr_roll;
            ViewData["mtr_noti"] = mt.mtr_noti;
            ViewData["mtr_noti_min"] = mt.mtr_noti_min;
            ViewData["mtr_noti_max"] = mt.mtr_noti_max;



            groupMaterialModel gm = new groupMaterialModel();
            ViewData["group_material"] = gm.drop_gm(mt.mtr_ref_tm_id);

            unitModel un = new unitModel();
            ViewData["unit_get"] = un.drop_unit(mt.mtr_unit_get);
            ViewData["unit_expose"] = un.drop_unit(mt.mtr_unit_expose);


            stickerModel stk = new stickerModel();
            ViewData["sticker"] = stk.drop_con_pay(mt.mtr_sticker);

            shelfModel sh = new shelfModel();
            ViewData["shelf"] = sh.drop_shelf(mt.mtr_shelf);

            return View();
        }


        [HttpPost]
        public async Task<IActionResult> update_mtr(IList<IFormFile> selectFile, string mtr_img, string mtr_id, string mtr_tm, string mtr_code, string mtr_name, string mtr_detail, string mtr_shelf, string mtr_unit_get, string mtr_keep_num, string mtr_unit_expose, string mtr_width, string mtr_long, string mtr_side, string mtr_roll, string mtr_noti, string mtr_noti_min, string mtr_noti_max, string mtr_sticker)
        {
            MaterialModel mtr = new MaterialModel();

          

            var uploads = Path.Combine(_hostingEnvironment.WebRootPath, "material_img");
            int num = selectFile.Count();
            if (num != 0)
            {
                foreach (var file in selectFile)
                {
                    if (file.Length > 0)
                    {

                        var filePath = Path.Combine(uploads, file.FileName);
                        mtr.mtr_img = file.FileName;

                        using (var fileStream = new FileStream(filePath, FileMode.Create))
                        {
                            await file.CopyToAsync(fileStream);

                        }

                    }
                    else
                    {

                        mtr.mtr_img = mtr_img;

                    }
                }
            }
            else
            {

                mtr.mtr_img = mtr_img;
            }


            mtr.mtr_ref_tm_id = mtr_tm;
            mtr.mtr_code = mtr_code;
            mtr.mtr_name = mtr_name;
            mtr.mtr_detail = mtr_detail;
            mtr.mtr_shelf = mtr_shelf;
            mtr.mtr_unit_get = mtr_unit_get;
            mtr.mtr_keep_num = mtr_keep_num;
            mtr.mtr_unit_expose = mtr_unit_expose;
            mtr.mtr_width = mtr_width;
            mtr.mtr_long = mtr_long;
            mtr.mtr_side = mtr_side;
            mtr.mtr_roll = mtr_roll;
            mtr.mtr_noti = mtr_noti;
            mtr.mtr_noti_min = mtr_noti_min;
            mtr.mtr_noti_max = mtr_noti_max;
            mtr.mtr_sticker = mtr_sticker;
            mtr.mtr_id = mtr_id;

            mtr.update_mtr();


            return RedirectToAction("material","Material");
        }
        public void del_mtr(string id) {

            MaterialModel mt = new MaterialModel();
            mt.mtr_id = id;
            mt.del_mtr();
        }


    }
}
