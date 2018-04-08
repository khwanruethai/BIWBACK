using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace BIWBACK.Models
{
    public class line_saleModel
    {
        public string  emp_sale_id { get; set; }
        public string  emp_sale_ref_emp_id { get; set; }
        public string  emp_sale_ref_line_id { get; set; }
        public string  emp_sale_create_date { get; set; }
        public string  emp_sale_create_admin_id { get; set; }
        public string  emp_sale_edit_date { get; set; }
        public string  emp_sale_edit_admin_id { get; set; }
        public string  emp_sale_status { get; set; }

        DatabaseClass db = new DatabaseClass();
        CultureInfo en = new CultureInfo("EN");
       
        public void insert_line_sale()
        {

            string table = "st_emp_line_sale";
            string[] Columns = { "emp_sale_ref_emp_id", "emp_sale_ref_line_id","emp_sale_create_date",  "emp_sale_create_admin_id", "emp_sale_edit_date",  "emp_sale_edit_admin_id"};
            string[] Values = {  emp_sale_ref_emp_id, emp_sale_ref_line_id,    Convert.ToDateTime(emp_sale_create_date).ToString("yyyy-MM-dd HH:mm:ss") ,   "1" ,   DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") , "1"};

            db.insert_db(table, Columns, Values);

        }
        public void select_line_sale(string where_ = "")
        {

            string table = "st_emp_line_sale";
            string[] Columns = { "emp_sale_id", "emp_sale_ref_emp_id", "emp_sale_ref_line_id", "emp_sale_create_date", "emp_sale_create_admin_id", "emp_sale_edit_date", "emp_sale_edit_admin_id", "emp_sale_status" };
            string join = "";
            string where = where_;
            string groupby = "";
            string orderby = "";

            List<string> result = db.select_db(Columns, table, join, where, groupby, orderby);
            emp_sale_id = result[0];
            emp_sale_ref_emp_id = result[1];
            emp_sale_ref_line_id = result[2];
            emp_sale_create_date = Convert.ToDateTime(result[3]).ToString("dd/MM/yyyy", en);
            emp_sale_create_admin_id = result[4];
            emp_sale_edit_date = result[5];
            emp_sale_edit_admin_id = result[6];
            emp_sale_status = result[7];

        }
        public void update_line_sale()
        {

            string table = "st_emp_line_sale";
            string[] Columns = {  "emp_sale_ref_emp_id", "emp_sale_ref_line_id", "emp_sale_create_date", "emp_sale_edit_date", "emp_sale_edit_admin_id"};
            string[] Values = {  emp_sale_ref_emp_id, emp_sale_ref_line_id, Convert.ToDateTime(emp_sale_create_date).ToString("yyyy-MM-dd HH:mm:ss"), DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), "1" };
            string where = "emp_sale_id = '" + emp_sale_id + "'";

            db.update_db(table, Columns, Values, where);

        }
        public List<line_saleModel> list_line_sale()
        {

            List<line_saleModel> item = new List<line_saleModel>();

            db.dbConnect();

            db.cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT * FROM st_emp_line_sale LEFT JOIN st_employee AS emp ON emp.emp_id = emp_sale_ref_emp_id LEFT JOIN st_line ON st_line.line_id = emp_sale_ref_line_id WHERE emp_sale_status = 'Y'", db.conn);
            db.rdr = db.cmd.ExecuteReader();
            while (db.rdr.Read())
            {
                line_saleModel ls = new line_saleModel();
                ls.emp_sale_id = db.rdr["emp_sale_id"].ToString();
                ls.emp_sale_ref_emp_id = db.rdr["emp_name"].ToString();
                ls.emp_sale_ref_line_id = db.rdr["line_name"].ToString();
                ls.emp_sale_create_date = Convert.ToDateTime(db.rdr["emp_sale_create_date"]).ToString("dd/MM/yyyy", en);
                ls.emp_sale_create_admin_id = db.rdr["emp_sale_create_admin_id"].ToString();
                ls.emp_sale_edit_date = db.rdr["emp_sale_edit_date"].ToString();
                ls.emp_sale_edit_admin_id = db.rdr["emp_sale_edit_admin_id"].ToString();
                ls.emp_sale_status = db.rdr["emp_sale_status"].ToString();


                item.Add(ls);
            }

            db.dbClosed();

            return item;
        }
        public void del_line_sale()
        {

            string table = "st_emp_line_sale";
            string[] Columns = { "emp_sale_status" };
            string[] Values = { "N" };
            string where = "emp_sale_id = '" + emp_sale_id + "'";

            db.update_db(table, Columns, Values, where);

        }
        public List<SelectListItem> drop_line_sale(string selected)
        {

            List<SelectListItem> item = new List<SelectListItem>();

            string table = "st_emp_line_sale";
            string where = " emp_sale_status = 'Y' ";
            string join = " LEFT JOIN st_employee AS emp ON emp.emp_id = emp_sale_ref_emp_id LEFT JOIN st_line ON st_line.line_id = emp_sale_ref_line_id ";
            string groupby = "";
            string orderby = "";
            string text = "line_name";
            string value = "emp_sale_id";

            item = db.creat_dropdown(table, where, join, groupby, orderby, text, value, selected);

            return item;
        }
    }
}
