using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BIWBACK.Models
{
    public class CustomerAddressModel
    {
        public string add_id { get; set; }
        public string add_num { get; set; }
        public string add_alley { get; set; }
        public string add_road { get; set; }
        public string add_district { get; set; }
        public string add_amphur { get; set; }
        public string add_province { get; set; }
        public string add_poscode { get; set; }
        public string add_type_status { get; set; }
        public string add_branch { get; set; }
        public string add_ref_cus_id { get; set; }
        public string add_create_date { get; set; }
        public string add_create_admin_id { get; set; }
        public string add_edit_date { get; set; }
        public string add_edit_admin_id { get; set; }
        public string add_status { get; set; }

        DatabaseClass db = new DatabaseClass();

        public void insert_address()
        {

            string table = "st_customer_address";
            string[] Columns = { "add_num", "add_alley", "add_road", "add_district", "add_amphur",  "add_province", "add_poscode", "add_type_status", "add_branch", "add_ref_cus_id",  "add_create_date", "add_create_admin_id", "add_edit_date", "add_edit_admin_id"  };
            string[] Values = { add_num, add_alley, add_road, add_district, add_amphur, add_province, add_poscode, add_type_status, add_branch, add_ref_cus_id, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), "1", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") ,"1" };
            db.insert_db(table, Columns, Values);

        }
        public void update_address()
        {

            string table = "st_customer_address";
            string[] Columns = {  "add_num", "add_alley", "add_road", "add_district", "add_amphur", "add_province", "add_poscode", "add_type_status", "add_branch", "add_ref_cus_id", "add_edit_date", "add_edit_admin_id"};
            string[] Values = { add_num, add_alley, add_road, add_district, add_amphur, add_province, add_poscode, add_type_status, add_branch, add_ref_cus_id, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), "1" };
            string where = "add_id = '" + add_id + "'";

            db.update_db(table, Columns, Values, where);

        }
        public void del_address()
        {

            string table = "st_customer_address";
            string[] Columns = { "add_status" };
            string[] Values = { "N" };
            string where = "add_id = '" + add_id + "'";

            db.update_db(table, Columns, Values, where);

        }
        public void select_address(string where_)
        {

            string table = "st_customer_address";
            string[] Columns = { "add_id", "add_num", "add_alley", "add_road", "add_district", "add_amphur", "add_province", "add_poscode", "add_type_status", "add_branch", "add_ref_cus_id", "add_create_date", "add_create_admin_id", "add_edit_date", "add_edit_admin_id", "add_status" };
            string join = "";
            string where = where_;
            string groupby = "";
            string orderby = "";

            List<string> result = db.select_db(Columns, table, join, where, groupby, orderby);

            add_id = result[0];
            add_num = result[1];
            add_alley = result[2];
            add_road = result[3];
            add_district = result[4];
            add_amphur = result[5];
            add_province = result[6];
            add_poscode = result[7];
            add_type_status = result[8];
            add_branch = result[9];
            add_ref_cus_id = result[10];
            add_create_date = result[11];
            add_create_admin_id = result[12];
            add_edit_date = result[13];
            add_edit_admin_id = result[14];
            add_status = result[15];
        }
        public List<SelectListItem> drop_address(string selected)
        {

            List<SelectListItem> item = new List<SelectListItem>();

            string table = "st_customer_address";
            string where = "add_status = 'Y'";
            string join = "";
            string groupby = "";
            string orderby = "";
            string text = "add_num";
            string value = "add_id";

            item = db.creat_dropdown(table, where, join, groupby, orderby, text, value, selected);

            return item;
        }
        public List<CustomerAddressModel> list_address()
        {

            List<CustomerAddressModel> item = new List<CustomerAddressModel>();

            db.dbConnect();

            db.cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT * FROM st_customer_address WHERE add_status = 'Y'", db.conn);
            db.rdr = db.cmd.ExecuteReader();
            while (db.rdr.Read())
            {

                CustomerAddressModel ad = new CustomerAddressModel();
                ad.add_id = db.rdr["add_id"].ToString();
                ad.add_num = db.rdr["add_num"].ToString();
                ad.add_alley = db.rdr["add_alley"].ToString();
                ad.add_road = db.rdr["add_road"].ToString();
                ad.add_district = db.rdr["add_district"].ToString();
                ad.add_amphur = db.rdr["add_amphur"].ToString();
                ad.add_province = db.rdr["add_province"].ToString();
                ad.add_poscode = db.rdr["add_poscode"].ToString();
                ad.add_type_status = db.rdr["add_type_status"].ToString();
                ad.add_branch = db.rdr["add_branch"].ToString();
                ad.add_ref_cus_id = db.rdr["add_ref_cus_id"].ToString();
                ad.add_create_date = db.rdr["add_create_date"].ToString();
                ad.add_create_admin_id = db.rdr["add_create_admin_id"].ToString();
                ad.add_edit_date = db.rdr["add_edit_date"].ToString();
                ad.add_edit_admin_id = db.rdr["add_edit_admin_id"].ToString();
                ad.add_status = db.rdr["add_status"].ToString();


                item.Add(ad);
            }
            db.rdr.Close();
            db.dbClosed();

            return item;
        }

      
    }
}
