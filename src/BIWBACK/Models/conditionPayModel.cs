using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BIWBACK.Models
{
    public class conditionPayModel
    {

        public string cdt_id { get; set; }
        public string cdt_name { get; set; }
        public string cdt_ref_typ_pay { get; set; }
        public string cdt_num { get; set; }
        public string cdt_type { get; set; }
        public string cdt_create_date { get; set; }
        public string cdt_create_admin_id { get; set; }
        public string cdt_edit_date { get; set; }
        public string cdt_edit_admin_id { get; set; }
        public string cdt_status { get; set; }

        DatabaseClass db = new DatabaseClass();

        public void insert_con_pay()
        {

            string table = "st_condition_pay";
            string[] Columns = {"cdt_name","cdt_ref_typ_pay", "cdt_num", "cdt_type", "cdt_create_date", "cdt_create_admin_id", "cdt_edit_date", "cdt_edit_admin_id" };
            string[] Values = {cdt_name ,   cdt_ref_typ_pay, cdt_num, cdt_type, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), "1", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),   "1" };
            db.insert_db(table, Columns, Values);

        }
        public void update_con_pay()
        {

            string table = "st_condition_pay";
            string[] Columns = {  "cdt_name", "cdt_ref_typ_pay", "cdt_num", "cdt_type",  "cdt_edit_date", "cdt_edit_admin_id"};
            string[] Values = {  cdt_name, cdt_ref_typ_pay, cdt_num, cdt_type,  DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), "1" };
            string where = "cdt_id = '" + cdt_id + "'";

            db.update_db(table, Columns, Values, where);

        }
        public void del_con_pay()
        {

            string table = "st_condition_pay";
            string[] Columns = { "cdt_status" };
            string[] Values = { "N" };
            string where = "cdt_id = '" + cdt_id + "'";

            db.update_db(table, Columns, Values, where);

        }
        public void select_con_pay(string where_)
        {

            string table = "st_condition_pay";
            string[] Columns = { "cdt_id", "cdt_name", "cdt_ref_typ_pay", "cdt_num", "cdt_type", "cdt_create_date", "cdt_create_admin_id", "cdt_edit_date", "cdt_edit_admin_id", "cdt_status" };
            string join = "";
            string where = where_;
            string groupby = "";
            string orderby = "";

            List<string> result = db.select_db(Columns, table, join, where, groupby, orderby);
            cdt_id = result[0];
            cdt_name = result[1];
            cdt_ref_typ_pay = result[2];
            cdt_num = result[3];
            cdt_type = result[4];
            cdt_create_date = result[5];
            cdt_create_admin_id = result[6];
            cdt_edit_date = result[7];
            cdt_edit_admin_id = result[8];
            cdt_status = result[9];

        }
        public List<SelectListItem> drop_con_pay(string selected)
        {

            List<SelectListItem> item = new List<SelectListItem>();

            string table = "st_condition_pay";
            string where = "cdt_status = 'Y'";
            string join = "";
            string groupby = "";
            string orderby = "";
            string text = "cdt_name";
            string value = "cdt_id";

            item = db.creat_dropdown(table, where, join, groupby, orderby, text, value, selected);

            return item;
        }
        public List<conditionPayModel> list_con_pay()
        {

            List<conditionPayModel> item = new List<conditionPayModel>();

            db.dbConnect();

            db.cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT * FROM st_condition_pay WHERE cdt_status = 'Y'", db.conn);
            db.rdr = db.cmd.ExecuteReader();
            while (db.rdr.Read())
            {

                conditionPayModel cp = new conditionPayModel();

                cp.cdt_id = db.rdr["cdt_id"].ToString();
                cp.cdt_name = db.rdr["cdt_name"].ToString();
                cp.cdt_ref_typ_pay = db.rdr["cdt_ref_typ_pay"].ToString();
                cp.cdt_num = db.rdr["cdt_num"].ToString();
                cp.cdt_type = db.rdr["cdt_type"].ToString();
                cp.cdt_create_date = db.rdr["cdt_create_date"].ToString();
                cp.cdt_create_admin_id = db.rdr["cdt_create_admin_id"].ToString();
                cp.cdt_edit_date = db.rdr["cdt_edit_date"].ToString();
                cp.cdt_edit_admin_id = db.rdr["cdt_edit_admin_id"].ToString();
                cp.cdt_status = db.rdr["cdt_status"].ToString();

                item.Add(cp);
            }
            db.rdr.Close();
            db.dbClosed();

            return item;
        }
    }
}
