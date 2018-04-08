using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace BIWBACK.Models
{
    public class MaterialModel
    {
        public string  mtr_id { get; set; }
        public string  mtr_ref_tm_id { get; set; }
        public string  mtr_code { get; set; }
        public string  mtr_name { get; set; }
        public string  mtr_detail { get; set; }
        public string  mtr_serial { get; set; }
        public string  mtr_shelf { get; set; }
        public string  mtr_unit_get { get; set; }
        public string  mtr_keep_num { get; set; }
        public string  mtr_unit_expose { get; set; }
        public string  mtr_width { get; set; }
        public string  mtr_long { get; set; }
        public string  mtr_side { get; set; }
        public string  mtr_roll { get; set; }
        public string  mtr_noti { get; set; }
        public string  mtr_noti_min { get; set; }
        public string  mtr_noti_max { get; set; }
        public string  mtr_sticker { get; set; }
        public string  mtr_img { get; set; }
        public string  mtr_create_date { get; set; }
        public string  mtr_create_admin_id { get; set; }
        public string  mtr_edit_date { get; set; }
        public string  mtr_edit_admin_id { get; set; }
        public string  mtr_status { get; set; }

        CultureInfo en = new CultureInfo("EN");
        CultureInfo th = new CultureInfo("TH");

        DatabaseClass db = new DatabaseClass();

        public void insert_mtr()
        {

            string table = "st_material";
            string[] Columns = { "mtr_ref_tm_id", "mtr_code","mtr_name", "mtr_detail",  "mtr_serial",  "mtr_shelf", "mtr_unit_get", "mtr_keep_num", "mtr_unit_expose", "mtr_width",  "mtr_long",  "mtr_side", "mtr_roll", "mtr_noti",  "mtr_noti_min",  "mtr_noti_max", "mtr_sticker", "mtr_img", "mtr_create_date", "mtr_create_admin_id", "mtr_edit_date", "mtr_edit_admin_id" };
            string[] Values = {mtr_ref_tm_id,   mtr_code,    mtr_name,    mtr_detail , mtr_serial,  mtr_shelf ,  mtr_unit_get ,   mtr_keep_num ,   mtr_unit_expose, mtr_width,   mtr_long ,   mtr_side  ,  mtr_roll ,   mtr_noti ,   mtr_noti_min  ,  mtr_noti_max ,   mtr_sticker, mtr_img, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", en), "1", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss",en) ,  "1"  };
            db.insert_db(table, Columns, Values);

        }
        public void update_mtr()
        {

            string table = "st_material";
            string[] Columns = {  "mtr_ref_tm_id", "mtr_code", "mtr_name", "mtr_detail", "mtr_serial", "mtr_shelf", "mtr_unit_get", "mtr_keep_num", "mtr_unit_expose", "mtr_width", "mtr_long", "mtr_side", "mtr_roll", "mtr_noti", "mtr_noti_min", "mtr_noti_max", "mtr_sticker", "mtr_img", "mtr_edit_date", "mtr_edit_admin_id" };
            string[] Values = {  mtr_ref_tm_id, mtr_code, mtr_name, mtr_detail, mtr_serial, mtr_shelf, mtr_unit_get, mtr_keep_num, mtr_unit_expose, mtr_width, mtr_long, mtr_side, mtr_roll, mtr_noti, mtr_noti_min, mtr_noti_max, mtr_sticker, mtr_img, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", en), "1" };
            string where = "mtr_id = '" + mtr_id + "'";

            db.update_db(table, Columns, Values, where);

        }
        public void del_mtr()
        {

            string table = "st_material";
            string[] Columns = { "mtr_status" };
            string[] Values = { "N" };
            string where = "mtr_id = '" + mtr_id + "'";

            db.update_db(table, Columns, Values, where);

        }
        public void select_mtr(string where_)
        {

            string table = "st_material";
            string[] Columns = { "mtr_id", "mtr_ref_tm_id", "mtr_code", "mtr_name", "mtr_detail", "mtr_serial", "mtr_shelf", "mtr_unit_get", "mtr_keep_num", "mtr_unit_expose", "mtr_width", "mtr_long", "mtr_side", "mtr_roll", "mtr_noti", "mtr_noti_min", "mtr_noti_max", "mtr_sticker", "mtr_img", "mtr_create_date", "mtr_create_admin_id", "mtr_edit_date", "mtr_edit_admin_id", "mtr_status" };
            string join = "";
            string where = where_;
            string groupby = "";
            string orderby = "";

            List<string> result = db.select_db(Columns, table, join, where, groupby, orderby);
            mtr_id = result[0];
            mtr_ref_tm_id = result[1];
            mtr_code = result[2];
            mtr_name = result[3];
            mtr_detail = result[4];
            mtr_serial = result[5];
            mtr_shelf = result[6];
            mtr_unit_get = result[7];
            mtr_keep_num = result[8];
            mtr_unit_expose = result[9];
            mtr_width = result[10];
            mtr_long= result[11];
            mtr_side= result[12];
            mtr_roll= result[13];
            mtr_noti = result[14];
            mtr_noti_min = result[15];
            mtr_noti_max = result[16];
            mtr_sticker = result[17];
            mtr_img = result[18];
            mtr_create_date = result[19];
            mtr_create_admin_id = result[20];
            mtr_edit_date = result[21];
            mtr_edit_admin_id = result[22];
            mtr_status = result[23];

        }
        public List<SelectListItem> drop_mtr(string selected)
        {

            List<SelectListItem> item = new List<SelectListItem>();

            string table = "st_material";
            string where = "mtr_status = 'Y'";
            string join = "";
            string groupby = "";
            string orderby = "";
            string text = "mtr_name";
            string value = "mtr_id";

            item = db.creat_dropdown(table, where, join, groupby, orderby, text, value, selected);

            return item;
        }
        public List<MaterialModel> list_mtr()
        {

            List<MaterialModel> item = new List<MaterialModel>();

            db.dbConnect();

            db.cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT *,  u1.unit_name AS u1_name, u2.unit_name  AS u2_name "+
                                                          " FROM st_material AS mtr"+
                                                          " INNER JOIN st_group_material AS gm ON gm.gm_id = mtr.mtr_ref_tm_id"+
                                                          " INNER JOIN st_shelf AS sh ON sh.shelf_id = mtr.mtr_shelf"+
                                                          " INNER JOIN st_unit AS u1 ON u1.unit_id = mtr.mtr_unit_get"+
                                                          " INNER JOIN st_unit AS u2 ON u2.unit_id = mtr.mtr_unit_expose WHERE mtr_status = 'Y'", db.conn);
            db.rdr = db.cmd.ExecuteReader();
            while (db.rdr.Read())
            {

                MaterialModel mtr = new MaterialModel();
                mtr.mtr_id = db.rdr["mtr_id"].ToString();
                mtr.mtr_ref_tm_id = db.rdr["gm_name"].ToString();
                mtr.mtr_code = db.rdr["mtr_code"].ToString();
                mtr.mtr_name = db.rdr["mtr_name"].ToString();
                mtr.mtr_detail = db.rdr["mtr_detail"].ToString();
                mtr.mtr_serial = db.rdr["mtr_serial"].ToString();
                mtr.mtr_shelf = db.rdr["shelf_name"].ToString();
                mtr.mtr_unit_get = db.rdr["u1_name"].ToString();
                mtr.mtr_keep_num = db.rdr["mtr_keep_num"].ToString();
                mtr.mtr_unit_expose = db.rdr["u2_name"].ToString();
                mtr.mtr_width = db.rdr["mtr_width"].ToString();
                mtr.mtr_long = db.rdr["mtr_long"].ToString();
                mtr.mtr_side = db.rdr["mtr_side"].ToString();
                mtr.mtr_roll = db.rdr["mtr_roll"].ToString();
                mtr.mtr_noti = db.rdr["mtr_noti"].ToString();
                mtr.mtr_noti_min = db.rdr["mtr_noti_min"].ToString();
                mtr.mtr_noti_max = db.rdr["mtr_noti_max"].ToString();
                mtr.mtr_sticker = db.rdr["mtr_sticker"].ToString();
                mtr.mtr_img = db.rdr["mtr_img"].ToString();
                mtr.mtr_create_date = db.rdr["mtr_create_date"].ToString();
                mtr.mtr_create_admin_id = db.rdr["mtr_create_admin_id"].ToString();
                mtr.mtr_edit_date = db.rdr["mtr_edit_date"].ToString();
                mtr.mtr_edit_admin_id = db.rdr["mtr_edit_admin_id"].ToString();
                mtr.mtr_status = db.rdr["mtr_status"].ToString();

                item.Add(mtr);
            }
            db.rdr.Close();
            db.dbClosed();

            return item;
        }

    }
}
