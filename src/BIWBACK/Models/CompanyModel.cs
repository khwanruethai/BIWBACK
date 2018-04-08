using NuGet.Packaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BIWBACK.Models
{
    public class CompanyModel
    {
        public string comp_address { get; set; }
        public string comp_amphur { get; set; }
        public string comp_create_admin_id { get; set; }
        public string comp_create_date { get; set; }
        public string comp_district { get; set; }
        public string comp_edit_date { get; set; }
        public string comp_email { get; set; }
        public string comp_fax { get; set; }
        public string comp_id { get; set; }
        public string comp_name { get; set; }
        public string comp_name_en { get; set; }
        public string comp_postcode { get; set; }
        public string comp_province { get; set;}
        public string comp_road { get; set; }
        public string comp_tax { get; set; }
        public string comp_tel { get; set; }
        public string comp_trade { get; set; }
        public string comp_web { get; set; }
        public string comp_edit_admin_id { get; set; }

        DatabaseClass db = new DatabaseClass();

        public void update_comp() {

            string table = "st_company";
            string[] Columns = {
                "comp_address", "comp_amphur", "comp_create_admin_id", "comp_create_date", "comp_district",
                "comp_edit_date", "comp_email", "comp_fax", "comp_name", "comp_name_en", "comp_postcode", "comp_province",
                "comp_road", "comp_tax", "comp_tel", "comp_trade", "comp_web", "comp_edit_admin_id"
            };
            string[] Values = {
                comp_address, comp_amphur , comp_create_admin_id, comp_create_date, comp_district,
                comp_edit_date, comp_email, comp_fax,comp_name, comp_name_en, comp_postcode, comp_province,
                comp_road, comp_tax, comp_tel, comp_trade, comp_web, comp_edit_admin_id

            };
            string where = "comp_id = '1'";

           db.update_db(table, Columns, Values, where);


        }
        public void select_comp() {

            string[] Columns = {
                "comp_address", "comp_amphur", "comp_create_admin_id", "comp_create_date", "comp_district",
                "comp_edit_date", "comp_email", "comp_fax", "comp_name", "comp_name_en", "comp_postcode", "comp_province",
                "comp_road", "comp_tax", "comp_tel", "comp_trade", "comp_web", "comp_edit_admin_id","comp_id"
            };
            string table = "st_company";
            string join = "";
            string where = "";
            string groupby = "";
            string orderby = "";
            
           List<string> result =  db.select_db(Columns, table, join, where, groupby, orderby);

            comp_address = result[0];
            comp_amphur = result[1];
            comp_create_admin_id = result[2];
            comp_create_date = result[3];
            comp_district = result[4];
            comp_edit_date = result[5];
            comp_email = result[6];
            comp_fax = result[7];
            comp_name = result[8];
            comp_name_en = result[9];
            comp_postcode = result[10];
            comp_province = result[11];
            comp_road = result[12];
            comp_tax = result[13];
            comp_tel = result[14];
            comp_trade = result[15];
            comp_web = result[16];
            comp_edit_admin_id = result[17];
            comp_id = result[18];


        }


    }
}
