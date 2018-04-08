using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace BIWBACK.Models
{
    public class FormulaModel
    {
        public string fm_id { get; set; }
        public string fm_ref_group_product_id { get; set; }
        public string fm_ref_group_material_id { get; set; }
        public string fm_ref_unit_id { get; set; }
        public string fm_result_width { get; set; }
        public string fm_result_long { get; set; }
        public string fm_width_action_a { get; set; }
        public string fm_width_action_a_val { get; set; }
        public string fm_width_action_b { get; set; }
        public string fm_width_action_b_val { get; set; }
        public string fm_long_action_a { get; set; }
        public string fm_long_action_a_val { get; set; }
        public string fm_long_action_b { get; set; }
        public string fm_long_action_b_val { get; set; }
        public string fm_result_num { get; set; }
        public string fm_width_x_long { get; set; }
        public string fm_use_num { get; set; }
        public string fm_create_date { get; set; }
        public string fm_create_admin_id { get; set; }
        public string fm_edit_date { get; set; }
        public string fm_edit_admin_id { get; set; }
        public string fm_status { get; set; }

        public string gp_name { get; set; }
        public string gm_name { get; set; }
        public string unit_name { get; set; }
        

        CultureInfo en = new CultureInfo("EN");
        CultureInfo th = new CultureInfo("TH");

        DatabaseClass db = new DatabaseClass();

        public void insert_formula()
        {

            string table = "st_formula";
            string[] Columns = {  "fm_ref_group_product_id", "fm_ref_group_material_id",    "fm_ref_unit_id",  "fm_result_width", "fm_result_long",  "fm_width_action_a",   "fm_width_action_a_val",   "fm_width_action_b",   "fm_width_action_b_val",   "fm_long_action_a",    "fm_long_action_a_val" ,   "fm_long_action_b",    "fm_long_action_b_val",    "fm_result_num",   "fm_width_x_long", "fm_use_num",  "fm_create_date",  "fm_create_admin_id",  "fm_edit_date",    "fm_edit_admin_id"};
            string[] Values = {fm_ref_group_product_id, fm_ref_group_material_id ,   fm_ref_unit_id , fm_result_width, fm_result_long  ,fm_width_action_a ,  fm_width_action_a_val ,  fm_width_action_b,   fm_width_action_b_val,   fm_long_action_a  ,  fm_long_action_a_val   , fm_long_action_b,    fm_long_action_b_val,    fm_result_num ,  fm_width_x_long, fm_use_num, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", en), "1" , DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", en) ,   "1"   };
            db.insert_db(table, Columns, Values);

        }
        public void update_formula()
        {

            string table = "st_formula";
            string[] Columns = {  "fm_ref_group_product_id", "fm_ref_group_material_id", "fm_ref_unit_id", "fm_result_width", "fm_result_long", "fm_width_action_a", "fm_width_action_a_val", "fm_width_action_b", "fm_width_action_b_val", "fm_long_action_a", "fm_long_action_a_val", "fm_long_action_b", "fm_long_action_b_val", "fm_result_num", "fm_width_x_long", "fm_use_num", "fm_edit_date", "fm_edit_admin_id" };
            string[] Values = { fm_ref_group_product_id, fm_ref_group_material_id, fm_ref_unit_id, fm_result_width, fm_result_long, fm_width_action_a, fm_width_action_a_val, fm_width_action_b, fm_width_action_b_val, fm_long_action_a, fm_long_action_a_val, fm_long_action_b, fm_long_action_b_val, fm_result_num, fm_width_x_long, fm_use_num,  DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", en), "1" };
            string where = "fm_id = '" + fm_id + "'";

            db.update_db(table, Columns, Values, where);

        }
        public void del_formula()
        {

            string table = "st_formula";
            string[] Columns = { "fm_status" };
            string[] Values = { "N" };
            string where = "fm_id = '" + fm_id + "'";

            db.update_db(table, Columns, Values, where);

        }
        public void select_formula(string where_)
        {


            string table = "st_formula";
            string[] Columns = { "fm_id", "fm_ref_group_product_id", "fm_ref_group_material_id", "fm_ref_unit_id", "fm_result_width", "fm_result_long", "fm_width_action_a", "fm_width_action_a_val", "fm_width_action_b", "fm_width_action_b_val", "fm_long_action_a", "fm_long_action_a_val", "fm_long_action_b", "fm_long_action_b_val", "fm_result_num", "fm_width_x_long", "fm_use_num", "fm_create_date", "fm_create_admin_id", "fm_edit_date", "fm_edit_admin_id", "fm_status" };
            string join = "";
            string where = where_;
            string groupby = "";
            string orderby = "";

            List<string> result = db.select_db(Columns, table, join, where, groupby, orderby);
            fm_id = result[0];
            fm_ref_group_product_id = result[1];
            fm_ref_group_material_id = result[2];
            fm_ref_unit_id = result[3];
            fm_result_width = result[4];
            fm_result_long = result[5];
            fm_width_action_a = result[6];
            fm_width_action_a_val = result[7];
            fm_width_action_b = result[8];
            fm_width_action_b_val = result[9];
            fm_long_action_a = result[10];
            fm_long_action_a_val = result[11];
            fm_long_action_b = result[12];
            fm_long_action_b_val = result[13];
            fm_result_num = result[14];
            fm_width_x_long = result[15];
            fm_use_num = result[16];
            fm_create_date = result[17];
            fm_create_admin_id = result[18];
            fm_edit_date = result[19];
            fm_edit_admin_id = result[20];
            fm_status = result[21];


        }
        public List<SelectListItem> drop_formula(string selected)
        {

            List<SelectListItem> item = new List<SelectListItem>();

            string table = "st_formula";
            string where = "fm_status = 'Y'";
            string join = "";
            string groupby = "";
            string orderby = "";
            string text = "fm_id";
            string value = "fm_id";

            item = db.creat_dropdown(table, where, join, groupby, orderby, text, value, selected);

            return item;
        }
        public List<FormulaModel> list_formula()
        {

            List<FormulaModel> item = new List<FormulaModel>();

            db.dbConnect();

            db.cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT * FROM st_formula fm "+
           " INNER JOIN st_group_product gp ON  gp.gp_id = fm.fm_ref_group_product_id"+
           " INNER JOIN st_group_material gm ON gm.gm_id = fm.fm_ref_group_material_id"+
           " INNER JOIN st_unit ut ON ut.unit_id = fm.fm_ref_unit_id"
            + " WHERE fm_status = 'Y'", db.conn);
            db.rdr = db.cmd.ExecuteReader();
            while (db.rdr.Read())
            {

                FormulaModel fm = new FormulaModel();

                fm.fm_id = db.rdr["fm_id"].ToString();
                fm.fm_ref_group_product_id = db.rdr["fm_ref_group_product_id"].ToString();
                fm.fm_ref_group_material_id = db.rdr["fm_ref_group_material_id"].ToString();
                fm.fm_ref_unit_id = db.rdr["fm_ref_unit_id"].ToString();
                fm.fm_result_width = db.rdr["fm_result_width"].ToString();
                fm.fm_result_long = db.rdr["fm_result_long"].ToString();
                fm.fm_width_action_a = db.rdr["fm_width_action_a"].ToString();
                fm.fm_width_action_a_val = db.rdr["fm_width_action_a_val"].ToString();
                fm.fm_width_action_b = db.rdr["fm_width_action_b"].ToString();
                fm.fm_width_action_b_val = db.rdr["fm_width_action_b_val"].ToString();
                fm.fm_long_action_a = db.rdr["fm_long_action_a"].ToString();
                fm.fm_long_action_a_val = db.rdr["fm_long_action_a_val"].ToString();
                fm.fm_long_action_b = db.rdr["fm_long_action_b"].ToString();
                fm.fm_long_action_b_val = db.rdr["fm_long_action_b_val"].ToString();
                fm.fm_result_num = db.rdr["fm_result_num"].ToString();
                fm.fm_width_x_long = db.rdr["fm_width_x_long"].ToString();
                fm.fm_use_num = db.rdr["fm_use_num"].ToString();
                fm.fm_create_date = db.rdr["fm_create_date"].ToString();
                fm.fm_create_admin_id = db.rdr["fm_create_admin_id"].ToString();
                fm.fm_edit_date = db.rdr["fm_edit_date"].ToString();
                fm.fm_edit_admin_id = db.rdr["fm_edit_admin_id"].ToString();
                fm.fm_status = db.rdr["fm_status"].ToString();
                fm.gp_name = db.rdr["gp_name"].ToString();
                fm.gm_name = db.rdr["gm_name"].ToString();
                fm.unit_name = db.rdr["unit_name"].ToString();

                item.Add(fm);
            }
            db.rdr.Close();
            db.dbClosed();

            return item;
        }
    }
}
