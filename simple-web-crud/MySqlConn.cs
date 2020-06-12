using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace simple_web_crud {
    public class MySqlConn {

        static readonly string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["SimpleWebCrud"].ToString();

        /// <summary>
        /// Load the data from DB to gridview and populate Category list box
        /// Execute both query in the same established connection *idk if this is correct*
        /// </summary>
        /// <param name="gv">GridView</param>
        /// <param name="ddl">DropDownList</param>
        public void Load(GridView gv, DropDownList ddl) {
            using (MySqlConnection conn = new MySqlConnection(connectionString)) {
                string query1 = "SELECT IdProducts ,Name, Price, Quantity, CategoryName FROM products, category WHERE products.CategoryId = category.Id";
                string query2 = "Select * FROM category";

                using (MySqlCommand cmd = new MySqlCommand(query1)) {
                    cmd.Connection = conn;
                    conn.Open();
                    
                    using (DataTable dt = new DataTable()) {
                        dt.Load(cmd.ExecuteReader());
                        gv.DataSource = dt;
                        gv.DataBind();
                    }

                    cmd.CommandText = query2;
                    using (DataTable dt2 = new DataTable()) {
                        dt2.Load(cmd.ExecuteReader());
                        ddl.DataSource = dt2;
                        ddl.DataTextField = "CategoryName";
                        ddl.DataValueField = "Id";
                        ddl.DataBind();

                    }
                }

            }
        }



        /// <summary>
        /// Add products on DB, category is based on id value from selected item in the DropDownList  
        /// </summary>
        /// <param name="pname">product name</param>
        /// <param name="pprice">product price</param>
        /// <param name="pquantity">product quantity</param>
        /// <param name="ddl">dropdownlist category</param>
        public void AddProducts(TextBox pname, TextBox pprice, TextBox pquantity, DropDownList ddl) {
            
            using (MySqlConnection conn = new MySqlConnection(connectionString)) {
                string command = $"INSERT INTO products (Name, Price, Quantity, CategoryId) VALUES ('{pname.Text}', '{float.Parse(pprice.Text, CultureInfo.InvariantCulture)}', '{pquantity.Text}' , '{ddl.SelectedValue}')";

                using (MySqlCommand cmd = new MySqlCommand(command)) {

                    cmd.Connection = conn;
                    conn.Open();
                    int n = cmd.ExecuteNonQuery();



                }
            }
        }


        public void SelectProduct() {

        }


        public void UpdateProducts() {

        }



    }
}







