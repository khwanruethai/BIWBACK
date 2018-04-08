using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BIWBACK.Models
{
    public class lineModel
    {
        public string line_id { get; set; }
        public string line_code { get; set; }
        public string line_name { get; set; }
        public string line_create_date { get; set; }
        public string line_create_admin_id { get; set; }
        public string line_edit_date { get; set; }
        public string line_edit_admin_id { get; set; }
        public string line_status { get; set; }

        DatabaseClass db = new DatabaseClass();

        public void insert_line()
        {

            string table = "st_line";
            string[] Columns = {  "line_code",   "line_name",   "line_create_date",    "line_create_admin_id",   "line_edit_date",  "line_edit_admin_id"};
            string[] Values = {    line_code ,  line_name,   DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),    "1" , DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),  "1"};
            db.insert_db(table, Columns, Values);

        }
        public void update_line()
        {

            string table = "st_line";
            string[] Columns = { "line_code", "line_name",   "line_edit_date", "line_edit_admin_id" };
            string[] Values = {  line_code, line_name,   DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), "1" };
            string where = "line_id = '" + line_id + "'";

            db.update_db(table, Columns, Values, where);

        }
        public void del_line()
        {

            string table = "st_line";
            string[] Columns = { "line_status" };
            string[] Values = { "N" };
            string where = "line_id = '" + line_id + "'";

            db.update_db(table, Columns, Values, where);

        }
        public void select_line(string where_)
        {

            string table = "st_line";
            string[] Columns = { "line_id", "line_code", "line_name", "line_create_date", "line_create_admin_id", "line_edit_date", "line_edit_admin_id", "line_status" };
            string join = "";
            string where = where_;
            string groupby = "";
            string orderby = "";

            List<string> result = db.select_db(Columns, table, join, where, groupby, orderby);

            line_id = result[0];
            line_code = result[1];
            line_name = result[2];
            line_create_date = result[3];
            line_create_admin_id = result[4];
            line_edit_date = result[5];
            line_edit_admin_id = result[6];
            line_status = result[7];


        }
        public List<SelectListItem> drop_line(string selected)
        {

            List<SelectListItem> item = new List<SelectListItem>();

            string table = "st_line";
            string where = "line_status = 'Y'";
            string join = "";
            string groupby = "";
            string orderby = "";
            string text = "line_name";
            string value = "line_id";

            item = db.creat_dropdown(table, where, join, groupby, orderby, text, value, selected);

            return item;
        }
        public List<lineModel> list_line()
        {

            List<lineModel> item = new List<lineModel>();

            db.dbConnect();

            db.cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT * FROM st_line WHERE line_status = 'Y'", db.conn);
            db.rdr = db.cmd.ExecuteReader();
            while (db.rdr.Read())
            {

                lineModel ln = new lineModel();
                ln.line_id = db.rdr["line_id"].ToString();
                ln.line_code = db.rdr["line_code"].ToString();
                ln.line_name = db.rdr["line_name"].ToString();
                ln.line_create_date = db.rdr["line_create_date"].ToString();
                ln.line_create_admin_id = db.rdr["line_create_admin_id"].ToString();
                ln.line_edit_date = db.rdr["line_edit_date"].ToString();
                ln.line_edit_admin_id = db.rdr["line_edit_admin_id"].ToString();
                ln.line_status = db.rdr["line_status"].ToString();
                item.Add(ln);
            }
            db.rdr.Close();
            db.dbClosed();

            return item;
        }
    }
}
