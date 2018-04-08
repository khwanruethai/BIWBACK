﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace BIWBACK.Models
{
    public class DatabaseClass
    {
        public MySqlConnection conn;
        public MySqlCommand cmd;
        public MySqlDataReader rdr;
        public string sqlConnection = "server=localhost; uid=root;pwd=1234;database=biwmanag_stock;";

        public string Columns_set { get; set; }
        public string Columns_get { get; set; }
        public string Columns_update { get; set; }
        public  long id { get; set; }

        public string join_data { get; set; }
        public string where_data { get; set; }
        public string group_data { get; set; }
        public string orderby_data { get; set; } 

        public void dbConnect() {

            conn = new MySqlConnection(sqlConnection);

            if (conn.State == ConnectionState.Closed) {

                conn.Open();

            }
        }
        public void dbClosed() {

            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
        }
        public void ColumnsGetSet(string[] Columns) {

            int length = Columns.Count();
            int last = length - 1;
            for (int i = 0; i < length; i++)
            {

                if (i == last)
                {
                    Columns_set += Columns[i];
                    Columns_get += "@" + Columns[i];
                    Columns_update += Columns[i] + " =@" + Columns[i];
                }
                else
                {
                    Columns_set += Columns[i] + " , ";
                    Columns_get += "@" + Columns[i] + " , ";
                    Columns_update += Columns[i] + " =@" + Columns[i]+", ";
                }
            }
            
        }
        public void InputValue(string[] Columns, string[] Values) {

            int j = 0;
            foreach (object val in Values)
            {
                cmd.Parameters.AddWithValue("@" + Columns[j], val);

                j++;
            }
        }
        public void Exucte_Dispose() {
            
            cmd.ExecuteNonQuery();
            cmd.Dispose();

        }
        public void getLastInsertId() {

            id =  cmd.LastInsertedId;
        }

        public void insert_db(string table , string[] Columns, string[] Values)
        { 
            
          
            ColumnsGetSet(Columns);

            dbConnect();

            cmd = new MySqlCommand("INSERT INTO "+table+" ("+Columns_set+") VALUES("+Columns_get+")", conn);
            InputValue(Columns, Values);
            Exucte_Dispose();

            dbClosed();
        }
        public string mysql_insert_db_return_id(string table, string[] Columns, string[] Values)
        {

            dbConnect();
            ColumnsGetSet(Columns);

            cmd = new MySqlCommand("INSERT INTO "+table+" (" + Columns_set + ") VALUES(" + Columns_get + ")", conn);
            InputValue(Columns, Values);
            Exucte_Dispose();
            getLastInsertId();
            dbClosed();

            return id.ToString();
        }
        public void update_db(string table, string[] Columns, string[] Values, string where = null) {
            
            dbConnect();
            ColumnsGetSet(Columns);

            if (string.IsNullOrEmpty(where) == true) {

                where = "";
            }
            else {

                where = "WHERE "+where;
            }

            cmd = new MySqlCommand("UPDATE "+table+" SET "+Columns_update +" "+ where, conn);
            InputValue(Columns, Values);
            Exucte_Dispose();

            dbClosed();
        }
        public void delete_db(string table, string where) {

            dbConnect();

            cmd = new MySqlCommand("DELETE * FROM "+table+" WHERE "+where, conn);
            Exucte_Dispose();

            dbClosed();
        }
        public void checkData_search(string join, string where, string groupby, string orderby) {


            if (string.IsNullOrEmpty(join) == true)
            {
                join_data = "";

            }
            //else {

            //    join_data = join+" ";

            //}

            //

            if (string.IsNullOrEmpty(where) == true)
            {

                where_data = "";

            }
            else
            {

                where_data = join+"  WHERE " + where;

            }

            //
            if (string.IsNullOrEmpty(groupby) == true)
            {
                group_data = "";

            }
            else
            {

                group_data = " GROUP BY " + groupby;
            }

            //

            if (string.IsNullOrEmpty(orderby) == true)
            {
                orderby_data = "";

            }
            else
            {

                orderby_data = " ORDER BY " + orderby;
            }


        }
        public List<string> select_db(string[] Columns, string table, string join = null, string where = null, string groupby = null, string orderby = null) {

            List<string> result = new List<string>();

            ColumnsGetSet(Columns);

            checkData_search(join, where, groupby, orderby);

            dbConnect();
            cmd = new MySqlCommand("SELECT "+Columns_set+" FROM "+table+ where_data+ join_data + group_data+orderby_data , conn);
            rdr = cmd.ExecuteReader();
            while (rdr.Read()) {

                foreach (string col in Columns) {

                    result.Add(rdr[col].ToString());
                }
            }

            rdr.Close();
            dbClosed();
            
            return result;
        }
        public List<SelectListItem> creat_dropdown(string table,string where, string join, string groupby, string orderby, string text, string value, string selected) {

            List<SelectListItem> item = new List<SelectListItem>();
            string txt = "";
            checkData_search(join, where, groupby, orderby);

            dbConnect();
            cmd = new MySqlCommand("SELECT " + text + " , "+value+" FROM " + table + where_data + join_data + group_data + orderby_data, conn);
            rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                if (string.IsNullOrEmpty(selected) == false) {

                    if (rdr[value].ToString() == selected) {

                     
                            item.Insert(0, new SelectListItem { Text = rdr[text].ToString(), Value = rdr[value].ToString() });
                        
                      
                    }
                }

                item.Add(new SelectListItem{ Text= rdr[text].ToString(), Value = rdr[value].ToString() });
            }

            rdr.Close();
            dbClosed();
            

            return item;
        }
        public string create_dropdown_ajax(string table, string join = null, string where = null, string groupby = null, string orderby = null, string text = "", string value = "") {

            string result = "";

            checkData_search(join, where, groupby, orderby);

            dbConnect();
            cmd = new MySqlCommand("SELECT " + text + " , " + value + " FROM " + table + where_data + join_data + group_data + orderby_data, conn);
            rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                result += "<option value = '"+rdr[value]+"'>"+rdr[text]+"</option>";
            }

            rdr.Close();
            dbClosed();


            return result;
        }
    }
}

