using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BIWBACK.Models
{
    public class stickerModel
    {
        public string stk_id { get; set; }
        public string stk_name { get; set; }

        DatabaseClass db = new DatabaseClass();

        public List<SelectListItem> drop_con_pay(string selected)
        {

            List<SelectListItem> item = new List<SelectListItem>();

            string table = "st_sticker";
            string where = "";
            string join = "";
            string groupby = "";
            string orderby = "";
            string text = "stk_name";
            string value = "stk_id";

            item = db.creat_dropdown(table, where, join, groupby, orderby, text, value, selected);

            return item;
        }
    }
}
