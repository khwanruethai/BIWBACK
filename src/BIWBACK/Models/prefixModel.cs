using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BIWBACK.Models
{
    public class prefixModel
    {
        public string prefix_id { get; set; }
        public string prefix_name { get; set; }
        public string prefix_ending { get; set; }
        public string prefix_create_date { get; set; }
        public string prefix_create_admin_id { get; set; }
        public string prefix_edit_date { get; set; }
        public string prefix_edit_admin_id { get; set; }
        public string prefix_status { get; set; }

        DatabaseClass db = new DatabaseClass();

        public void insert_prefix()
        {

            string table = "st_prefix";
            string[] Columns = {  "prefix_name", "prefix_ending",   "prefix_create_date" , "prefix_create_admin_id",  "prefix_edit_date",    "prefix_edit_admin_id"};
            string[] Values = { prefix_name, prefix_ending, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), "1", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),    "1" };
            db.insert_db(table, Columns, Values);

        }
        public void update_prefix()
        {

            string table = "st_prefix";
            string[] Columns = {  "prefix_name", "prefix_ending",  "prefix_create_admin_id", "prefix_edit_date", "prefix_edit_admin_id" };
            string[] Values = { prefix_name, prefix_ending, "1", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), "1" };
            string where = "prefix_id = '" + prefix_id + "'";

            db.update_db(table, Columns, Values, where);

        }
        public void del_prefix()
        {

            string table = "st_prefix";
            string[] Columns = { "prefix_status" };
            string[] Values = { "N" };
            string where = "prefix_id = '" + prefix_id + "'";

            db.update_db(table, Columns, Values, where);

        }
        public void select_prefix(string where_)
        {

            string table = "st_prefix";
            string[] Columns = { "prefix_id", "prefix_name", "prefix_ending", "prefix_create_date",  "prefix_create_admin_id", "prefix_edit_date", "prefix_edit_admin_id" , "prefix_status"};
            string join = "";
            string where = where_;
            string groupby = "";
            string orderby = "";

            List<string> result = db.select_db(Columns, table, join, where, groupby, orderby);

            prefix_id = result[0];
            prefix_name = result[1];
            prefix_ending = result[2];
            prefix_create_date = result[3];
            prefix_create_admin_id = result[4];
            prefix_edit_date = result[5];
            prefix_edit_admin_id = result[6];
            prefix_status = result[7];
        }
        public List<SelectListItem> drop_prefix(string selected)
        {

            List<SelectListItem> item = new List<SelectListItem>();

            string table = "st_prefix";
            string where = "prefix_status = 'Y'";
            string join = "";
            string groupby = "";
            string orderby = "";
            string text = "prefix_name";
            string value = "prefix_id";

            item = db.creat_dropdown(table, where, join, groupby, orderby, text, value, selected);

            return item;
        }
        public List<prefixModel> list_prefix()
        {

            List<prefixModel> item = new List<prefixModel>();

            db.dbConnect();

            db.cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT * FROM st_prefix WHERE prefix_status = 'Y'", db.conn);
            db.rdr = db.cmd.ExecuteReader();
            while (db.rdr.Read())
            {

                prefixModel px = new prefixModel();

                px.prefix_id = db.rdr["prefix_id"].ToString();
                px.prefix_name = db.rdr["prefix_name"].ToString();

                if (string.IsNullOrEmpty(db.rdr["prefix_ending"].ToString()) == true)
                {


                    px.prefix_ending = "";
                }
                else {


                    px.prefix_ending = db.rdr["prefix_ending"].ToString();
                }

                px.prefix_create_date = db.rdr["prefix_create_date"].ToString();
                px.prefix_create_admin_id = db.rdr["prefix_create_admin_id"].ToString();
                px.prefix_edit_date = db.rdr["prefix_edit_date"].ToString();
                px.prefix_edit_admin_id = db.rdr["prefix_edit_admin_id"].ToString();
                px.prefix_status = db.rdr["prefix_status"].ToString();

                item.Add(px);
            }
            db.rdr.Close();
            db.dbClosed();

            return item;
        }
    }
}
