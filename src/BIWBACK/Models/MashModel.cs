using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace BIWBACK.Models
{
    public class MashModel
    {
        public string   mash_id { get; set; }
        public string   mash_ref_product_id { get; set; }
        public string   mash_ref_material_id { get; set; }
        public string   mash_create_date { get; set; }
        public string   mash_create_admin_id { get; set; }
        public string   mash_edit_date { get; set; }
        public string   mash_edit_admin_id { get; set; }
        public string   mash_status { get; set; }

        public string product_code { get; set; }
        public string product_name { get; set; }
        public string mtr_code { get; set; }
        public string mtr_name { get; set; }
        public string mtr_detail { get; set; }


        CultureInfo en = new CultureInfo("EN");
        CultureInfo th = new CultureInfo("TH");

        DatabaseClass db = new DatabaseClass();

        public void insert_mash()
        {

            string table = "st_mash";
            string[] Columns = {  "mash_ref_product_id", "mash_ref_material_id", "mash_create_date", "mash_create_admin_id", "mash_edit_date",  "mash_edit_admin_id" , "mash_status" };
            string[] Values = { mash_ref_product_id, mash_ref_material_id , DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", en),   "1"  ,  DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss",en),  "1" , "Y" };
            db.insert_db(table, Columns, Values);

        }
        public void update_mash()
        {

            string table = "st_mash";
            string[] Columns = {  "mash_ref_product_id", "mash_ref_material_id", "mash_edit_date", "mash_edit_admin_id" };
            string[] Values = {  mash_ref_product_id, mash_ref_material_id, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", en), "1" };
            string where = "mash_id = '" + mash_id + "'";

            db.update_db(table, Columns, Values, where);

        }
        public void del_mash()
        {

            string table = "st_mash";
            string[] Columns = { "mash_status" };
            string[] Values = { "N" };
            string where = "mash_id = '" + mash_id + "'";

            db.update_db(table, Columns, Values, where);

        }
        public void select_mash(string where_)
        {

            string table = "st_mash";
            string[] Columns = { "mash_id", "mash_ref_product_id", "mash_ref_material_id", "mash_create_date", "mash_create_admin_id", "mash_edit_date", "mash_edit_admin_id", "mash_status" };
            string join = "";
            string where = where_;
            string groupby = "";
            string orderby = "";

            List<string> result = db.select_db(Columns, table, join, where, groupby, orderby);
            mash_id = result[0];
            mash_ref_product_id = result[1];
            mash_ref_material_id = result[2];
            mash_create_date = result[3];
            mash_create_admin_id = result[4];
            mash_edit_date = result[5];
            mash_edit_admin_id = result[6];
            mash_status = result[7];


        }
        public List<SelectListItem> drop_mash(string selected)
        {

            List<SelectListItem> item = new List<SelectListItem>();

            string table = "st_mash";
            string where = "mash_status = 'Y'";
            string join = "";
            string groupby = "";
            string orderby = "";
            string text = "mash_id";
            string value = "mash_id";

            item = db.creat_dropdown(table, where, join, groupby, orderby, text, value, selected);

            return item;
        }
        public List<MashModel> list_mash()
        {

            List<MashModel> item = new List<MashModel>();

            db.dbConnect();

            db.cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT ms.mash_id, pd.pd_code, pd.pd_name, mt.mtr_code, mt.mtr_name, mt.mtr_detail FROM st_mash ms"+
                   " INNER JOIN st_product pd ON pd.pd_id = ms.mash_ref_product_id"+
                   " INNER JOIN st_material mt ON mt.mtr_id = ms.mash_ref_material_id WHERE mash_status = 'Y'", db.conn);
            db.rdr = db.cmd.ExecuteReader();
            while (db.rdr.Read())
            {

                MashModel ms = new MashModel();

                ms.mash_id = db.rdr["mash_id"].ToString();
                ms.product_code = db.rdr["pd_code"].ToString();
                ms.product_name = db.rdr["pd_name"].ToString();
                ms.mtr_code = db.rdr["mtr_code"].ToString();
                ms.mtr_name = db.rdr["mtr_name"].ToString();
                ms.mtr_detail = db.rdr["mtr_detail"].ToString();

                item.Add(ms);
            }
            db.rdr.Close();
            db.dbClosed();

            return item;
        }
       

    }
}
