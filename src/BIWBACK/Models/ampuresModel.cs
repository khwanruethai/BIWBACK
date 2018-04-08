using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BIWBACK.Models
{
    public class ampuresModel
    {
        public string amphur_id { get; set; }
        public string amphur_name { get; set; }

        DatabaseClass db = new DatabaseClass();

        public List<SelectListItem> dorp_amphur(string selected) {
            
            List<SelectListItem> item = new List<SelectListItem>();

            string table = "amphures";
            string where = "";
            string join = "";
            string groupby = "";
            string orderby = "";
            string text = "AMPHUR_NAME";
            string value = "AMPHUR_ID";

                 item =   db.creat_dropdown(table, where, join, groupby, orderby, text, value, selected);

            
            return item;
        }
        public string option_amphur(string where_) {

            string result = "";

            string table = "amphures";
            string where = "PROVINCE_ID = '"+where_+"'";
            string join = "";
            string groupby = "";
            string orderby = "";
            string text = "AMPHUR_NAME";
            string value = "AMPHUR_ID";

           result =  db.create_dropdown_ajax(table, join, where, groupby, orderby, text, value);


            return result;
        }
    }
}
