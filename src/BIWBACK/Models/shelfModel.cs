using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace BIWBACK.Models
{
    public class shelfModel
    {

        public string shelf_id { get; set; }
        public string shelf_code { get; set; }
        public string shelf_ref_store { get; set; }
        public string shelf_name { get; set; }
        public string shelf_create_date { get; set; }
        public string shelf_create_admin_id { get; set; }
        public string shelf_edit_date { get; set; }
        public string shelf_edit_admin_id { get; set; }
        public string shelf_status { get; set; }
       

        //
        public string count_code { get; set; }
        public string store_name { get; set; }

        CultureInfo en = new CultureInfo("EN");
        CultureInfo th = new CultureInfo("TH");


        DatabaseClass db = new DatabaseClass();

        public void check_sh_code()
        {

            db.dbConnect();
            db.cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT COUNT(shelf_id) AS countCode FROM st_shelf WHERE shelf_code = '" + shelf_code + "'", db.conn);
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

            db.cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT COUNT(shelf_id) AS countShelf FROM st_shelf", db.conn);
            db.rdr = db.cmd.ExecuteReader();
            while (db.rdr.Read())
            {

                shelf_code = "A" + (Convert.ToInt32(db.rdr["countShelf"]) + 1).ToString("00");

            }
            db.dbClosed();

        }
        public void insert_shelf()
        {

            string table = "st_shelf";
            string[] Columns = { "shelf_code",  "shelf_ref_store", "shelf_name",  "shelf_create_date",   "shelf_create_admin_id",   "shelf_edit_date", "shelf_edit_admin_id"};
            string[] Values = {  shelf_code , shelf_ref_store, shelf_name, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", en),   "1" ,  DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss",en), "1" };
            db.insert_db(table, Columns, Values);

        }
        public void update_shelf()
        {

            string table = "st_shelf";
            string[] Columns = {  "shelf_ref_store", "shelf_name",  "shelf_edit_date", "shelf_edit_admin_id"};
            string[] Values = {  shelf_ref_store, shelf_name,  DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", en), "1" };
            string where = "shelf_id = '" + shelf_id + "'";

            db.update_db(table, Columns, Values, where);

        }
        public void del_shelf()
        {

            string table = "st_shelf";
            string[] Columns = { "shelf_status" };
            string[] Values = { "N" };
            string where = "shelf_id = '" + shelf_id + "'";

            db.update_db(table, Columns, Values, where);

        }
        public void select_shelf(string where_)
        {

            string table = "st_shelf";
            string[] Columns = { "shelf_id", "shelf_code", "shelf_ref_store", "shelf_name", "shelf_create_date", "shelf_create_admin_id", "shelf_edit_date", "shelf_edit_admin_id", "shelf_status" };
            string join = "";
            string where = where_;
            string groupby = "";
            string orderby = "";

            List<string> result = db.select_db(Columns, table, join, where, groupby, orderby);
            shelf_id = result[0];
            shelf_code = result[1];
            shelf_ref_store = result[2];
            shelf_name = result[3];
            shelf_create_date = result[4];
            shelf_create_admin_id = result[5];
            shelf_edit_date = result[6];
            shelf_edit_admin_id = result[7];
            shelf_status = result[8];

        }
        public List<SelectListItem> drop_shelf(string selected)
        {

            List<SelectListItem> item = new List<SelectListItem>();

            string table = "st_shelf";
            string where = "shelf_status = 'Y'";
            string join = "";
            string groupby = "";
            string orderby = "";
            string text = "shelf_name";
            string value = "shelf_id";

            item = db.creat_dropdown(table, where, join, groupby, orderby, text, value, selected);

            return item;
        }
        public List<shelfModel> list_shelf()
        {

            List<shelfModel> item = new List<shelfModel>();

            db.dbConnect();

            db.cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT * FROM st_shelf INNER JOIN st_store ON st_store.store_id = st_shelf.shelf_ref_store  WHERE shelf_status = 'Y'", db.conn);
            db.rdr = db.cmd.ExecuteReader();
            while (db.rdr.Read())
            {

                shelfModel sh = new shelfModel();

                sh.shelf_id = db.rdr["shelf_id"].ToString();
                sh.shelf_code = db.rdr["shelf_code"].ToString();
                sh.shelf_ref_store = db.rdr["shelf_ref_store"].ToString();
                sh.shelf_name = db.rdr["shelf_name"].ToString();
                sh.shelf_create_date = db.rdr["shelf_create_date"].ToString();
                sh.shelf_create_admin_id = db.rdr["shelf_create_admin_id"].ToString();
                sh.shelf_edit_date = db.rdr["shelf_edit_date"].ToString();
                sh.shelf_edit_admin_id = db.rdr["shelf_edit_admin_id"].ToString();
                sh.shelf_status = db.rdr["shelf_status"].ToString();
                sh.store_name = db.rdr["store_name"].ToString();

                item.Add(sh);
            }
            db.rdr.Close();
            db.dbClosed();

            return item;
        }
       
    }
}
