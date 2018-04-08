using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace BIWBACK.Models
{
    public class groupMaterialModel
    {
        public string   gm_id { get; set; }
        public string   gm_code { get; set; }
        public string   gm_ref_type_material { get; set; }
        public string   gm_ref_unit { get; set; }
        public string   gm_name { get; set; }
        public string   gm_create_date { get; set; }
        public string   gm_create_admin_id { get; set; }
        public string   gm_edit_date { get; set; }
        public string   gm_edit_admin_id { get; set; }
        public string   gm_status { get; set; }

        CultureInfo en = new CultureInfo("EN");
        CultureInfo th = new CultureInfo("TH");

        DatabaseClass db = new DatabaseClass();

        public void create_code()
        {

            db.dbConnect();

            db.cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT COUNT(gm_id) AS countGm FROM st_group_material", db.conn);
            db.rdr = db.cmd.ExecuteReader();
            while (db.rdr.Read())
            {

                gm_code =  (Convert.ToInt32(db.rdr["countGm"]) + 1).ToString("00");

            }
            db.dbClosed();

        }
        public void insert_gm()
        {

            string table = "st_group_material";
            string[] Columns = { "gm_code", "gm_ref_type_material", "gm_ref_unit", "gm_name", "gm_create_date", "gm_create_admin_id",  "gm_edit_date",   "gm_edit_admin_id" };
            string[] Values = {   gm_code ,gm_ref_type_material  ,  gm_ref_unit, gm_name, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss",en), "1" , DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss",en) ,   "1"   };
            db.insert_db(table, Columns, Values);

        }
        public void update_gm()
        {

            string table = "st_group_material";
            string[] Columns = { "gm_ref_type_material", "gm_ref_unit", "gm_name",  "gm_edit_date", "gm_edit_admin_id" };
            string[] Values = {  gm_ref_type_material, gm_ref_unit, gm_name, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", en), "1" };
            string where = "gm_id = '" + gm_id + "'";

            db.update_db(table, Columns, Values, where);

        }
        public void del_gm()
        {

            string table = "st_group_material";
            string[] Columns = { "gm_status" };
            string[] Values = { "N" };
            string where = "gm_id = '" + gm_id + "'";

            db.update_db(table, Columns, Values, where);

        }
        public void select_gm(string where_)
        {

            string table = "st_group_material";
            string[] Columns = { "gm_id", "gm_code", "gm_ref_type_material", "gm_ref_unit", "gm_name", "gm_create_date", "gm_create_admin_id", "gm_edit_date", "gm_edit_admin_id", "gm_status" };
            string join = "";
            string where = where_;
            string groupby = "";
            string orderby = "";

            List<string> result = db.select_db(Columns, table, join, where, groupby, orderby);
            gm_id = result[0];
            gm_code = result[1];
            gm_ref_type_material = result[2];
            gm_ref_unit = result[3];
            gm_name = result[4];
            gm_create_date = result[5];
            gm_create_admin_id = result[6];
            gm_edit_date = result[7];
            gm_edit_admin_id = result[8];
            gm_status = result[9];

        }
        public List<SelectListItem> drop_gm(string selected)
        {

            List<SelectListItem> item = new List<SelectListItem>();

            string table = "st_group_material";
            string where = "gm_status = 'Y'";
            string join = "";
            string groupby = "";
            string orderby = "";
            string text = "gm_name";
            string value = "gm_id";

            item = db.creat_dropdown(table, where, join, groupby, orderby, text, value, selected);

            return item;
        }
        public List<groupMaterialModel> list_gm()
        {

            List<groupMaterialModel> item = new List<groupMaterialModel>();

            db.dbConnect();

            db.cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT * FROM st_group_material AS gm "+
               " INNER JOIN st_type_material AS tm ON tm.tm_id = gm.gm_ref_type_material"+
               " INNER JOIN st_unit AS ut ON ut.unit_id = gm.gm_ref_unit  WHERE gm_status = 'Y'", db.conn);
            db.rdr = db.cmd.ExecuteReader();
            while (db.rdr.Read())
            {

                groupMaterialModel gm = new groupMaterialModel();

                gm.gm_id = db.rdr["gm_id"].ToString();
                gm.gm_code = db.rdr["gm_code"].ToString();
                gm.gm_ref_type_material = db.rdr["tm_name"].ToString();
                gm.gm_ref_unit = db.rdr["unit_name"].ToString();
                gm.gm_name = db.rdr["gm_name"].ToString();
                gm.gm_create_date = db.rdr["gm_create_date"].ToString();
                gm.gm_create_admin_id = db.rdr["gm_create_admin_id"].ToString();
                gm.gm_edit_date = db.rdr["gm_edit_date"].ToString();
                gm.gm_edit_admin_id = db.rdr["gm_edit_admin_id"].ToString();
                gm.gm_status = db.rdr["gm_status"].ToString();

                item.Add(gm);
            }
            db.rdr.Close();
            db.dbClosed();

            return item;
        }
    }
}
