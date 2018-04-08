using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace BIWBACK.Models
{
    public class groupPoductModel
    {
        public string  gp_id { get; set; }
        public string  gp_code { get; set; }
        public string  gp_name { get; set; }
        public string  gp_unit { get; set; }
        public string  gp_type_cal { get; set; }
        public string  gp_create_date { get; set; }
        public string  gp_create_admin_id { get; set; }
        public string  gp_edit_date { get; set; }
        public string  gp_edit_admin_id { get; set; }
        public string  gp_status { get; set; }


        //

            public string count { get; set; }
        CultureInfo en = new CultureInfo("EN");
        CultureInfo th = new CultureInfo("TH");

        DatabaseClass db = new DatabaseClass();

        public void check_code() {

            db.dbConnect();

            db.cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT COUNT(gp_id) AS num FROM st_group_product WHERE gp_code = '"+gp_code+"' AND gp_status = 'Y'",db.conn);
            db.rdr = db.cmd.ExecuteReader();
            while (db.rdr.Read()) {

                count = db.rdr["num"].ToString();

            }

            db.rdr.Close();
            db.dbClosed();


        }

        public void insert_gp()
        {
            string table = "st_group_product";
            string[] Columns = {  "gp_code", "gp_name", "gp_unit", "gp_type_cal", "gp_create_date",  "gp_create_admin_id",  "gp_edit_date",  "gp_edit_admin_id"};
            string[] Values = {   gp_code ,gp_name, gp_unit, gp_type_cal, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", en), "1" , DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", en)  ,  "1" };
            db.insert_db(table, Columns, Values);

        }
        public void update_gp()
        {
            string table = "st_group_product";
            string[] Columns = {  "gp_code", "gp_name", "gp_unit", "gp_type_cal", "gp_edit_date", "gp_edit_admin_id"  };
            string[] Values = {  gp_code, gp_name, gp_unit, gp_type_cal,  DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", en), "1" };
            string where = "gp_id = '" + gp_id + "'";

            db.update_db(table, Columns, Values, where);

        }
        public void del_gp()
        {

            string table = "st_group_product";
            string[] Columns = { "gp_status" };
            string[] Values = { "N" };
            string where = "gp_id = '" + gp_id + "'";

            db.update_db(table, Columns, Values, where);

        }
        public void select_gp(string where_)
        {
            string table = "st_group_product";
            string[] Columns = { "gp_id", "gp_code", "gp_name", "gp_unit", "gp_type_cal", "gp_create_date", "gp_create_admin_id", "gp_edit_date", "gp_edit_admin_id", "gp_status" };
            string[] Values = { gp_id, gp_code, gp_name, gp_unit, gp_type_cal, gp_create_date, gp_create_admin_id, gp_edit_date, gp_edit_admin_id, gp_status };
            string join = "";
            string where = where_;
            string groupby = "";
            string orderby = "";

            List<string> result = db.select_db(Columns, table, join, where, groupby, orderby);
            gp_id = result[0];
            gp_code = result[1];
            gp_name = result[2];
            gp_unit = result[3];
            gp_type_cal = result[4];
            gp_create_date = result[5];
            gp_create_admin_id = result[6];
            gp_edit_date = result[7];
            gp_edit_admin_id = result[8];
            gp_status = result[9];

        }
        public List<SelectListItem> drop_gp(string selected)
        {

            List<SelectListItem> item = new List<SelectListItem>();

            string table = "st_group_product";
            string where = "gp_status = 'Y'";
            string join = "";
            string groupby = "";
            string orderby = "";
            string text = "gp_name";
            string value = "gp_id";

            item = db.creat_dropdown(table, where, join, groupby, orderby, text, value, selected);

            return item;
        }
        public List<groupPoductModel> list_gp()
        {

            List<groupPoductModel> item = new List<groupPoductModel>();

            db.dbConnect();

            db.cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT * FROM st_group_product INNER JOIN st_unit ON st_unit.unit_id = st_group_product.gp_unit WHERE gp_status = 'Y'", db.conn);
            db.rdr = db.cmd.ExecuteReader();
            while (db.rdr.Read())
            {

                groupPoductModel gp = new groupPoductModel();
                gp.gp_id = db.rdr["gp_id"].ToString();
                gp.gp_code = db.rdr["gp_code"].ToString();
                gp.gp_name = db.rdr["gp_name"].ToString();
                gp.gp_unit = db.rdr["unit_name"].ToString();
                gp.gp_type_cal = db.rdr["gp_type_cal"].ToString();
                gp.gp_create_date = db.rdr["gp_create_date"].ToString();
                gp.gp_create_admin_id = db.rdr["gp_create_admin_id"].ToString();
                gp.gp_edit_date = db.rdr["gp_edit_date"].ToString();
                gp.gp_edit_admin_id = db.rdr["gp_edit_admin_id"].ToString();
                gp.gp_status = db.rdr["gp_status"].ToString();

                item.Add(gp);
            }
            db.rdr.Close();
            db.dbClosed();

            return item;
        }
    }
}
