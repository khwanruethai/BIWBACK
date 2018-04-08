using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;


namespace BIWBACK.Models
{
    public class positionModel
    {
       public string ps_id { get; set; }
       public string ps_code { get; set; }
       public string ps_name { get; set; }
       public string ps_create_date { get; set; }
       public string ps_create_admin_id { get; set; }
       public string ps_edit_date { get; set; }
       public string ps_edit_admin_id { get; set; }

        DatabaseClass db = new DatabaseClass();

        CultureInfo th = new CultureInfo("th-TH");

        public void insert_position() {

            string table = "st_position";
            string[] Columns = {  "ps_code", "ps_name", "ps_create_date", "ps_create_admin_id", "ps_edit_date", "ps_edit_admin_id" };
            string[] Values = { ps_code, ps_name, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),  "1" , DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),   "1" };

            db.insert_db(table, Columns, Values);

        }
        public void select_position(string where_ = "") {

            string[] Columns = { "ps_id", "ps_code", "ps_name", "ps_create_date", "ps_create_admin_id", "ps_edit_date", "ps_edit_admin_id" };
            string table = "st_position";
            string join = "";
            string where = where_;
            string groupby = "";
            string orderby = "";

          List<string> result =  db.select_db(Columns, table, join, where, groupby, orderby);

            ps_id = result[0];
            ps_code = result[1];
            ps_name = result[2];
            ps_create_date = result[3];
            ps_create_admin_id = result[4];
            ps_edit_date = result[5];
            ps_edit_admin_id = result[6];

        }
        public void update_position() {

            
            string table = "st_position";
            string[] Columns = { "ps_code", "ps_name",  "ps_edit_date", "ps_edit_admin_id" };
            string[] Values = { ps_code, ps_name, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), "1" };
            string where = "ps_id = '"+ps_id+"'";

            db.update_db(table, Columns, Values, where);
            
        }
        public List<positionModel> list_position() {

            List<positionModel> item = new List<positionModel>();

            db.dbConnect();

            db.cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT * FROM st_position WHERE ps_status = 'Y'", db.conn);
            db.rdr = db.cmd.ExecuteReader();
            while (db.rdr.Read()) {

                positionModel ps = new positionModel();
                ps.ps_id = db.rdr["ps_id"].ToString();
                ps.ps_code = db.rdr["ps_code"].ToString();
                ps.ps_name = db.rdr["ps_name"].ToString();
                ps.ps_create_date = db.rdr["ps_create_date"].ToString();
                ps.ps_create_admin_id = db.rdr["ps_create_admin_id"].ToString();
                ps.ps_edit_date = db.rdr["ps_edit_date"].ToString();
                ps.ps_edit_admin_id = db.rdr["ps_edit_admin_id"].ToString();
                item.Add(ps);
            }
            
            db.dbClosed();

            return item;
        }
        public void del_position() {
            
            string table = "st_position";
            string[] Columns = { "ps_status"};
            string[] Values = { "N"  };
            string where = "ps_id = '" + ps_id + "'";

            db.update_db(table, Columns, Values, where);

        }
        public List<SelectListItem> drop_position(string selected = null)
        {

            List<SelectListItem> item = new List<SelectListItem>();

            string table = "st_position";
            string where = "";
            string join = "";
            string groupby = "";
            string orderby = "";
            string text = "ps_name";
            string value = "ps_id";

            item = db.creat_dropdown(table, where, join, groupby, orderby, text, value, selected);

            return item;
        }
    }
}
