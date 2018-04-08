using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BIWBACK.Models
{
    public class CustomerModel
    {
    public string   cus_id { get; set; }
    public string   cus_code { get; set; }
    public string   cus_ref_type_id { get; set; }
    public string   cus_ref_prefix_id { get; set; }
    public string   cus_name { get; set; }
    public string   cus_lastname{ get; set; }
    public string   cus_name_contact { get; set; }
    public string   cus_trade { get; set; }
    public string   cus_tax { get; set; }
    public string   cus_create_date { get; set; }
    public string   cus_create_admin_id { get; set; }
    public string   cus_edit_date { get; set; }
    public string   cus_edit_admin_id { get; set; }
    public string   cus_status { get; set; }
    public string   count_code { get; set; }
        //

        public string status { get; set; }
        public string credit { get; set; }
        public string tel { get; set; }
        public string mail { get; set; }
        public string line { get; set; }
        public string sale { get; set; } 
      


        DatabaseClass db = new DatabaseClass();

        public void check_cus_code() {

            db.dbConnect();
            db.cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT COUNT(cus_code) AS countCode FROM st_customer WHERE cus_code = '"+cus_code+"'", db.conn);
            db.rdr = db.cmd.ExecuteReader();
            while (db.rdr.Read()) {


                count_code = db.rdr["countCode"].ToString();
            }

            db.dbClosed();
        }
        
        public void create_code() {

            db.dbConnect();

            db.cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT COUNT(cus_id) AS countCus FROM st_customer WHERE YEAR(cus_create_date) = '"+DateTime.Now.ToString("yyyy")+ "' AND MONTH(cus_create_date) = '"+DateTime.Now.ToString("MM")+"'", db.conn);
            db.rdr = db.cmd.ExecuteReader();
            while (db.rdr.Read()) {

                cus_code = DateTime.Now.ToString("yyMM") + (Convert.ToInt32(db.rdr["countCus"]) + 1).ToString("0000") + cus_ref_type_id;

            }
            db.dbClosed();

        }


        public void insert_customer()
        {

            if (string.IsNullOrEmpty(cus_code) == true)
            {
                create_code();

            }
            else {

                check_cus_code();
                if (count_code !=  "0")
                {
                    create_code();

                }
            }


            string table = "st_customer";
            string[] Columns = { "cus_code", "cus_ref_type_id", "cus_ref_prefix_id",   "cus_name",      "cus_name_contact",  "cus_trade",  "cus_tax",  "cus_create_date",  "cus_create_admin_id",  "cus_edit_date",  "cus_edit_admin_id" };
            string[] Values = { cus_code, cus_ref_type_id, cus_ref_prefix_id, cus_name, cus_name_contact, cus_trade, cus_tax, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), "1" ,DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") ,  "1"  };

          cus_id =  db.mysql_insert_db_return_id(table, Columns, Values);


        }
        public void update_customer()
        {

            string table = "st_customer";
            string[] Columns = {  "cus_ref_type_id", "cus_ref_prefix_id", "cus_name", "cus_name_contact", "cus_trade", "cus_tax",  "cus_edit_date", "cus_edit_admin_id" };
            string[] Values = { cus_ref_type_id, cus_ref_prefix_id, cus_name, cus_name_contact, cus_trade, cus_tax,  DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), "1" };
            string where = "cus_id = '" + cus_id + "'";

            db.update_db(table, Columns, Values, where);

        }
        public void del_customer()
        {

            string table = "st_customer";
            string[] Columns = { "cus_status" };
            string[] Values = { "N" };
            string where = "cus_id = '" + cus_id + "'";

            db.update_db(table, Columns, Values, where);

        }
        public void select_customer(string where_)
        {

            string table = "st_customer";
            string[] Columns = { "cus_id", "cus_code", "cus_ref_type_id", "cus_ref_prefix_id", "cus_name", "cus_lastname", "cus_name_contact", "cus_trade", "cus_tax", "cus_create_date", "cus_create_admin_id", "cus_edit_date", "cus_edit_admin_id", "cus_status" };
            string join = "";
            string where = where_;
            string groupby = "";
            string orderby = "";

            List<string> result = db.select_db(Columns, table, join, where, groupby, orderby);
            cus_id = result[0];
            cus_code = result[1];
            cus_ref_type_id = result[2];
            cus_ref_prefix_id = result[3];
            cus_name = result[4];
            cus_lastname = result[5];
            cus_name_contact = result[6];
            cus_trade = result[7];
            cus_tax = result[8];
            cus_create_date = result[9];
            cus_create_admin_id = result[10];
            cus_edit_date = result[11];
            cus_edit_admin_id = result[12];
            cus_status = result[13];

        }
        public List<SelectListItem> drop_customer(string selected)
        {

            List<SelectListItem> item = new List<SelectListItem>();

            string table = "st_customer";
            string where = "cus_status = 'Y'";
            string join = "";
            string groupby = "";
            string orderby = "";
            string text = "cus_code";
            string value = "cus_id";

            item = db.creat_dropdown(table, where, join, groupby, orderby, text, value, selected);

            return item;
        }
        public List<CustomerModel> list_customer()
        {

            List<CustomerModel> item = new List<CustomerModel>();

            db.dbConnect();

            db.cmd = new MySql.Data.MySqlClient.MySqlCommand(
                "SELECT  cus.cus_id,cus.cus_code,  cus.cus_ref_prefix_id, px.prefix_name, cus.cus_name, px.prefix_ending, cus.cus_name_contact, type.type_name, cus.cus_trade, cus.cus_tax,"+
                  "  ad.add_num, ad.add_alley, ad.add_road, dt1.DISTRICT_NAME AS dt1_name, pv1.PROVINCE_NAME AS pv1_name,am1.AMPHUR_NAME AS am1_name, ad.add_poscode, ad.add_type_status, ad.add_branch," +
                  "  contact.ct_tel, contact.ct_fax, contact.ct_email, contact.ct_web,"+
                  "  credit.credit_money, cond.cdt_name,"+
                  "  line.line_name, cl.cs_sale_name,"+
                  "  tn.at_customer_name, tn.at_num, tn.at_alley, tn.at_road, dt2.DISTRICT_NAME AS dt2_name, am2.AMPHUR_NAME AS am2_name, pv2.PROVINCE_NAME AS pv2_name, tn.at_postcode"+
                  "  FROM st_customer AS cus"+
                  "  INNER JOIN st_customer_type AS type ON type.type_id = cus.cus_ref_type_id"+
                  "  INNER JOIN st_customer_address AS ad ON ad.add_ref_cus_id = cus.cus_id"+
                  "  INNER JOIN provinces AS pv1 ON pv1.PROVINCE_ID = ad.add_province"+
                  "  INNER JOIN amphures AS am1 ON am1.AMPHUR_ID = ad.add_amphur"+
                  "  INNER JOIN districts AS dt1 ON dt1.DISTRICT_ID = ad.add_district"+
                  "  INNER JOIN st_customer_contact AS contact ON contact.ct_ref_cus_id = cus.cus_id"+
                  "  INNER JOIN st_customer_credit AS credit ON credit.credit_ref_cus_id = cus.cus_id"+
                  "  INNER JOIN st_condition_pay AS cond ON cond.cdt_id = credit.credit_ref_condition"+
                  "  INNER JOIN st_customer_line_sale AS cl ON cl.cs_ref_cus_id = cus.cus_id"+
                  "  INNER JOIN st_line AS line ON line.line_id = cl.cs_ref_line_id"+
                  "  INNER JOIN st_customer_transport AS tn ON tn.at_ref_cus_id = cus.cus_id"+
                  "  INNER JOIN provinces AS pv2 ON pv2.PROVINCE_ID = tn.at_province"+
                  "  INNER JOIN amphures AS am2 ON am2.AMPHUR_ID = tn.at_amphur"+
                  "  INNER JOIN districts AS dt2 ON dt2.DISTRICT_ID = tn.at_district"+
                  "  INNER JOIN st_prefix AS px ON px.prefix_id = cus.cus_ref_prefix_id"+
                  " WHERE cus.cus_status = 'Y'", db.conn);
            db.rdr = db.cmd.ExecuteReader();
            while (db.rdr.Read())
            {

                CustomerModel cs = new CustomerModel();

                cs.cus_id = db.rdr["cus_id"].ToString();
                cs.cus_code = db.rdr["cus_code"].ToString();
                cs.cus_ref_type_id = db.rdr["type_name"].ToString();
                cs.cus_ref_prefix_id = db.rdr["prefix_name"].ToString();
                cs.cus_name = db.rdr["cus_name"].ToString();
                cs.cus_lastname = db.rdr["prefix_ending"].ToString();
                cs.cus_name_contact = db.rdr["cus_name_contact"].ToString();
                cs.cus_trade = db.rdr["cus_trade"].ToString();
                cs.cus_tax = db.rdr["cus_tax"].ToString();
                cs.credit = db.rdr["cdt_name"].ToString();
                cs.status = db.rdr["add_type_status"].ToString();
                cs.tel = db.rdr["ct_tel"].ToString();
                cs.mail = db.rdr["ct_email"].ToString();
                cs.line = db.rdr["line_name"].ToString();
                cs.sale = db.rdr["cs_sale_name"].ToString();

                item.Add(cs);
            }
            db.rdr.Close();
            db.dbClosed();

            return item;
        }
       
    }
}
