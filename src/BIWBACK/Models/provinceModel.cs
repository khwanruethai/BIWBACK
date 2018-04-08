using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BIWBACK.Models
{
    public class provinceModel
    {
        public string province_id { get; set; }
        public string province_name { get; set; }

        DatabaseClass db = new DatabaseClass();

        public List<SelectListItem> drop_province(string selected) {

            List<SelectListItem> item = new List<SelectListItem>();

            string table = "provinces";
            string where = "";
            string join = "";
            string groupby = "";
            string orderby = "";
            string text = "PROVINCE_NAME";
            string value = "PROVINCE_ID";

            item = db.creat_dropdown(table, where, join, groupby, orderby, text, value, selected);


            return item;
        }
        public List<provinceModel> list_province()
        {

            List<provinceModel> item = new List<provinceModel>();

            db.dbConnect();

            db.cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT * FROM provinces", db.conn);
            db.rdr = db.cmd.ExecuteReader();
            while (db.rdr.Read())
            {

                provinceModel pv = new provinceModel();

                pv.province_name = db.rdr["PROVINCE_NAME"].ToString();
                pv.province_id = db.rdr["PROVINCE_ID"].ToString();
                       
                item.Add(pv);
            }

            db.dbClosed();

            return item;
        }
    }
}
