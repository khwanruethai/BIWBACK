using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BIWBACK.Models
{
    public class CustomerLineSaleModel
    {
        public string   cs_id { get; set; }
        public string   cs_ref_line_id { get; set; }
        public string   cs_sale_name { get; set; }
        public string   cs_ref_cus_id { get; set; }
        public string   cs_create_date { get; set; }
        public string   cs_create_admin_id { get; set; }
        public string   cs_edit_date { get; set; }
        public string   cs_edit_admin_id { get; set; }
        public string   cs_status { get; set; }


        DatabaseClass db = new DatabaseClass();

        public void insert_cus_line()
        {

            string table = "st_customer_line_sale";
            string[] Columns = {  "cs_ref_line_id", "cs_sale_name", "cs_ref_cus_id",  "cs_create_date",  "cs_create_admin_id", "cs_edit_date",  "cs_edit_admin_id"   };
            string[] Values = {    cs_ref_line_id , cs_sale_name ,   cs_ref_cus_id, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), "1",  DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") ,   "1"   };
            db.insert_db(table, Columns, Values);

        }
        public void update_cus_line()
        {

            string table = "st_customer_line_sale";
            string[] Columns = {  "cs_ref_line_id", "cs_sale_name", "cs_ref_cus_id", "cs_edit_date", "cs_edit_admin_id"};
            string[] Values = {  cs_ref_line_id, cs_sale_name, cs_ref_cus_id,  DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), "1" };
            string where = "cs_id = '" + cs_id + "'";

            db.update_db(table, Columns, Values, where);

        }
        public void del_cus_line()
        {

            string table = "st_customer_line_sale";
            string[] Columns = { "cs_status" };
            string[] Values = { "N" };
            string where = "cs_id = '" + cs_id + "'";

            db.update_db(table, Columns, Values, where);

        }
        public void select_cus_line(string where_)
        {

            string table = "st_customer_line_sale";
            string[] Columns = { "cs_id", "cs_ref_line_id", "cs_sale_name", "cs_ref_cus_id", "cs_create_date", "cs_create_admin_id", "cs_edit_date", "cs_edit_admin_id", "cs_status" };
            string join = "";
            string where = where_;
            string groupby = "";
            string orderby = "";

            List<string> result = db.select_db(Columns, table, join, where, groupby, orderby);

            cs_id = result[0];
            cs_ref_line_id = result[1];
            cs_sale_name = result[2];
            cs_ref_cus_id = result[3];
            cs_create_date = result[4];
            cs_create_admin_id = result[5];
            cs_edit_date = result[6];
            cs_edit_admin_id = result[7];
            cs_status = result[8];

        }
        public List<SelectListItem> drop_cus_line(string selected)
        {

            List<SelectListItem> item = new List<SelectListItem>();

            string table = "st_customer_line_sale";
            string where = "cs_status = 'Y'";
            string join = "";
            string groupby = "";
            string orderby = "";
            string text = "cs_sale_name";
            string value = "cs_id";

            item = db.creat_dropdown(table, where, join, groupby, orderby, text, value, selected);

            return item;
        }
        public List<CustomerLineSaleModel> list_cus_line()
        {

            List<CustomerLineSaleModel> item = new List<CustomerLineSaleModel>();

            db.dbConnect();

            db.cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT * FROM st_customer_line_sale WHERE cs_status = 'Y'", db.conn);
            db.rdr = db.cmd.ExecuteReader();
            while (db.rdr.Read())
            {

                CustomerLineSaleModel cs = new CustomerLineSaleModel();

                cs.cs_id = db.rdr["cs_id"].ToString();
                cs.cs_ref_line_id = db.rdr["cs_ref_line_id"].ToString();
                cs.cs_sale_name = db.rdr["cs_sale_name"].ToString();
                cs.cs_ref_cus_id = db.rdr["cs_ref_cus_id"].ToString();
                cs.cs_create_date = db.rdr["cs_create_date"].ToString();
                cs.cs_create_admin_id = db.rdr["cs_create_admin_id"].ToString();
                cs.cs_edit_date = db.rdr["cs_edit_date"].ToString();
                cs.cs_edit_admin_id = db.rdr["cs_edit_admin_id"].ToString();
                cs.cs_status = db.rdr["cs_status"].ToString();


                item.Add(cs);
            }
            db.rdr.Close();
            db.dbClosed();

            return item;
        }

    }
}
