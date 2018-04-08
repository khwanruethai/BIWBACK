using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BIWBACK.Models
{
    public class CustomerTransportModel
    {
        public string   at_id { get; set; }
        public string   at_num { get; set; }
        public string   at_alley { get; set; }
        public string   at_road { get; set; }
        public string   at_district { get; set; }
        public string   at_amphur { get; set; }
        public string   at_province { get; set; }
        public string   at_postcode { get; set; }
        public string   at_ref_cus_id { get; set; }
        public string   at_create_date { get; set; }
        public string   at_create_admin_id { get; set; }
        public string   at_edit_date { get; set; }
        public string   at_edit_admin_id { get; set; }
        public string   at_status { get; set; }
        public string   at_customer_name { get; set; }

        DatabaseClass db = new DatabaseClass();

        public void insert_cus_tran()
        {

            string table = "st_customer_transport";
            string[] Columns = { "at_num",  "at_alley", "at_road", "at_district", "at_amphur", "at_province", "at_postcode", "at_ref_cus_id",   "at_create_date",  "at_create_admin_id",  "at_edit_date",  "at_edit_admin_id", "at_customer_name" };
            string[] Values = {   at_num  ,at_alley , at_road, at_district ,at_amphur  , at_province, at_postcode ,at_ref_cus_id, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), "1",  DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")  ,  "1" , at_customer_name };
            db.insert_db(table, Columns, Values);

        }
        public void update_cus_tran()
        {

            string table = "st_customer_transport";
            string[] Columns = {  "at_num", "at_alley", "at_road", "at_district", "at_amphur", "at_province", "at_postcode", "at_ref_cus_id",  "at_edit_date", "at_edit_admin_id" , "at_customer_name" };
            string[] Values = { at_num, at_alley, at_road, at_district, at_amphur, at_province, at_postcode, at_ref_cus_id, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), "1", at_customer_name };
            string where = "at_id = '" + at_id + "'";

            db.update_db(table, Columns, Values, where);

        }
        public void del_cus_tran()
        {

            string table = "st_customer_transport";
            string[] Columns = { "at_status" };
            string[] Values = { "N" };
            string where = "at_id = '" + at_id + "'";

            db.update_db(table, Columns, Values, where);

        }
        public void select_cus_tran(string where_)
        {

            string table = "st_customer_transport";
            string[] Columns = { "at_id", "at_num", "at_alley", "at_road", "at_district", "at_amphur", "at_province", "at_postcode", "at_ref_cus_id", "at_create_date", "at_create_admin_id", "at_edit_date", "at_edit_admin_id", "at_status" , "at_customer_name" };
            string join = "";
            string where = where_;
            string groupby = "";
            string orderby = "";

            List<string> result = db.select_db(Columns, table, join, where, groupby, orderby);
            at_id = result[0];
            at_num = result[1];
            at_alley = result[2];
            at_road = result[3];
            at_district = result[4];
            at_amphur = result[5];
            at_province = result[6];
            at_postcode = result[7];
            at_ref_cus_id = result[8];
            at_create_date = result[9];
            at_create_admin_id = result[10];
            at_edit_date = result[11];
            at_edit_admin_id = result[12];
            at_status = result[13];
            at_customer_name = result[14];

        }
        public List<SelectListItem> drop_cus_tran(string selected)
        {

            List<SelectListItem> item = new List<SelectListItem>();

            string table = "st_unit";
            string where = "unit_status = 'Y'";
            string join = "";
            string groupby = "";
            string orderby = "";
            string text = "unit_name";
            string value = "unit_id";

            item = db.creat_dropdown(table, where, join, groupby, orderby, text, value, selected);

            return item;
        }
        public List<CustomerTransportModel> list_cus_tran()
        {

            List<CustomerTransportModel> item = new List<CustomerTransportModel>();

            db.dbConnect();

            db.cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT * FROM st_customer_transport WHERE at_status = 'Y'", db.conn);
            db.rdr = db.cmd.ExecuteReader();
            while (db.rdr.Read())
            {

                CustomerTransportModel at = new CustomerTransportModel();
                at.at_id = db.rdr["at_id"].ToString();
                at.at_num = db.rdr["at_num"].ToString();
                at.at_alley = db.rdr["at_alley"].ToString();
                at.at_road = db.rdr["at_road"].ToString();
                at.at_district = db.rdr["at_district"].ToString();
                at.at_amphur = db.rdr["at_amphur"].ToString();
                at.at_province = db.rdr["at_province"].ToString();
                at.at_postcode = db.rdr["at_postcode"].ToString();
                at.at_ref_cus_id = db.rdr["at_ref_cus_id"].ToString();
                at.at_create_date = db.rdr["at_create_date"].ToString();
                at.at_create_admin_id = db.rdr["at_create_admin_id"].ToString();
                at.at_edit_date = db.rdr["at_edit_date"].ToString();
                at.at_edit_admin_id = db.rdr["at_edit_admin_id"].ToString();
                at.at_status = db.rdr["at_status"].ToString();
                at.at_customer_name = db.rdr["at_customer_name"].ToString();

                item.Add(at);
            }
            db.rdr.Close();
            db.dbClosed();

            return item;
        }

    }
}
