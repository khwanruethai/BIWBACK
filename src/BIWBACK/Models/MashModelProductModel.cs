using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace BIWBACK.Models
{
    public class MashModelProductModel
    {
        public string  mmp_id { get; set; }
        public string  mmp_ref_model_product_id { get; set; }
        public string  mmp_ref_material_id { get; set; }
        public string  mmp_create_date { get; set; }
        public string  mmp_create_admin_id { get; set; }
        public string  mmp_edit_date { get; set; }
        public string  mmp_edit_admin_id { get; set; }
        public string  mmp_status { get; set; }

        public string model_product { get; set; }
        public string mtr_code { get; set; }
        public string mtr_name { get; set; }

        CultureInfo en = new CultureInfo("EN");
        CultureInfo th = new CultureInfo("TH");

        DatabaseClass db = new DatabaseClass();

        public void insert_mmp()
        {

            string table = "st_mash_model_product";
            string[] Columns = {  "mmp_ref_model_product_id", "mmp_ref_material_id", "mmp_create_date", "mmp_create_admin_id",  "mmp_edit_date",   "mmp_edit_admin_id" };
            string[] Values = {  mmp_ref_model_product_id ,   mmp_ref_material_id, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", en), "1", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss",en)  , "1" };
            db.insert_db(table, Columns, Values);

        }
        public void update_mmp()
        {

            string table = "st_mash_model_product";
            string[] Columns = { "mmp_ref_model_product_id", "mmp_ref_material_id", "mmp_edit_date", "mmp_edit_admin_id" };
            string[] Values = { mmp_ref_model_product_id, mmp_ref_material_id, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", en), "1" };
            string where = "mmp_id = '" + mmp_id + "'";

            db.update_db(table, Columns, Values, where);

        }
        public void del_mmp()
        {

            string table = "st_mash_model_product";
            string[] Columns = { "mmp_status" };
            string[] Values = { "N" };
            string where = "mmp_id = '" + mmp_id + "'";

            db.update_db(table, Columns, Values, where);

        }
        public void select_mmp(string where_)
        {

            string table = "st_mash_model_product";
            string[] Columns = { "mmp_id", "mmp_ref_model_product_id", "mmp_ref_material_id", "mmp_create_date", "mmp_create_admin_id", "mmp_edit_date", "mmp_edit_admin_id", "mmp_status" };
            string join = "";
            string where = where_;
            string groupby = "";
            string orderby = "";

            List<string> result = db.select_db(Columns, table, join, where, groupby, orderby);

            mmp_id = result[0];
            mmp_ref_model_product_id = result[1];
            mmp_ref_material_id = result[2];
            mmp_create_date = result[3];
            mmp_create_admin_id = result[4];
            mmp_edit_date = result[5];
            mmp_edit_admin_id = result[6];
            mmp_status = result[7];

        }
        public List<SelectListItem> drop_mmp(string selected)
        {

            List<SelectListItem> item = new List<SelectListItem>();

            string table = "st_mash_model_product";
            string where = "mmp_status = 'Y'";
            string join = "";
            string groupby = "";
            string orderby = "";
            string text = "mmp_id";
            string value = "mmp_id";

            item = db.creat_dropdown(table, where, join, groupby, orderby, text, value, selected);

            return item;
        }
        public List<MashModelProductModel> list_mmp()
        {

            List<MashModelProductModel> item = new List<MashModelProductModel>();

            db.dbConnect();

            db.cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT mmp.mmp_id, mp.mp_name, mt.mtr_code, mt.mtr_name FROM  st_mash_model_product mmp"+
                                                          "  INNER JOIN st_model_product mp ON mp.mp_id = mmp.mmp_ref_model_product_id"+
                                                          "  INNER JOIN st_material mt ON mt.mtr_id = mmp.mmp_ref_material_id WHERE mmp_status = 'Y'", db.conn);
            db.rdr = db.cmd.ExecuteReader();
            while (db.rdr.Read())
            {

                MashModelProductModel mmp = new MashModelProductModel();

                mmp.mmp_id = db.rdr["mmp_id"].ToString();
                mmp.model_product = db.rdr["mp_name"].ToString();
                mmp.mtr_code = db.rdr["mtr_code"].ToString();
                mmp.mtr_name = db.rdr["mtr_name"].ToString();
                   

                item.Add(mmp);
            }
            db.rdr.Close();
            db.dbClosed();

            return item;
        }
    }
}
