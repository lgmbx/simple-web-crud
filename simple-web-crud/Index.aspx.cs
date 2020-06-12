using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace simple_web_crud {
    public partial class Index : System.Web.UI.Page {

        MySqlConn m = new MySqlConn();

        protected void Page_Load(object sender, EventArgs e) {

           

            if (!IsPostBack) {
                
                m.Load(PageGridView, DropDownListCategory);

            }
            
        }

        protected void Save_Click(object sender, EventArgs e) {
            
            m.AddProducts(Product, Price, Quantity, DropDownListCategory);
            m.Load(PageGridView, DropDownListCategory);

        }

        protected void SelectButton_Click(object sender, EventArgs e) {
            int i = Convert.ToInt32((sender as Button).CommandArgument);
        }
    }
}