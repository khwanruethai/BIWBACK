using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using BIWBACK.Models;
using System.IO;
using Microsoft.AspNetCore.Hosting;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace BIWBACK.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
        private IHostingEnvironment _hostingEnvironment;

        public EmployeeController(IHostingEnvironment environment)
        {
            _hostingEnvironment = environment;
        }
        [HttpPost]
        public async Task<IActionResult>  insert_emp(IList<IFormFile> selectFile, string emp_code, string emp_prefix, string emp_name, string emp_lastname, string emp_position, string emp_address, string emp_road, string emp_province, string emp_amphur, string emp_district, string emp_postcode, string emp_tel, string emp_fax, string emp_email, string emp_national_id, string emp_tax, string emp_gender, string emp_birth, string emp_start, string emp_end)
        {
            employeeModel emp = new employeeModel();

            var uploads = Path.Combine(_hostingEnvironment.WebRootPath, "images");
            int num = selectFile.Count();
            if (num != 0)
            {
                foreach (var file in selectFile)
                {
                    if (file.Length > 0)
                    {

                        var filePath = Path.Combine(uploads, file.FileName);
                        emp.emp_img = file.FileName;

                        using (var fileStream = new FileStream(filePath, FileMode.Create))
                        {
                            await file.CopyToAsync(fileStream);

                        }

                    }
                    else
                    {

                        emp.emp_img = "nopicture.jpg";

                    }
                }
            }
            else {

                emp.emp_img = "nopicture.jpg";
            }


            emp.emp_code = emp_code;
            emp.emp_prefix = emp_prefix;
            emp.emp_name = emp_name;
            emp.emp_lastname = emp_lastname;
            emp.emp_position = emp_position;
            emp.emp_address = emp_address;
            emp.emp_road = emp_road;
            emp.emp_district = emp_district;
            emp.emp_amphur = emp_amphur;
            emp.emp_province = emp_province;
            emp.emp_postcode = emp_postcode;
            emp.emp_tel = emp_tel;
            emp.emp_fax = emp_fax;
            emp.emp_email = emp_email;
            emp.emp_national_id = emp_national_id;
            emp.emp_tax = emp_tax;
            emp.emp_gender = emp_gender;
            emp.emp_birthday = emp_birth;
            emp.emp_start_date = emp_start;
            emp.emp_end_date = emp_end;

            emp.insert_emp();


            return RedirectToAction("employee", "Information");
        }
        [HttpPost]
        public async Task<IActionResult> update_emp(IList<IFormFile> selectFile, string emp_img, string emp_code, string emp_prefix, string emp_name, string emp_lastname, string emp_position, string emp_address, string emp_road, string emp_province, string emp_amphur, string emp_district, string emp_postcode, string emp_tel, string emp_fax, string emp_email, string emp_national_id, string emp_tax, string emp_gender, string emp_birth, string emp_start, string emp_end, string emp_id) {

            employeeModel emp = new employeeModel();

            var uploads = Path.Combine(_hostingEnvironment.WebRootPath, "images");

            int num = selectFile.Count();

            if (num != 0)
            {

                foreach (var file in selectFile)
                {
                    if (file.Length > 0)
                    {

                        var filePath = Path.Combine(uploads, file.FileName);
                        emp.emp_img = file.FileName;

                        using (var fileStream = new FileStream(filePath, FileMode.Create))
                        {
                            await file.CopyToAsync(fileStream);

                        }

                    }
                }
            }
            else {

                emp.emp_img = emp_img;

            }
            
            emp.emp_id = emp_id;
            emp.emp_code = emp_code;
            emp.emp_prefix = emp_prefix;
            emp.emp_name = emp_name;
            emp.emp_lastname = emp_lastname;
            emp.emp_position = emp_position;
            emp.emp_address = emp_address;
            emp.emp_road = emp_road;
            emp.emp_district = emp_district;
            emp.emp_amphur = emp_amphur;
            emp.emp_province = emp_province;
            emp.emp_postcode = emp_postcode;
            emp.emp_tel = emp_tel;
            emp.emp_fax = emp_fax;
            emp.emp_email = emp_email;
            emp.emp_national_id = emp_national_id;
            emp.emp_tax = emp_tax;
            emp.emp_gender = emp_gender;
            emp.emp_birthday = emp_birth;
            emp.emp_start_date = emp_start;
            emp.emp_end_date = emp_end;

            emp.update_emp();

            return RedirectToAction("employee","Information");
        }
        public IActionResult editEmployee(string id) {

            employeeModel emp = new employeeModel();
            prefixModel px = new prefixModel();
            provinceModel pv = new provinceModel();
            ampuresModel am = new ampuresModel();
            districts dt = new districts();
            positionModel ps = new positionModel();
            emp.select_emp("emp_id = '"+id+"'");

            ViewData["emp_code"] = emp.emp_code;
            ViewData["emp_prefix"] = px.drop_prefix(emp.emp_prefix);
            ViewData["emp_name"] = emp.emp_name;
            ViewData["emp_lastname"] = emp.emp_lastname;
            ViewData["emp_position"] = ps.drop_position(emp.emp_position);
            ViewData["emp_address"] = emp.emp_address;
            ViewData["emp_road"] = emp.emp_road;
            ViewData["emp_province"] = pv.drop_province(emp.emp_province);
            ViewData["emp_amphur"] = am.dorp_amphur(emp.emp_amphur);
            ViewData["emp_district"] = dt.drop_district(emp.emp_district);
            ViewData["emp_postcode"] = emp.emp_postcode;
            ViewData["emp_tel"] = emp.emp_tel;
            ViewData["emp_fax"] = emp.emp_fax;
            ViewData["emp_email"] = emp.emp_email;
            ViewData["emp_national_id"] = emp.emp_national_id;
            ViewData["emp_gender"] = emp.emp_gender;
            ViewData["emp_tax"] = emp.emp_tax;
            ViewData["emp_birth"] = emp.emp_birthday;
            ViewData["emp_start"] = emp.emp_start_date;
            ViewData["emp_end"] = emp.emp_end_date;
            ViewData["emp_id"] = id;
            if (string.IsNullOrEmpty(emp.emp_img) == true)
            {

                ViewData["emp_img"] = "nopicture.jpg";
            }
            else
            {

                ViewData["emp_img"] = emp.emp_img;
            }

            return View();
        }
        public IActionResult viewEmployee(string id)
        {

            employeeModel emp = new employeeModel();
            prefixModel px = new prefixModel();
            provinceModel pv = new provinceModel();
            ampuresModel am = new ampuresModel();
            districts dt = new districts();
            positionModel ps = new positionModel();
            emp.select_emp("emp_id = '" + id + "'");


            ViewData["emp_code"] = emp.emp_code;
            ViewData["emp_prefix"] = px.drop_prefix(emp.emp_prefix);
            ViewData["emp_name"] = emp.emp_name;
            ViewData["emp_lastname"] = emp.emp_lastname;
            ViewData["emp_position"] = ps.drop_position(emp.emp_position);
            ViewData["emp_address"] = emp.emp_address;
            ViewData["emp_road"] = emp.emp_road;
            ViewData["emp_province"] = pv.drop_province(emp.emp_province);
            ViewData["emp_amphur"] = am.dorp_amphur(emp.emp_amphur);
            ViewData["emp_district"] = dt.drop_district(emp.emp_district);
            ViewData["emp_postcode"] = emp.emp_postcode;
            ViewData["emp_tel"] = emp.emp_tel;
            ViewData["emp_fax"] = emp.emp_fax;
            ViewData["emp_email"] = emp.emp_email;
            ViewData["emp_national_id"] = emp.emp_national_id;
            ViewData["emp_gender"] = emp.emp_gender;
            ViewData["emp_tax"] = emp.emp_tax;
            ViewData["emp_birth"] = emp.emp_birthday;
            ViewData["emp_start"] = emp.emp_start_date;
            ViewData["emp_end"] = emp.emp_end_date;
            ViewData["emp_id"] = id;
            if (string.IsNullOrEmpty(emp.emp_img) == true)
            {

                ViewData["emp_img"] = "nopicture.jpg";
            }
            else
            {

                ViewData["emp_img"] = emp.emp_img;
            }

            return View();
        }
        public void del_emp(string id) {

            employeeModel emp = new employeeModel();
            emp.emp_id = id;
            emp.del_emp();
        }
    }
}
