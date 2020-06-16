using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Globalization;
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

            try {
                using (MySqlConnection conn = new MySqlConnection(connectionString)) {


                    string query1 = "SELECT IdProducts ,Name, Price, Quantity, CategoryName FROM products, category WHERE products.CategoryId = category.Id ORDER BY IdProducts";
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
            catch (Exception e) {
                string error = e.Message;
            }

        }


        /// <summary>
        /// Add products on DB, category is based on id value from selected item in the DropDownList  
        /// </summary>
        /// <param name="pname">product name</param>
        /// <param name="pprice">product price</param>
        /// <param name="pquantity">product quantity</param>
        /// <param name="ddl">dropdownlist category</param>
        public void AddOrUpdate(TextBox pname, TextBox pprice, TextBox pquantity, DropDownList ddl, Label selectedIdText, int id) {

            try {
                string actualDdlValue = ddl.SelectedValue;
                using (MySqlConnection conn = new MySqlConnection(connectionString)) {
                    string command;
                    if (selectedIdText.Text == "") {
                        command = $"INSERT INTO products (Name, Price, Quantity, CategoryId) VALUES ('{pname.Text}', '{float.Parse(pprice.Text, CultureInfo.InvariantCulture)}', '{pquantity.Text}' , '{actualDdlValue}')";
                    }
                    else {
                        command = $"UPDATE products, category SET Name='{pname.Text}', Price='{float.Parse(pprice.Text, CultureInfo.InvariantCulture)}', Quantity ='{pquantity.Text}', CategoryId = '{ddl.SelectedValue}', CategoryName='{ddl.SelectedItem.Text}' WHERE products.IdProducts = {id.ToString()} AND category.Id = {ddl.SelectedValue}";
                    }

                    using (MySqlCommand cmd = new MySqlCommand(command)) {
                        cmd.Connection = conn;
                        conn.Open();
                        int n = cmd.ExecuteNonQuery();

                    }
                }
            }
            catch (Exception e) {

                string error = e.Message;
            }


        }



        public void SelectProduct(int selectedIdProduct, TextBox pname, TextBox pprice, TextBox pquantity, DropDownList ddl) {

            try {
                using (MySqlConnection conn = new MySqlConnection(connectionString)) {
                    string command = $"SELECT Name, Price, Quantity, Id FROM products, category WHERE products.IdProducts = {selectedIdProduct} AND products.CategoryId = category.Id;";
                    using (MySqlCommand cmd = new MySqlCommand(command)) {
                        cmd.Connection = conn;
                        conn.Open();

                        using (DataTable dt = new DataTable()) {
                            dt.Load(cmd.ExecuteReader());
                            pname.Text = dt.Rows[0]["Name"].ToString();
                            pprice.Text = dt.Rows[0]["Price"].ToString();
                            pquantity.Text = dt.Rows[0]["Quantity"].ToString();
                            ddl.SelectedValue = dt.Rows[0]["Id"].ToString();


                        }
                    }
                }
            }
            catch (Exception e) {

                string error = e.Message;
            }







        }


        public void Delete(int id) {
            try {
                using (MySqlConnection conn = new MySqlConnection(connectionString)) {
                    string command = $"DELETE FROM products WHERE IdProducts = {id}; ALTER TABLE products AUTO_INCREMENT=1;";
                    using (MySqlCommand cmd = new MySqlCommand(command, conn)) {
                        conn.Open();
                        int n = cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception e) {

                string error = e.Message;

            }



        }







    }


}




