using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BIWBACK.Models
{
    public class districts
    {
        public string district_id { get; set; }
        public string district_name { get; set; }
        DatabaseClass db = new DatabaseClass();

        public List<SelectListItem> drop_district(string selected) {

            List<SelectListItem> item = new List<SelectListItem>();

            string table = "districts";
            string where = "";
            string join = "";
            string groupby = "";
            string orderby = "";
            string text = "DISTRICT_NAME";
            string value = "DISTRICT_ID";

            item = db.creat_dropdown(table, where, join, groupby, orderby, text, value, selected);

            return item;
        }
        public string option_district(string where_) {

            string result = "";

            string table = "districts";
            string where = "AMPHUR_ID =  '" + where_ + "'";
            string join = "";
            string groupby = "";
            string orderby = "";
            string text = "DISTRICT_NAME";
            string value = "DISTRICT_ID";

            result = db.create_dropdown_ajax(table, join, where, groupby, orderby, text, value);


            return result;
        }
    }
}
