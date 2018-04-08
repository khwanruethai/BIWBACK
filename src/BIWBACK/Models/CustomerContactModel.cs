using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BIWBACK.Models
{
    public class CustomerContactModel
    {
        public string ct_id { get; set; }
        public string ct_tel { get; set; }
        public string ct_fax { get; set; }
        public string ct_email { get; set; }
        public string ct_web { get; set; }
        public string ct_ref_cus_id { get; set; }
        public string ct_create_date { get; set; }
        public string ct_create_admin_id { get; set; }
        public string ct_edit_date { get; set; }
        public string ct_edit_admin_id { get; set; }
        public string ct_status { get; set; }

        DatabaseClass db = new DatabaseClass();

        public void insert_contact()
        {

            string table = "st_customer_contact";
            string[] Columns = {   "ct_tel",  "ct_fax",  "ct_email",    "ct_web",  "ct_ref_cus_id",   "ct_create_date",  "ct_create_admin_id",  "ct_edit_date",    "ct_edit_admin_id"  };
            string[] Values = {   ct_tel,  ct_fax , ct_email  ,  ct_web , ct_ref_cus_id  , DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), "1" , DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") ,   "1"   };
            db.insert_db(table, Columns, Values);

        }
        public void update_contact()
        {

            string table = "st_customer_contact";
            string[] Columns = { "ct_tel", "ct_fax", "ct_email", "ct_web", "ct_ref_cus_id", "ct_edit_date", "ct_edit_admin_id" };
            string[] Values = {ct_tel, ct_fax, ct_email, ct_web, ct_ref_cus_id, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), "1" };
            string where = "ct_id = '" + ct_id + "'";

            db.update_db(table, Columns, Values, where);

        }
        public void del_contact()
        {

            string table = "st_customer_contact";
            string[] Columns = { "ct_status" };
            string[] Values = { "N" };
            string where = "ct_id = '" + ct_id + "'";

            db.update_db(table, Columns, Values, where);

        }
        public void select_contact(string where_)
        {

            string table = "st_customer_contact";
            string[] Columns = { "ct_id", "ct_tel", "ct_fax", "ct_email", "ct_web", "ct_ref_cus_id", "ct_create_date", "ct_create_admin_id", "ct_edit_date", "ct_edit_admin_id", "ct_status" };
            string join = "";
            string where = where_;
            string groupby = "";
            string orderby = "";

            List<string> result = db.select_db(Columns, table, join, where, groupby, orderby);
            ct_id = result[0];
            ct_tel = result[1];
            ct_fax = result[2];
            ct_email = result[3];
            ct_web = result[4];
            ct_ref_cus_id = result[5];
            ct_create_date = result[6];
            ct_create_admin_id = result[7];
            ct_edit_date = result[8];
            ct_edit_admin_id = result[9];
            ct_status = result[10];

        }
        public List<SelectListItem> drop_contact(string selected)
        {

            List<SelectListItem> item = new List<SelectListItem>();

            string table = "st_customer_contact";
            string where = "ct_status = 'Y'";
            string join = "";
            string groupby = "";
            string orderby = "";
            string text = "ct_tel";
            string value = "ct_id";

            item = db.creat_dropdown(table, where, join, groupby, orderby, text, value, selected);

            return item;
        }
        public List<CustomerContactModel> list_contact()
        {

            List<CustomerContactModel> item = new List<CustomerContactModel>();

            db.dbConnect();

            db.cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT * FROM st_customer_contact WHERE ct_status = 'Y'", db.conn);
            db.rdr = db.cmd.ExecuteReader();
            while (db.rdr.Read())
            {

                CustomerContactModel ct = new CustomerContactModel();
               ct.ct_id = db.rdr["ct_id"].ToString();
               ct.ct_tel = db.rdr["ct_tel"].ToString();
               ct.ct_fax = db.rdr["ct_fax"].ToString();
               ct.ct_email = db.rdr["ct_email"].ToString();
               ct.ct_web = db.rdr["ct_web"].ToString();
               ct.ct_ref_cus_id = db.rdr["ct_ref_cus_id"].ToString();
               ct.ct_create_date = db.rdr["ct_create_date"].ToString();
               ct.ct_create_admin_id = db.rdr["ct_create_admin_id"].ToString();
               ct.ct_edit_date = db.rdr["ct_edit_date"].ToString();
               ct.ct_edit_admin_id = db.rdr["ct_edit_admin_id"].ToString();
               ct.ct_status = db.rdr["ct_status"].ToString();


                item.Add(ct);
            }
            db.rdr.Close();
            db.dbClosed();

            return item;
        }
    }
}
