using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace BIWBACK.Models
{
    public class productModel
    {
                public string   pd_id { get; set; }
                public string pd_code { get; set; }
                public string   pd_ref_group_product { get; set; }
                public string pd_ref_group_product_sale { get; set; }
                public string   pd_name { get; set; }
                public string   pd_color { get; set; }
                public string   pd_width { get; set; }
                public string   pd_long { get; set; }
                public string   pd_detail { get; set; }
                public string   pd_unit { get; set; }
                public string   pd_price { get; set; }
                public string   pd_sale { get; set; }
                public string   pd_img { get; set; }
                public string   pd_create_date { get; set; }
                public string   pd_create_admin_id { get; set; }
                public string   pd_edit_date { get; set; }
                public string   pd_edit_admin_id { get; set; }
                public string   pd_status { get; set; }



        CultureInfo th = new CultureInfo("TH");
        CultureInfo en = new CultureInfo("EN");

        DatabaseClass db = new DatabaseClass();

        public void insert_product()
        {

            string table = "st_product";
            string[] Columns = { "pd_code", "pd_ref_group_product", "pd_ref_group_product_sale", "pd_name", "pd_color", "pd_width", "pd_long", "pd_detail", "pd_unit", "pd_price", "pd_sale", "pd_img",  "pd_create_date",  "pd_create_admin_id",  "pd_edit_date", "pd_edit_admin_id" };
            string[] Values = { pd_code, pd_ref_group_product  , pd_ref_group_product_sale, pd_name, pd_color   , pd_width  ,  pd_long ,pd_detail ,  pd_unit, pd_price,    pd_sale, pd_img, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", en),  "1",  DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss",en) ,   "1" };
            db.insert_db(table, Columns, Values);

        }
        public void update_product()
        {


            string table = "st_product";
            string[] Columns = { "pd_code",  "pd_ref_group_product", "pd_ref_group_product_sale", "pd_name", "pd_color", "pd_width", "pd_long", "pd_detail", "pd_unit", "pd_price", "pd_sale", "pd_img","pd_edit_date", "pd_edit_admin_id" };
            string[] Values = { pd_code, pd_ref_group_product, pd_ref_group_product_sale, pd_name, pd_color, pd_width, pd_long, pd_detail, pd_unit, pd_price, pd_sale, pd_img, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", en), "1" };
            string where = "pd_id = '" + pd_id + "'";

            db.update_db(table, Columns, Values, where);

        }
        public void del_product()
        {

            string table = "st_product";
            string[] Columns = { "pd_status" };
            string[] Values = { "N" };
            string where = "pd_id = '" + pd_id + "'";

            db.update_db(table, Columns, Values, where);

        }
        public void select_product(string where_)
        {


            string table = "st_product";
            string[] Columns = { "pd_id", "pd_ref_group_product", "pd_name", "pd_color", "pd_width", "pd_long", "pd_detail", "pd_unit", "pd_price", "pd_sale", "pd_img", "pd_create_date", "pd_create_admin_id", "pd_edit_date", "pd_edit_admin_id", "pd_status" , "pd_code", "pd_ref_group_product_sale" };
            string join = "";
            string where = where_;
            string groupby = "";
            string orderby = "";

            List<string> result = db.select_db(Columns, table, join, where, groupby, orderby);

            pd_id = result[0];
            pd_ref_group_product = result[1];
            pd_name = result[2];
            pd_color = result[3];
            pd_width = result[4];
            pd_long = result[5];
            pd_detail = result[6];
            pd_unit = result[7];
            pd_price = result[8];
            pd_sale = result[9];
            pd_img = result[10];
            pd_create_date = result[11];
            pd_create_admin_id = result[12];
            pd_edit_date = result[13];
            pd_edit_admin_id = result[14];
            pd_status = result[15];
            pd_code = result[16];
           pd_ref_group_product_sale = result[17];

        }
        public List<SelectListItem> drop_product(string selected)
        {

            List<SelectListItem> item = new List<SelectListItem>();

            string table = "st_product";
            string where = "pd_status = 'Y'";
            string join = "";
            string groupby = "";
            string orderby = "";
            string text = "pd_name";
            string value = "pd_id";

            item = db.creat_dropdown(table, where, join, groupby, orderby, text, value, selected);

            return item;
        }
        public List<productModel> list_product()
        {

            List<productModel> item = new List<productModel>();

            db.dbConnect();

            db.cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT * , p1.gp_name AS p1_name, p2.gp_name AS p2_name "+
                       " FROM st_product AS pd "+
                       " INNER JOIN st_group_product AS p1 ON p1.gp_id = pd.pd_ref_group_product"+
                       " INNER JOIN st_group_product AS p2 ON p2.gp_id = pd.pd_ref_group_product_sale"+
                       " INNER JOIN st_unit AS un ON un.unit_id = pd.pd_unit WHERE pd.pd_status = 'Y'", db.conn);
            db.rdr = db.cmd.ExecuteReader();
            while (db.rdr.Read())
            {

                productModel pd = new productModel();

                pd.pd_id = db.rdr["pd_id"].ToString();
                pd.pd_ref_group_product = db.rdr["p1_name"].ToString();
                pd.pd_name = db.rdr["pd_name"].ToString();
                pd.pd_color = db.rdr["pd_color"].ToString();
                pd.pd_width = db.rdr["pd_width"].ToString();
                pd.pd_long = db.rdr["pd_long"].ToString();
                pd.pd_detail = db.rdr["pd_detail"].ToString();
                pd.pd_unit = db.rdr["unit_name"].ToString();
                pd.pd_price = db.rdr["pd_price"].ToString();
                pd.pd_sale = db.rdr["pd_sale"].ToString();
                pd.pd_img = db.rdr["pd_img"].ToString();
                pd.pd_create_date = db.rdr["pd_create_date"].ToString();
                pd.pd_create_admin_id = db.rdr["pd_create_admin_id"].ToString();
                pd.pd_edit_date = db.rdr["pd_edit_date"].ToString();
                pd.pd_edit_admin_id = db.rdr["pd_edit_admin_id"].ToString();
                pd.pd_status = db.rdr["pd_status"].ToString();
                pd.pd_code = db.rdr["pd_code"].ToString();
                pd.pd_ref_group_product_sale = db.rdr["p2_name"].ToString();

                item.Add(pd);
            }
            db.rdr.Close();
            db.dbClosed();

            return item;
        }
    }
}
