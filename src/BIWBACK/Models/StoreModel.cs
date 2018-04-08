using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace BIWBACK.Models
{
    public class StoreModel
    {
        public string store_id { get; set; }
        public string store_code { get; set; }
        public string store_name { get; set; }
        public string store_create_date { get; set; }
        public string store_create_admin_id { get; set; }
        public string store_edit_date { get; set; }
        public string store_edit_admin_id { get; set; }
        public string store_status { get; set; }

        //
        public string count_code { get; set; }

        DatabaseClass db = new DatabaseClass();
        CultureInfo th = new CultureInfo("TH");
        CultureInfo en = new CultureInfo("EN");

        public void check_st_code()
        {

            db.dbConnect();
            db.cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT COUNT(store_id) AS countCode FROM st_store WHERE store_code = '" + store_code + "'", db.conn);
            db.rdr = db.cmd.ExecuteReader();
            while (db.rdr.Read())
            {


                count_code = db.rdr["countCode"].ToString();
            }

            db.dbClosed();
        }

        public void create_code()
        {

            db.dbConnect();

            db.cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT COUNT(store_id) AS countStore FROM st_store ", db.conn);
            db.rdr = db.cmd.ExecuteReader();
            while (db.rdr.Read())
            {

                store_code = "A" + (Convert.ToInt32(db.rdr["countStore"]) + 1).ToString("00");

            }
            db.dbClosed();

        }
        public void insert_store()
        {

            string table = "st_store";
            string[] Columns = {  "store_code",  "store_name",  "store_create_date",  "store_create_admin_id",   "store_edit_date", "store_edit_admin_id"  };
            string[] Values = {    store_code , store_name , DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", en), "1",   DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", en) ,"1" };
            db.insert_db(table, Columns, Values);

        }
        public void update_store()
        {

            string table = "st_store";
            string[] Columns = {  "store_name",  "store_edit_date", "store_edit_admin_id" };
            string[] Values = {   store_name, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", en), "1" };
            string where = "store_id = '" + store_id + "'";

            db.update_db(table, Columns, Values, where);

        }
        public void del_store()
        {

            string table = "st_store";
            string[] Columns = { "store_status" };
            string[] Values = { "N" };
            string where = "store_id = '" + store_id + "'";

            db.update_db(table, Columns, Values, where);

        }
        public void select_store(string where_)
        {

            string table = "st_store";
            string[] Columns = { "store_id", "store_code", "store_name", "store_create_date", "store_create_admin_id", "store_edit_date", "store_edit_admin_id", "store_status" };
            string join = "";
            string where = where_;
            string groupby = "";
            string orderby = "";

            List<string> result = db.select_db(Columns, table, join, where, groupby, orderby);
            store_id = result[0];
            store_code = result[1];
            store_name = result[2];
            store_create_date = result[3];
            store_create_admin_id = result[4];
            store_edit_date = result[5];
            store_edit_admin_id = result[6];
            store_status = result[7];

        }
        public List<SelectListItem> drop_store(string selected)
        {

            List<SelectListItem> item = new List<SelectListItem>();

            string table = "st_store";
            string where = "store_status = 'Y'";
            string join = "";
            string groupby = "";
            string orderby = "";
            string text = "store_name";
            string value = "store_id";

            item = db.creat_dropdown(table, where, join, groupby, orderby, text, value, selected);

            return item;
        }
        public List<StoreModel> list_store()
        {

            List<StoreModel> item = new List<StoreModel>();

            db.dbConnect();

            db.cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT * FROM st_store WHERE store_status = 'Y'", db.conn);
            db.rdr = db.cmd.ExecuteReader();
            while (db.rdr.Read())
            {

                StoreModel st = new StoreModel();
                st.store_id = db.rdr["store_id"].ToString();
                st.store_code = db.rdr["store_code"].ToString();
                st.store_name = db.rdr["store_name"].ToString();
                st.store_create_date = db.rdr["store_create_date"].ToString();
                st.store_create_admin_id = db.rdr["store_create_admin_id"].ToString();
                st.store_edit_date = db.rdr["store_edit_date"].ToString();
                st.store_edit_admin_id = db.rdr["store_edit_admin_id"].ToString();
                st.store_status = db.rdr["store_status"].ToString();

                item.Add(st);
            }
            db.rdr.Close();
            db.dbClosed();

            return item;
        }
    }
}
