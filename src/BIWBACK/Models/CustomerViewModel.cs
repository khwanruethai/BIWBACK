using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BIWBACK.Models
{
    public class CustomerViewModel
    {
        DatabaseClass db = new DatabaseClass();

        public List<CustomerViewModel> select_customer_view() {


            List<CustomerViewModel> obj = new List<CustomerViewModel>();

            db.dbConnect();
            db.cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT  * "+
                        " FROM st_customer AS cus"+
                        " INNER JOIN st_prefix AS px ON px.prefix_id = cus.cus_ref_prefix_id"+
                        " LEFT JOIN st_customer_type AS type ON type.type_id = cus.cus_ref_type_id"+
                        " LEFT JOIN st_customer_address AS ad ON ad.add_ref_cus_id = cus.cus_id"+
                        " LEFT JOIN provinces AS pv1 ON pv1.PROVINCE_ID = ad.add_province"+
                        " LEFT JOIN amphures AS am1 ON am1.AMPHUR_ID = ad.add_amphur"+
                        " LEFT JOIN districts AS dt1 ON dt1.DISTRICT_ID = ad.add_district"+
                        " LEFT JOIN st_customer_contact AS contact ON contact.ct_ref_cus_id = cus.cus_id"+
                        " LEFT JOIN st_customer_credit AS credit ON credit.credit_ref_cus_id = cus.cus_id"+
                        " LEFT JOIN st_condition_pay AS cond ON cond.cdt_id = credit.credit_ref_condition"+
                        " LEFT JOIN st_customer_line_sale AS cl ON cl.cs_ref_cus_id = cus.cus_id"+
                        " LEFT JOIN st_line AS line ON line.line_id = cl.cs_ref_line_id"+
                        " LEFT JOIN st_customer_transport AS tn ON tn.at_ref_cus_id = cus.cus_id"+
                        " LEFT JOIN provinces AS pv2 ON pv2.PROVINCE_ID = tn.at_province"+
                        " LEFT JOIN amphures AS am2 ON am2.AMPHUR_ID = tn.at_amphur"+
                        " LEFT JOIN districts AS dt2 ON dt2.DISTRICT_ID = tn.at_district", db.conn);
            db.rdr = db.cmd.ExecuteReader();
            while (db.rdr.Read()) {


            }
            db.rdr.Close();
            db.dbClosed();

            return obj;
        }

    }

}
