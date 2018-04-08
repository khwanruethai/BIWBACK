using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace BIWBACK.Models
{
    public class line_transport
    {
            public string emp_tran_id { get; set; }
            public string emp_tran_ref_emp_id { get; set; }
            public string emp_tran_ref_line_id { get; set; }
            public string emp_tran_create_date { get; set; }
            public string emp_tran_create_admin_id { get; set; }
            public string emp_tran_edit_date { get; set; }
            public string emp_tran_edit_admin_id { get; set; }
            public string emp_tran_status { get; set; }

        DatabaseClass db = new DatabaseClass();
        CultureInfo en = new CultureInfo("EN");

        public void insert_line_tran()
        {

            string table = "st_emp_line_transport";
            string[] Columns = {  "emp_tran_ref_emp_id", "emp_tran_ref_line_id", "emp_tran_create_date", "emp_tran_create_admin_id" , "emp_tran_edit_date",  "emp_tran_edit_admin_id"};
            string[] Values = {emp_tran_ref_emp_id ,emp_tran_ref_line_id ,   Convert.ToDateTime(emp_tran_create_date).ToString("yyyy-MM-dd HH:mm:ss") ,   "1"  ,  DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),  "1"};

            db.insert_db(table, Columns, Values);

        }
        public void select_line_tran(string where_ = "")
        {

            string table = "st_emp_line_transport";
            string[] Columns = { "emp_tran_id", "emp_tran_ref_emp_id", "emp_tran_ref_line_id", "emp_tran_create_date", "emp_tran_create_admin_id", "emp_tran_edit_date", "emp_tran_edit_admin_id", "emp_tran_status" };
            string join = "";
            string where = where_;
            string groupby = "";
            string orderby = "";

            List<string> result = db.select_db(Columns, table, join, where, groupby, orderby);
            emp_tran_id = result[0];
            emp_tran_ref_emp_id = result[1];
            emp_tran_ref_line_id = result[2];
            emp_tran_create_date = Convert.ToDateTime(result[3]).ToString("dd/MM/yyyy",en) ;
            emp_tran_create_admin_id = result[4];
            emp_tran_edit_date = result[5];
            emp_tran_edit_admin_id = result[6];
            emp_tran_status = result[7];

        }
        public void update_line_tran()
        {


            string table = "st_emp_line_transport";
            string[] Columns = {  "emp_tran_ref_emp_id", "emp_tran_ref_line_id", "emp_tran_create_date", "emp_tran_create_admin_id", "emp_tran_edit_date", "emp_tran_edit_admin_id" };
            string[] Values = {  emp_tran_ref_emp_id, emp_tran_ref_line_id, Convert.ToDateTime(emp_tran_create_date).ToString("yyyy-MM-dd HH:mm:ss"), "1", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), "1" };
            string where = "emp_tran_id = '"+ emp_tran_id + "'";

            db.update_db(table, Columns, Values, where);

        }
        public List<line_transport> list_line_tran()
        {

            List<line_transport> item = new List<line_transport>();

            db.dbConnect();

            db.cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT * FROM st_emp_line_transport LEFT JOIN st_employee AS emp ON emp.emp_id = emp_tran_ref_emp_id LEFT JOIN st_line ON st_line.line_id = emp_tran_ref_line_id WHERE emp_tran_status = 'Y'", db.conn);
            db.rdr = db.cmd.ExecuteReader();
            while (db.rdr.Read())
            {
                line_transport lt = new line_transport();
                lt.emp_tran_id = db.rdr["emp_tran_id"].ToString();
                lt.emp_tran_ref_emp_id = db.rdr["emp_name"].ToString()+ " " +db.rdr["emp_lastname"].ToString(); ;
                lt.emp_tran_ref_line_id = db.rdr["line_name"].ToString();
                lt.emp_tran_create_date = Convert.ToDateTime(db.rdr["emp_tran_create_date"]).ToString("dd/MM/yyyy", en);
                lt.emp_tran_create_admin_id = db.rdr["emp_tran_create_admin_id"].ToString();
                lt.emp_tran_edit_date = db.rdr["emp_tran_edit_date"].ToString();
                lt.emp_tran_edit_admin_id = db.rdr["emp_tran_edit_admin_id"].ToString();
                lt.emp_tran_status = db.rdr["emp_tran_status"].ToString();


                item.Add(lt);
            }

            db.dbClosed();

            return item;
        }
        public void del_line_tran()
        {

            string table = "st_emp_line_transport";
            string[] Columns = { "emp_tran_status" };
            string[] Values = { "N" };
            string where = "emp_tran_id = '" + emp_tran_id + "'";

            db.update_db(table, Columns, Values, where);

        }
        public List<SelectListItem> drop_line_tran(string selected)
        {

            List<SelectListItem> item = new List<SelectListItem>();

            string table = "st_emp_line_transport";
            string where = "emp_tran_status = 'Y'";
            string join = "LEFT JOIN st_employee AS emp ON emp.emp_id = emp_tran_ref_emp_id LEFT JOIN st_line ON st_line.line_id = emp_tran_ref_line_id ";
            string groupby = "";
            string orderby = "";
            string text = "line_name";
            string value = "emp_tran_id";

            item = db.creat_dropdown(table, where, join, groupby, orderby, text, value, selected);

            return item;
        }

    }
}
