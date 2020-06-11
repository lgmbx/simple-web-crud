using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace simple_web_crud {
    public class MySqlConn {
        
        static readonly string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["SimpleWebCrud"].ToString();

       
        public void Load(GridView gv) {
            using (MySqlConnection conn = new MySqlConnection(connectionString)) {
                string command = "SELECT Name, Price, Quantity, CategoryName FROM products, category WHERE products.CategoryId = category.Id";
                using (MySqlCommand cmd = new MySqlCommand(command)) {
                    using(MySqlDataAdapter da = new MySqlDataAdapter()) {
                        cmd.Connection = conn;
                        da.SelectCommand = cmd;
                        using(DataTable dt = new DataTable()) {
                            da.Fill(dt);
                            gv.DataSource = dt;
                            gv.DataBind();
                        }
                    }
                    
                }
            }
        }

        
    }
}