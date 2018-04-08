using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace BIWBACK.Models
{
    public class typeMaterialModel
    {

        public string tm_id { get; set; }
        public string tm_name { get; set; }
        public string tm_create_date { get; set; }
        public string tm_create_admin_id { get; set; }
        public string tm_edit_date { get; set; }
        public string tm_edit_admin_id { get; set; }
        public string tm_status { get; set; }

        CultureInfo en = new CultureInfo("EN");
        CultureInfo th = new CultureInfo("TH");
        DatabaseClass db = new DatabaseClass();

        public void insert_type_material()
        {

            string table = "st_type_material";
            string[] Columns = {"tm_name", "tm_create_date",  "tm_create_admin_id",  "tm_edit_date",  "tm_edit_admin_id" };
            string[] Values = {  tm_name, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss",en) , "1", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", en),  "1"  };
            db.insert_db(table, Columns, Values);

        }
        public void update_type_material()
        {

            string table = "st_type_material";
            string[] Columns = {  "tm_name", "tm_edit_date", "tm_edit_admin_id"};
            string[] Values = {  tm_name, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", en), "1" };
            string where = "tm_id = '" + tm_id + "'";

            db.update_db(table, Columns, Values, where);

        }
        public void del_type_material()
        {

            string table = "st_type_material";
            string[] Columns = { "tm_status" };
            string[] Values = { "N" };
            string where = "tm_id = '" + tm_id + "'";

            db.update_db(table, Columns, Values, where);

        }
        public void select_type_material(string where_)
        {

            string table = "st_type_material";
            string[] Columns = { "tm_id", "tm_name", "tm_create_date", "tm_create_admin_id", "tm_edit_date", "tm_edit_admin_id", "tm_status" };
            string join = "";
            string where = where_;
            string groupby = "";
            string orderby = "";

            List<string> result = db.select_db(Columns, table, join, where, groupby, orderby);
            tm_id = result[0];
            tm_name = result[1];
            tm_create_date = result[2];
            tm_create_admin_id = result[3];
            tm_edit_date = result[4];
            tm_edit_admin_id = result[5];
            tm_status = result[6];

        }
        public List<SelectListItem> drop_type_material(string selected)
        {

            List<SelectListItem> item = new List<SelectListItem>();

            string table = "st_type_material";
            string where = "tm_status = 'Y'";
            string join = "";
            string groupby = "";
            string orderby = "";
            string text = "tm_name";
            string value = "tm_id";

            item = db.creat_dropdown(table, where, join, groupby, orderby, text, value, selected);

            return item;
        }
        public List<typeMaterialModel> list_type_material()
        {

            List<typeMaterialModel> item = new List<typeMaterialModel>();

            db.dbConnect();

            db.cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT * FROM st_type_material WHERE tm_status = 'Y'", db.conn);
            db.rdr = db.cmd.ExecuteReader();
            while (db.rdr.Read())
            {

                typeMaterialModel tm = new typeMaterialModel();
                tm.tm_id = db.rdr["tm_id"].ToString();
                tm.tm_name = db.rdr["tm_name"].ToString();
                tm.tm_create_date = db.rdr["tm_create_date"].ToString();
                tm.tm_create_admin_id= db.rdr["tm_create_admin_id"].ToString();
                tm.tm_edit_date = db.rdr["tm_edit_date"].ToString();
                tm.tm_edit_admin_id = db.rdr["tm_edit_admin_id"].ToString();
                tm.tm_status = db.rdr["tm_status"].ToString();

                item.Add(tm);
            }
            db.rdr.Close();
            db.dbClosed();

            return item;
        }
    }
}
