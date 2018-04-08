using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace BIWBACK.Models
{
    public class employeeModel
    {
        public string  emp_id { get; set; }
        public string  emp_code { get; set; }
        public string  emp_img { get; set; }
        public string  emp_prefix { get; set; }
        public string  emp_name { get; set; }
        public string  emp_lastname { get; set; }
        public string  emp_position { get; set; }
        public string  emp_address { get; set; }
        public string  emp_road { get; set; }
        public string  emp_district { get; set; }
        public string  emp_amphur { get; set; }
        public string  emp_province { get; set; }
        public string  emp_postcode { get; set; }
        public string  emp_tel { get; set; }
        public string  emp_fax { get; set; }
        public string  emp_email { get; set; }
        public string  emp_national_id { get; set; }
        public string  emp_tax { get; set; }
        public string  emp_gender { get; set; }
        public string  emp_birthday { get; set; }
        public string  emp_start_date { get; set; }
        public string  emp_end_date { get; set; }
        public string  emp_create_date { get; set; }
        public string  emp_create_admin_id { get; set; }
        public string  emp_edit_date { get; set; }
        public string  emp_edit_admin_id { get; set; }
        public string  emp_status { get; set; }

        DatabaseClass db = new DatabaseClass();

        CultureInfo th = new CultureInfo("th-TH");
        CultureInfo en = new CultureInfo("EN");

        public void create_code_emp() {

            db.dbConnect();
            db.cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT COUNT(YEAR(emp_start_date)) AS num FROM st_employee WHERE YEAR(emp_start_date) = '"+Convert.ToDateTime(emp_start_date).ToString("yyyy")+"'", db.conn);
            db.rdr = db.cmd.ExecuteReader();
            while (db.rdr.Read()) {


                emp_code = Convert.ToDateTime(emp_start_date).ToString("yy") + Convert.ToInt32(Convert.ToDouble(db.rdr["num"]) + 1).ToString("00");

            }
            db.dbClosed();

           
            
        }

        public void insert_emp()
        {
            if (string.IsNullOrEmpty(emp_code) == true)
            {

                create_code_emp();
            }
            
            string table = "st_employee";
            string[] Columns = { "emp_code", "emp_img", "emp_prefix",  "emp_name", "emp_lastname", "emp_position",  "emp_address", "emp_road", "emp_district", "emp_amphur",  "emp_province", "emp_postcode", "emp_tel" ,"emp_fax", "emp_email", "emp_national_id", "emp_tax", "emp_gender",  "emp_birthday",  "emp_start_date",  "emp_end_date", "emp_create_date", "emp_create_admin_id", "emp_edit_date" ,  "emp_edit_admin_id"  };
            string[] Values = { emp_code, emp_img, emp_prefix, emp_name, emp_lastname, emp_position, emp_address, emp_road, emp_district, emp_amphur, emp_province, emp_postcode, emp_tel, emp_fax, emp_email, emp_national_id, emp_tax, emp_gender, Convert.ToDateTime(emp_birthday).ToString("yyyy-MM-dd"), Convert.ToDateTime(emp_start_date).ToString("yyyy-MM-dd HH:mm:ss"), Convert.ToDateTime(emp_end_date).ToString("yyyy-MM-dd HH:mm:ss")  , DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), "1" ,DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") ,  "1"  };

            db.insert_db(table, Columns, Values);

        }
        public void select_emp(string where_ = "")
        {

            string table = "st_employee";
            string[] Columns = { "emp_id", "emp_code", "emp_img", "emp_prefix", "emp_name", "emp_lastname", "emp_position", "emp_address", "emp_road", "emp_district", "emp_amphur", "emp_province", "emp_postcode", "emp_tel", "emp_fax", "emp_email", "emp_national_id", "emp_tax", "emp_gender", "emp_birthday", "emp_start_date", "emp_end_date", "emp_create_date", "emp_create_admin_id", "emp_edit_date", "emp_edit_admin_id", "emp_status" };
            string join = "";
            string where = where_;
            string groupby = "";
            string orderby = "";

            List<string> result = db.select_db(Columns, table, join, where, groupby, orderby);

            emp_id = result[0];
            emp_code = result[1];
            emp_img = result[2];
            emp_prefix = result[3];
            emp_name = result[4];
            emp_lastname = result[5];
            emp_position = result[6];
            emp_address = result[7];
            emp_road = result[8];
            emp_district = result[9];
            emp_amphur = result[10];
            emp_province = result[11];
            emp_postcode = result[12];
            emp_tel = result[13];
            emp_fax = result[14];
            emp_email = result[15];
            emp_national_id = result[16];
            emp_tax = result[17];
            emp_gender = result[18];
            emp_birthday = result[19];
            emp_start_date = result[20];
            emp_end_date = result[21];
            emp_create_date = result[22];
            emp_create_admin_id = result[23];
            emp_edit_date = result[24];
            emp_edit_admin_id = result[25];
            emp_status = result[26];

        }
        public void update_emp()
        {
            string table = "st_employee";
            string[] Columns = {  "emp_code", "emp_img", "emp_prefix", "emp_name", "emp_lastname", "emp_position", "emp_address", "emp_road", "emp_district", "emp_amphur", "emp_province", "emp_postcode", "emp_tel", "emp_fax", "emp_email", "emp_national_id", "emp_tax", "emp_gender", "emp_birthday", "emp_start_date", "emp_end_date",  "emp_edit_date", "emp_edit_admin_id", };
            string[] Values = { emp_code, emp_img, emp_prefix, emp_name, emp_lastname, emp_position, emp_address, emp_road, emp_district, emp_amphur, emp_province, emp_postcode, emp_tel, emp_fax, emp_email, emp_national_id, emp_tax, emp_gender, Convert.ToDateTime(emp_birthday).ToString("yyyy-MM-dd"), Convert.ToDateTime(emp_start_date).ToString("yyyy-MM-dd HH:mm:ss"), Convert.ToDateTime(emp_end_date).ToString("yyyy-MM-dd HH:mm:ss"), DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), "1",  };
            string where = "emp_id = '" + emp_id + "'";

            db.update_db(table, Columns, Values, where);

        }
        public List<employeeModel> list_emp()
        {

            List<employeeModel> item = new List<employeeModel>();

            db.dbConnect();

            db.cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT * FROM st_employee "+
                                                                   " LEFT JOIN st_prefix ON emp_prefix = st_prefix.prefix_id"+
                                                                   " LEFT JOIN st_position ON emp_position = st_position.ps_id"+
                                                                   " LEFT JOIN provinces ON emp_province = provinces.PROVINCE_ID"+
                                                                   " LEFT JOIN amphures ON emp_amphur = amphures.AMPHUR_ID"+
                                                                   " LEFT JOIN districts ON emp_district = districts.DISTRICT_ID"+
                                                                   " WHERE emp_status = 'Y'", db.conn);
            db.rdr = db.cmd.ExecuteReader();
            while (db.rdr.Read())
            {
                employeeModel emp = new employeeModel();
                emp.emp_id = db.rdr["emp_id"].ToString();
                emp.emp_code = db.rdr["emp_code"].ToString();
                emp.emp_img = db.rdr["emp_img"].ToString();
                emp.emp_prefix = db.rdr["prefix_name"].ToString();
                emp.emp_name = db.rdr["emp_name"].ToString();
                emp.emp_lastname = db.rdr["emp_lastname"].ToString();
                emp.emp_position = db.rdr["ps_name"].ToString();
                emp.emp_address = db.rdr["emp_address"].ToString();
                emp.emp_road = db.rdr["emp_road"].ToString();
                emp.emp_district = db.rdr["DISTRICT_NAME"].ToString();
                emp.emp_amphur = db.rdr["AMPHUR_NAME"].ToString();
                emp.emp_province = db.rdr["PROVINCE_NAME"].ToString();
                emp.emp_postcode = db.rdr["emp_postcode"].ToString();
                emp.emp_tel = db.rdr["emp_tel"].ToString();
                emp.emp_fax = db.rdr["emp_fax"].ToString();
                emp.emp_email = db.rdr["emp_email"].ToString();
                emp.emp_national_id = db.rdr["emp_national_id"].ToString();
                emp.emp_tax = db.rdr["emp_tax"].ToString();
                emp.emp_gender = db.rdr["emp_gender"].ToString();
                emp.emp_birthday = db.rdr["emp_birthday"].ToString();
                emp.emp_start_date = Convert.ToDateTime(db.rdr["emp_start_date"]).ToString("dd/MM/yyyy", en);

                if (Convert.ToDateTime(db.rdr["emp_end_date"]).ToString("dd/MM/yyyy", en) == "01/01/0544")
                {

                    emp.emp_end_date = "";

                }
                else {


                    emp.emp_end_date = Convert.ToDateTime(db.rdr["emp_end_date"]).ToString("dd/MM/yyyy", en);
                }

                emp.emp_create_date = db.rdr["emp_create_date"].ToString();
                emp.emp_create_admin_id = db.rdr["emp_create_admin_id"].ToString();
                emp.emp_edit_date = db.rdr["emp_edit_date"].ToString();
                emp.emp_edit_admin_id = db.rdr["emp_edit_admin_id"].ToString();

                if (emp.emp_end_date == "")
                {

                    emp.emp_status = "ดำเนินการ";
                }
                else {

                    emp.emp_status = "ลาออก";
                }

              
                item.Add(emp);
            }

            db.dbClosed();

            return item;
        }
        public void del_emp()
        {

            string table = "st_employee";
            string[] Columns = { "emp_status" };
            string[] Values = { "N" };
            string where = "emp_id = '" + emp_id + "'";

            db.update_db(table, Columns, Values, where);

        }
        public List<SelectListItem> drop_emp(string selected)
        {

            List<SelectListItem> item = new List<SelectListItem>();

            string table = "st_employee";
            string where = "emp_status = 'Y'";
            string join = "";
            string groupby = "";
            string orderby = "";
            string text = "emp_name";
            string value = "emp_id";

            item = db.creat_dropdown(table, where, join, groupby, orderby, text, value, selected);

            return item;
        }

    }
}
