using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace BIWBACK.Models
{
    public class SuplierModel
    {
          public string sup_id { get; set; }
          public string sup_code { get; set; }
          public string sup_prefix_id { get; set; }
          public string sup_name { get; set; }
          public string sup_lastname { get; set; }
          public string sup_name_contact { get; set; }
          public string sup_num { get; set; }
          public string sup_alley{ get; set; }
          public string sup_road { get; set; }
          public string sup_district { get; set; }
          public string sup_amphur { get; set; }
          public string sup_province { get; set; }
          public string sup_postcode { get; set; }
          public string sup_tel { get; set; }
          public string sup_fax { get; set; }
          public string sup_tax { get; set; }
          public string sup_trade { get; set; }
          public string sup_email { get; set; }
          public string sup_web { get; set; }
          public string sup_credit_money { get; set; }
          public string sup_credit_id { get; set; }
          public string sup_create_date { get; set; }
          public string sup_create_admin_id { get; set; }
          public string sup_edit_date { get; set; }
          public string sup_edit_admin_id { get; set; }
          public string sup_status { get; set; }

        //
        public string credit_name { get; set; }
        public string district_name { get; set; }
        public string amphur_name { get; set; }
        public string province_name { get; set; }
        public string prefix_name { get; set; }
        public string prefix_end { get; set; }

         public string count_code { get; set; }

        DatabaseClass db = new DatabaseClass();

        CultureInfo en = new CultureInfo("EN");
        CultureInfo th = new CultureInfo("TH");
        public void check_sup_code()
        {

            db.dbConnect();
            db.cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT COUNT(sup_code) AS countCode FROM st_suplier WHERE sup_code = '" + sup_code + "'", db.conn);
            db.rdr = db.cmd.ExecuteReader();
            while (db.rdr.Read())
            {


                count_code = db.rdr["countCode"].ToString();
            }

            db.dbClosed();
        }

        public void create_code()
        {

            db.dbConnect();

            db.cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT COUNT(sup_id) AS countSup FROM st_suplier WHERE YEAR(sup_create_date) = '" + DateTime.Now.ToString("yyyy") + "' AND MONTH(sup_create_date) = '" + DateTime.Now.ToString("MM") + "'", db.conn);
            db.rdr = db.cmd.ExecuteReader();
            while (db.rdr.Read())
            {

                sup_code = DateTime.Now.ToString("yyMM",th) + (Convert.ToInt32(db.rdr["countSup"]) + 1).ToString("00000");

            }
            db.dbClosed();

        }



        public void insert_suplier()
        {

            string table = "st_suplier";
            string[] Columns = {  "sup_code", "sup_prefix_id", "sup_name", "sup_lastname",  "sup_name_contact", "sup_num", "sup_alley", "sup_road",  "sup_district", "sup_amphur", "sup_province",  "sup_postcode", "sup_tel", "sup_tax", "sup_fax", "sup_trade",  "sup_email",   "sup_web", "sup_credit_money" ,"sup_credit_id",   "sup_create_date", "sup_create_admin_id", "sup_edit_date", "sup_edit_admin_id"   };
            string[] Values = {  sup_code   , sup_prefix_id ,  sup_name,    sup_lastname  ,  sup_name_contact    ,sup_num ,sup_alley ,  sup_road ,   sup_district  ,  sup_amphur , sup_province  ,  sup_postcode  ,  sup_tel, sup_fax,sup_tax, sup_trade,   sup_email  , sup_web, sup_credit_money ,  sup_credit_id,   DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", en) ,"1", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", en) ,  "1"    };
            db.insert_db(table, Columns, Values);

        }
        public void update_suplier()
        {

            string table = "st_suplier";
            string[] Columns = {   "sup_prefix_id", "sup_name", "sup_lastname", "sup_name_contact", "sup_num", "sup_alley", "sup_road", "sup_district", "sup_amphur", "sup_province", "sup_postcode", "sup_tel", "sup_tax", "sup_fax", "sup_trade", "sup_email", "sup_web", "sup_credit_money", "sup_credit_id", "sup_edit_date", "sup_edit_admin_id"};
            string[] Values = {   sup_prefix_id, sup_name, sup_lastname, sup_name_contact, sup_num, sup_alley, sup_road, sup_district, sup_amphur, sup_province, sup_postcode, sup_tel, sup_fax, sup_tax, sup_trade, sup_email, sup_web, sup_credit_money, sup_credit_id,  DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", en), "1" };
            string where = "sup_id = '" + sup_id + "'";

            db.update_db(table, Columns, Values, where);

        }
        public void del_suplier()
        {

            string table = "st_suplier";
            string[] Columns = { "sup_status" };
            string[] Values = { "N" };
            string where = "sup_id = '" + sup_id + "'";

            db.update_db(table, Columns, Values, where);

        }
        public void select_suplier(string where_)
        {

            string table = "st_suplier AS sp";
            string[] Columns = { "sup_id", "sup_code", "sup_prefix_id", "sup_name", "sup_lastname", "sup_name_contact", "sup_num", "sup_alley", "sup_road", "sup_district", "sup_amphur", "sup_province", "sup_postcode", "sup_tel", "sup_tax", "sup_fax", "sup_trade", "sup_email", "sup_web", "sup_credit_money", "sup_credit_id", "sup_create_date", "sup_create_admin_id", "sup_edit_date", "sup_edit_admin_id", "sup_status", "cdt_name", "DISTRICT_NAME","AMPHUR_NAME","PROVINCE_NAME","prefix_name","prefix_ending"};
            string join = " INNER JOIN st_prefix As px ON px.prefix_id = sp.sup_prefix_id" +
                                                      " INNER JOIN st_condition_pay As cp ON cp.cdt_id = sp.sup_credit_id" +
                                                      " INNER JOIN provinces AS pv ON pv.PROVINCE_ID = sp.sup_province" +
                                                      " INNER JOIN districts AS dt ON dt.DISTRICT_ID = sp.sup_district" +
                                                      " INNER JOIN amphures AS am ON am.AMPHUR_ID = sp.sup_amphur";
            string where = where_;
            string groupby = "";
            string orderby = "";

            List<string> result = db.select_db(Columns, table, join, where, groupby, orderby);
            sup_id = result[0];
            sup_code = result[1];
            sup_prefix_id = result[2];
            sup_name = result[3];
            sup_lastname = result[4];
            sup_name_contact = result[5];
            sup_num = result[6];
            sup_alley = result[7];
            sup_road = result[8];
            sup_district = result[9];
            sup_amphur = result[10];
            sup_province = result[11];
            sup_postcode = result[12];
            sup_tel = result[13];
            sup_fax = result[14];
            sup_tax = result[15];
            sup_trade = result[16];
            sup_email = result[17];
            sup_web = result[18];
            sup_credit_money = result[19];
            sup_credit_id = result[20];
            sup_create_date = result[21];
            sup_create_admin_id = result[22];
            sup_edit_date = result[23];
            sup_edit_admin_id = result[24];
            sup_status = result[25];
            credit_name = result[26];
            district_name = result[27];
            amphur_name = result[28];
            province_name = result[29];
            prefix_name = result[30];
            prefix_end = result[31];

        }
        public List<SelectListItem> drop_suplier(string selected)
        {

            List<SelectListItem> item = new List<SelectListItem>();

            string table = "st_suplier";
            string where = "sup_status = 'Y'";
            string join = "";
            string groupby = "";
            string orderby = "";
            string text = "sup_name";
            string value = "sup_id";

            item = db.creat_dropdown(table, where, join, groupby, orderby, text, value, selected);

            return item;
        }
        public List<SuplierModel> list_suplier()
        {

            List<SuplierModel> item = new List<SuplierModel>();

            db.dbConnect();

            db.cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT * "+
                                                      " FROM st_suplier AS sp"+
                                                      " INNER JOIN st_prefix As px ON px.prefix_id = sp.sup_prefix_id"+
                                                      " INNER JOIN st_condition_pay As cp ON cp.cdt_id = sp.sup_credit_id"+
                                                      " INNER JOIN provinces AS pv ON pv.PROVINCE_ID = sp.sup_province"+
                                                      " INNER JOIN districts AS dt ON dt.DISTRICT_ID = sp.sup_district"+
                                                      " INNER JOIN amphures AS am ON am.AMPHUR_ID = sp.sup_amphur WHERE sp.sup_status = 'Y'", db.conn);
            db.rdr = db.cmd.ExecuteReader();
            while (db.rdr.Read())
            {

                SuplierModel sp = new SuplierModel();
                sp.sup_id = db.rdr["sup_id"].ToString();
                sp.sup_code = db.rdr["sup_code"].ToString();
                sp.sup_prefix_id = db.rdr["sup_prefix_id"].ToString();
                sp.sup_name = db.rdr["sup_name"].ToString();
                sp.sup_lastname = db.rdr["sup_lastname"].ToString();
                sp.sup_name_contact = db.rdr["sup_name_contact"].ToString();
                sp.sup_num = db.rdr["sup_num"].ToString();
                sp.sup_alley = db.rdr["sup_alley"].ToString();
                sp.sup_road = db.rdr["sup_road"].ToString();
                sp.sup_district = db.rdr["sup_district"].ToString();
                sp.sup_amphur = db.rdr["sup_amphur"].ToString();
                sp.sup_province = db.rdr["sup_province"].ToString();
                sp.sup_postcode = db.rdr["sup_postcode"].ToString();
                sp.sup_tel = db.rdr["sup_tel"].ToString();
                sp.sup_fax = db.rdr["sup_fax"].ToString();
                sp.sup_tax = db.rdr["sup_tax"].ToString();
                sp.sup_trade = db.rdr["sup_trade"].ToString();
                sp.sup_email = db.rdr["sup_email"].ToString();
                sp.sup_web = db.rdr["sup_web"].ToString();
                sp.sup_credit_money = db.rdr["sup_credit_money"].ToString();
                sp.sup_credit_id = db.rdr["sup_credit_id"].ToString();
                sp.sup_create_date = db.rdr["sup_create_date"].ToString();
                sp.sup_create_admin_id = db.rdr["sup_create_admin_id"].ToString();
                sp.sup_edit_date = db.rdr["sup_edit_date"].ToString();
                sp.sup_edit_admin_id = db.rdr["sup_edit_admin_id"].ToString();
                sp.sup_status = db.rdr["sup_status"].ToString();

                sp.credit_name = db.rdr["cdt_name"].ToString();
                sp.district_name= db.rdr["DISTRICT_NAME"].ToString();
                sp.amphur_name = db.rdr["AMPHUR_NAME"].ToString();
                sp.province_name = db.rdr["PROVINCE_NAME"].ToString();
                sp.prefix_name = db.rdr["prefix_name"].ToString();
                sp.prefix_end = db.rdr["prefix_ending"].ToString();

                item.Add(sp);
            }
            db.rdr.Close();
            db.dbClosed();

            return item;
        }
       
    }
}
