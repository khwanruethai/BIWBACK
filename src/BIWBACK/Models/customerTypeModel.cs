using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace BIWBACK.Models
{
    public class customerTypeModel
    {
    public string  type_id { get; set; }
    public string  type_code { get; set; }
    public string  type_name { get; set; }
    public string  type_vat { get;set; }
    public string  type_pay { get; set; }
    public string  type_discount { get; set; }
    public string  type_create_date { get; set; }
    public string  type_create_admin_id { get; set; }
    public string  type_edit_date { get; set; }
    public string  type_edit_admin_id { get; set; }
    public string  type_status { get; set; }

        DatabaseClass db = new DatabaseClass();

        public void selectCode() {

            db.dbConnect();
            db.cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT COUNT(type_code) AS code FROM st_customer_type WHERE type_status = 'Y'", db.conn);
            db.rdr = db.cmd.ExecuteReader();
            while (db.rdr.Read()) {

                type_code = db.rdr["code"].ToString();
            }
            db.rdr.Close();
            db.dbClosed();

            type_code = (Convert.ToDouble(type_code) + 1).ToString("00");
        }
        public void insert_cus_type()
        {

            string table = "st_customer_type";
            string[] Columns = {  "type_code", "type_name", "type_vat", "type_pay", "type_discount", "type_create_date", "type_create_admin_id", "type_edit_date", "type_edit_admin_id" };
            string[] Values = {  type_code,   type_name ,  type_vat  ,  type_pay  ,  type_discount, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),   "1",    DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")  ,"1"  };

            db.insert_db(table, Columns, Values);

        }
        public void select_cus_type(string where_ = "")
        {

            string[] Columns = { "type_id", "type_code", "type_name", "type_vat", "type_pay", "type_discount", "type_create_date", "type_create_admin_id", "type_edit_date", "type_edit_admin_id", "type_status" };
            string table = "st_customer_type";
            string join = "";
            string where = where_;
            string groupby = "";
            string orderby = "";

            List<string> result = db.select_db(Columns, table, join, where, groupby, orderby);

            type_id = result[0];
            type_code = result[1];
            type_name = result[2];
            type_vat = result[3];
            type_pay = result[4];
            type_discount = result[5];
            type_create_date = result[6];
            type_create_admin_id = result[7];
            type_edit_date = result[8];
            type_edit_admin_id = result[9];
            type_status = result[10];

        }
        public void update_cus_type()
        {


            string table = "st_customer_type";
            string[] Columns = {  "type_code", "type_name", "type_vat", "type_pay", "type_discount",  "type_edit_date", "type_edit_admin_id"};
            string[] Values = {  type_code, type_name, type_vat, type_pay, type_discount,  DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), "1"  };
            string where = "type_id = '" + type_id + "'";

            db.update_db(table, Columns, Values, where);

        }
        public List<customerTypeModel> list_cus_type()
        {

            List<customerTypeModel> item = new List<customerTypeModel>();

            db.dbConnect();

            db.cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT * FROM st_customer_type WHERE type_status = 'Y'", db.conn);
            db.rdr = db.cmd.ExecuteReader();
            while (db.rdr.Read())
            {

                customerTypeModel type = new customerTypeModel();
                type.type_id = db.rdr["type_id"].ToString();
                type.type_code = db.rdr["type_code"].ToString();
                type.type_name = db.rdr["type_name"].ToString();
                type.type_vat = db.rdr["type_vat"].ToString();
                type.type_pay = db.rdr["type_pay"].ToString();
                type.type_discount = db.rdr["type_discount"].ToString();
                type.type_create_date = db.rdr["type_create_date"].ToString();
                type.type_create_admin_id = db.rdr["type_create_admin_id"].ToString();
                type.type_edit_date = db.rdr["type_edit_date"].ToString();
                type.type_edit_admin_id = db.rdr["type_edit_admin_id"].ToString();
                type.type_status = db.rdr["type_status"].ToString();

                item.Add(type);
            }

            db.dbClosed();

            return item;
        }
        public void del_cus_type()
        {

            string table = "st_customer_type";
            string[] Columns = { "type_status" };
            string[] Values = { "N" };
            string where = "type_id = '" + type_id + "'";

            db.update_db(table, Columns, Values, where);

        }
        public List<SelectListItem> drop_cus_type(string selected = null)
        {

            List<SelectListItem> item = new List<SelectListItem>();

            string table = "st_customer_type";
            string where = "";
            string join = "";
            string groupby = "";
            string orderby = "";
            string text = "type_name";
            string value = "type_id";

            item = db.creat_dropdown(table, where, join, groupby, orderby, text, value, selected);

            return item;
        }
        public List<SelectListItem> drop_cus_type_code(string selected = null)
        {

            List<SelectListItem> item = new List<SelectListItem>();

            string table = "st_customer_type";
            string where = "";
            string join = "";
            string groupby = "";
            string orderby = "";
            string text = "type_name";
            string value = "type_id";

            item = db.creat_dropdown(table, where, join, groupby, orderby, text, value, selected);

            return item;
        }
    }
}
