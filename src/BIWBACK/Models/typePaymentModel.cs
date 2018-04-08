using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BIWBACK.Models
{
    public class typePaymentModel
    {
        public string  tp_id { get; set; }
        public string  tp_name {get; set;}
        public string  tp_create_date { get; set; }
        public string  tp_create_admin_id { get; set; }
        public string  tp_edit_date { get; set; }
        public string  tp_edit_admin_id { get; set; }
        public string  tp_status { get; set; }

        DatabaseClass db = new DatabaseClass();

        public void insert_type_payment()
        {

            string table = "st_type_payment";
            string[] Columns = { "tp_name", "tp_create_date",  "tp_create_admin_id",  "tp_edit_date", "tp_edit_admin_id" };
            string[] Values = {   tp_name, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),  "1" , DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") ,   "1" };
            db.insert_db(table, Columns, Values);

        }
        public void update_type_payment()
        {

            string table = "st_type_payment";
            string[] Columns = { "tp_name", "tp_edit_date", "tp_edit_admin_id" };
            string[] Values = {  tp_name, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), "1" };
            string where = "tp_id = '" + tp_id + "'";

            db.update_db(table, Columns, Values, where);

        }
        public void del_type_payment()
        {

            string table = "st_type_payment";
            string[] Columns = { "tp_status" };
            string[] Values = { "N" };
            string where = "tp_id = '" + tp_id + "'";

            db.update_db(table, Columns, Values, where);

        }
        public void select_type_payment(string where_)
        {

            string table = "st_type_payment";
            string[] Columns = { "tp_id", "tp_name", "tp_create_date", "tp_create_admin_id", "tp_edit_date", "tp_edit_admin_id", "tp_status" };
            string join = "";
            string where = where_;
            string groupby = "";
            string orderby = "";

            List<string> result = db.select_db(Columns, table, join, where, groupby, orderby);

            tp_id = result[0];
            tp_name = result[1];
            tp_create_date = result[2];
            tp_create_admin_id = result[3];
            tp_edit_date = result[4];
            tp_edit_admin_id = result[5];
            tp_status = result[6];

        }
        public List<SelectListItem> drop_type_payment(string selected)
        {

            List<SelectListItem> item = new List<SelectListItem>();

            string table = "st_type_payment";
            string where = "tp_status = 'Y'";
            string join = "";
            string groupby = "";
            string orderby = "";
            string text = "tp_name";
            string value = "tp_id";

            item = db.creat_dropdown(table, where, join, groupby, orderby, text, value, selected);

            return item;
        }
        public List<typePaymentModel> list_type_payment()
        {

            List<typePaymentModel> item = new List<typePaymentModel>();

            db.dbConnect();

            db.cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT * FROM st_type_payment WHERE tp_status = 'Y'", db.conn);
            db.rdr = db.cmd.ExecuteReader();
            while (db.rdr.Read())
            {

                typePaymentModel tp = new typePaymentModel();
                tp.tp_id = db.rdr["tp_id"].ToString();
                tp.tp_name = db.rdr["tp_name"].ToString();
                tp.tp_create_date = db.rdr["tp_create_date"].ToString();
                tp.tp_create_admin_id = db.rdr["tp_create_admin_id"].ToString();
                tp.tp_edit_date = db.rdr["tp_edit_date"].ToString();
                tp.tp_edit_admin_id = db.rdr["tp_edit_admin_id"].ToString();
                tp.tp_status = db.rdr["tp_status"].ToString();
                item.Add(tp);
            }
            db.rdr.Close();
            db.dbClosed();

            return item;
        }


    }
}
