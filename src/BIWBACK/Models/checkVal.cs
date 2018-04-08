using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BIWBACK.Models
{
    public class checkVal
    {
        public string trueORfalse(string txt) {

            string result = "";

            if (txt == "true")
            {
                result = "Y";

            }
            else {

                result = "N";

            }


            return result;
        }
        public bool turnTF(string txt) {

            bool result;

            if (txt == "Y")
            {
                result = true; 

            }
            else {

                result = false;

            }


            return result;
        }
        public string numIsNull(string txt) {

            string result = "";

            if (string.IsNullOrWhiteSpace(txt) == true)
            {

                result = "0";
            }
            else {

                result = txt;
            }

            return result;
        }
        public List<SelectListItem> ckFormula(string txt) {

            List<SelectListItem> item = new List<SelectListItem>();


            if (txt == "+")
            {

                item.Add(new SelectListItem { Text = "", Value = "" });
                item.Add(new SelectListItem { Text = "+", Value = "+", Selected = true });
                item.Add(new SelectListItem { Text = "-", Value = "-" });
                item.Add(new SelectListItem { Text = "x", Value = "*" });
                item.Add(new SelectListItem { Text = "/", Value = "/" });
            }
            else if (txt == "-")
            {

                item.Add(new SelectListItem { Text = "", Value = "" });
                item.Add(new SelectListItem { Text = "+", Value = "+" });
                item.Add(new SelectListItem { Text = "-", Value = "-", Selected = true });
                item.Add(new SelectListItem { Text = "x", Value = "*" });
                item.Add(new SelectListItem { Text = "/", Value = "/" });

            }
            else if (txt == "*")
            {

                item.Add(new SelectListItem { Text = "", Value = "" });
                item.Add(new SelectListItem { Text = "+", Value = "+" });
                item.Add(new SelectListItem { Text = "-", Value = "-" });
                item.Add(new SelectListItem { Text = "x", Value = "*", Selected = true });
                item.Add(new SelectListItem { Text = "/", Value = "/" });

            }
            else if (txt == "/")
            {


                item.Add(new SelectListItem { Text = "", Value = "" });
                item.Add(new SelectListItem { Text = "+", Value = "+" });
                item.Add(new SelectListItem { Text = "-", Value = "-" });
                item.Add(new SelectListItem { Text = "x", Value = "*" });
                item.Add(new SelectListItem { Text = "/", Value = "/", Selected = true });

            }
            else
            {


                item.Add(new SelectListItem { Text = "", Value = "", Selected = true });
                item.Add(new SelectListItem { Text = "+", Value = "+" });
                item.Add(new SelectListItem { Text = "-", Value = "-" });
                item.Add(new SelectListItem { Text = "x", Value = "*" });
                item.Add(new SelectListItem { Text = "/", Value = "/" });

            }



            return item;
        }
    }
}
