using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BIWBACK.Models
{
    public class unitModel
    {
       public string unit_id { get; set; }
       public string unit_name { get; set; }
       public string unit_create_date { get; set; }
       public string unit_create_admin_id { get; set; }
       public string unit_edit_date { get; set; }
       public string unit_edit_admin_id { get; set; }
       public string unit_status { get; set; }

        DatabaseClass db = new DatabaseClass();

        public void insert_unit() {

            string table = "st_unit";
            string[] Columns = { "unit_name","unit_create_date", "unit_create_admin_id" , "unit_edit_date", "unit_edit_admin_id" };
            string[] Values = {  unit_name,   DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") ,   "1",    DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") , "1"};
            db.insert_db(table, Columns, Values);

        }
        public void update_unit() {

            string table = "st_unit";
            string[] Columns = {  "unit_name", "unit_create_date", "unit_create_admin_id", "unit_edit_date", "unit_edit_admin_id" };
            string[] Values = { unit_name, Convert.ToDateTime(unit_create_date).ToString("yyyy-MM-dd HH:mm:ss"), "1", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), "1" };
            string where = "unit_id = '"+unit_id+"'";

            db.update_db(table, Columns, Values, where);

        }
        public void del_unit() {

            string table = "st_unit";
            string[] Columns = {"unit_status" };
            string[] Values = { "N"};
            string where = "unit_id = '" + unit_id + "'";

            db.update_db(table, Columns, Values, where);

        }
        public void select_unit(string where_) {

            string table = "st_unit";
            string[] Columns = { "unit_id","unit_name", "unit_create_date", "unit_create_admin_id", "unit_edit_date", "unit_edit_admin_id", "unit_status" };
            string join = "";
            string where = where_;
            string groupby = "";
            string orderby = "";

          List<string> result =  db.select_db(Columns,table,join, where, groupby, orderby );

            unit_id = result[0];
            unit_name = result[1];
            unit_create_date = result[2];
            unit_create_admin_id = result[3];
            unit_edit_date = result[4];
            unit_edit_admin_id = result[5];
            unit_status = result[6];

        }
        public List<SelectListItem> drop_unit(string selected)
        {

            List<SelectListItem> item = new List<SelectListItem>();

            string table = "st_unit";
            string where = "unit_status = 'Y'";
            string join = "";
            string groupby = "";
            string orderby = "";
            string text = "unit_name";
            string value = "unit_id";

            item = db.creat_dropdown(table, where, join, groupby, orderby, text, value, selected);

            return item;
        }
        public List<unitModel> list_unit() {

            List<unitModel> item = new List<unitModel>();

            db.dbConnect();

            db.cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT * FROM st_unit WHERE unit_status = 'Y'", db.conn);
            db.rdr = db.cmd.ExecuteReader();
            while (db.rdr.Read()) {

                unitModel ut = new unitModel();
                ut.unit_id = db.rdr["unit_id"].ToString();
                ut.unit_name = db.rdr["unit_name"].ToString();
                ut.unit_create_date = db.rdr["unit_create_date"].ToString();
                ut.unit_create_admin_id = db.rdr["unit_create_admin_id"].ToString();
                ut.unit_edit_date = db.rdr["unit_edit_date"].ToString();
                ut.unit_edit_admin_id = db.rdr["unit_edit_admin_id"].ToString();
                ut.unit_status = db.rdr["unit_status"].ToString();
                item.Add(ut);
            }
            db.rdr.Close();
            db.dbClosed();

            return item;
        }
    }
}
