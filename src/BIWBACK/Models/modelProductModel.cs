using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace BIWBACK.Models
{
    public class modelProductModel
    {
        public string mp_id { get; set; }
        public string mp_name { get; set; }
        public string mp_create_date { get; set; }
        public string mp_create_admin_id { get; set; }
        public string mp_edit_date { get; set; }
        public string mp_edit_admin_id { get; set; }
        public string mp_status { get; set; }

        CultureInfo en = new CultureInfo("EN");
        CultureInfo th = new CultureInfo("TH");

        DatabaseClass db = new DatabaseClass();

        public void insert_mp()
        {

            string table = "st_model_product";
            string[] Columns = {  "mp_name", "mp_create_date",  "mp_create_admin_id",  "mp_edit_date",  "mp_edit_admin_id" };
            string[] Values = {   mp_name , DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss",en) , "1" , DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", en),  "1"  };
            db.insert_db(table, Columns, Values);

        }
        public void update_mp()
        {
            string table = "st_model_product";
            string[] Columns = {  "mp_name",  "mp_edit_date", "mp_edit_admin_id" };
            string[] Values = { mp_name,  DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", en), "1"};
            string where = "mp_id = '" + mp_id + "'";

            db.update_db(table, Columns, Values, where);

        }
        public void del_mp()
        {

            string table = "st_model_product";
            string[] Columns = { "mp_status" };
            string[] Values = { "N" };
            string where = "mp_id = '" + mp_id + "'";

            db.update_db(table, Columns, Values, where);

        }
        public void select_mp(string where_)
        {

            string table = "st_model_product";
            string[] Columns = { "mp_id", "mp_name", "mp_create_date", "mp_create_admin_id", "mp_edit_date", "mp_edit_admin_id", "mp_status" };
            string join = "";
            string where = where_;
            string groupby = "";
            string orderby = "";

            List<string> result = db.select_db(Columns, table, join, where, groupby, orderby);
            mp_id = result[0];
            mp_name = result[1];
            mp_create_date = result[2];
            mp_create_admin_id = result[3];
            mp_edit_date = result[4];
            mp_edit_admin_id = result[5];
            mp_status = result[6];

        }
        public List<SelectListItem> drop_mp(string selected)
        {

            List<SelectListItem> item = new List<SelectListItem>();

            string table = "st_model_product";
            string where = "mp_status = 'Y'";
            string join = "";
            string groupby = "";
            string orderby = "";
            string text = "mp_name";
            string value = "mp_id";

            item = db.creat_dropdown(table, where, join, groupby, orderby, text, value, selected);

            return item;
        }
        public List<modelProductModel> list_mp()
        {

            List<modelProductModel> item = new List<modelProductModel>();

            db.dbConnect();

            db.cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT * FROM st_model_product WHERE mp_status = 'Y'", db.conn);
            db.rdr = db.cmd.ExecuteReader();
            while (db.rdr.Read())
            {

                modelProductModel mp = new modelProductModel();
                mp.mp_id = db.rdr["mp_id"].ToString();
                mp.mp_name = db.rdr["mp_name"].ToString();
                mp.mp_create_date = db.rdr["mp_create_date"].ToString();
                mp.mp_create_admin_id = db.rdr["mp_create_admin_id"].ToString();
                mp.mp_edit_date = db.rdr["mp_edit_date"].ToString();
                mp.mp_edit_admin_id = db.rdr["mp_edit_admin_id"].ToString();
                mp.mp_status = db.rdr["mp_status"].ToString();

                item.Add(mp);
            }
            db.rdr.Close();
            db.dbClosed();

            return item;
        }
    }
}
