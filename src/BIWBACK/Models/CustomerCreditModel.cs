using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BIWBACK.Models
{
    public class CustomerCreditModel
    {
        public string credit_id { get; set; }
        public string credit_money { get; set; }
        public string credit_ref_condition { get; set; }
        public string credit_ref_cus_id { get; set; }
        public string credit_create_date { get; set; }
        public string credit_create_admin_id { get; set; }
        public string credit_edit_date { get; set; }
        public string credit_edit_admin_id { get; set; }
        public string credit_status { get; set; }


        DatabaseClass db = new DatabaseClass();

        public void insert_credit()
        {

            string table = "st_customer_credit";
            string[] Columns = {   "credit_money",   "credit_ref_condition",    "credit_ref_cus_id",   "credit_create_date",  "credit_create_admin_id",  "credit_edit_date",   "credit_edit_admin_id" };
            string[] Values = {  credit_money ,   credit_ref_condition ,   credit_ref_cus_id , DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),  "1"  ,DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")   ,"1"  };
            db.insert_db(table, Columns, Values);

        }
        public void update_credit()
        {

            string table = "st_customer_credit";
            string[] Columns = { "credit_money", "credit_ref_condition", "credit_ref_cus_id","credit_edit_date", "credit_edit_admin_id" };
            string[] Values = {  credit_money, credit_ref_condition, credit_ref_cus_id,  DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), "1" };
            string where = "credit_id = '" + credit_id + "'";

            db.update_db(table, Columns, Values, where);

        }
        public void del_credit()
        {

            string table = "st_customer_credit";
            string[] Columns = { "credit_status" };
            string[] Values = { "N" };
            string where = "credit_id = '" + credit_id+ "'";

            db.update_db(table, Columns, Values, where);

        }
        public void select_credit(string where_)
        {

            string table = "st_customer_credit";
            string[] Columns = { "credit_id", "credit_money", "credit_ref_condition", "credit_ref_cus_id", "credit_create_date", "credit_create_admin_id", "credit_edit_date", "credit_edit_admin_id", "credit_status" };
            string join = "";
            string where = where_;
            string groupby = "";
            string orderby = "";

            List<string> result = db.select_db(Columns, table, join, where, groupby, orderby);
            credit_id = result[0];
            credit_money = result[1];
            credit_ref_condition = result[2];
            credit_ref_cus_id = result[3];
            credit_create_date = result[4];
            credit_create_admin_id = result[5];
            credit_edit_date = result[6];
            credit_edit_admin_id = result[7];
            credit_status = result[8];

        }
        public List<SelectListItem> drop_credit(string selected)
        {

            List<SelectListItem> item = new List<SelectListItem>();

            string table = "st_customer_credit";
            string where = "credit_status = 'Y'";
            string join = "";
            string groupby = "";
            string orderby = "";
            string text = "credit_money";
            string value = "credit_id";

            item = db.creat_dropdown(table, where, join, groupby, orderby, text, value, selected);

            return item;
        }
        public List<CustomerCreditModel> list_credit()
        {

            List<CustomerCreditModel> item = new List<CustomerCreditModel>();

            db.dbConnect();

            db.cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT * FROM st_customer_credit WHERE credit_status = 'Y'", db.conn);
            db.rdr = db.cmd.ExecuteReader();
            while (db.rdr.Read())
            {

                CustomerCreditModel cd = new CustomerCreditModel();
                cd.credit_id = db.rdr["credit_id"].ToString();
                cd.credit_money = db.rdr["credit_money"].ToString();
                cd.credit_ref_condition = db.rdr["credit_ref_condition"].ToString();
                cd.credit_ref_cus_id = db.rdr["credit_ref_cus_id"].ToString();
                cd.credit_create_date = db.rdr["credit_create_date"].ToString();
                cd.credit_create_admin_id = db.rdr["credit_create_admin_id"].ToString();
                cd.credit_edit_date = db.rdr["credit_edit_date"].ToString();
                cd.credit_edit_admin_id = db.rdr["credit_edit_admin_id"].ToString();
                cd.credit_status = db.rdr["credit_status"].ToString();

                item.Add(cd);
            }
            db.rdr.Close();
            db.dbClosed();

            return item;
        }
        //

    }
}
