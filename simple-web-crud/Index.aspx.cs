using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace simple_web_crud {

    public partial class Index : System.Web.UI.Page {

        MySqlConn m = new MySqlConn();
        int SelectedIdItem;
        protected void Page_Load(object sender, EventArgs e) {

           

            if (!IsPostBack) {
                
                m.Load(PageGridView, DropDownListCategory);

            }
            
        }

        protected void Save_Click(object sender, EventArgs e) {
            m.AddOrUpdate(Product, Price, Quantity, DropDownListCategory, LabelSelectedItem, SelectedIdItem);
            m.Load(PageGridView, DropDownListCategory);
           
            
                      
            
        }

        protected void SelectButton_Click(object sender, EventArgs e) {
            int id = Convert.ToInt32((sender as Button).CommandArgument);
            m.SelectProduct(id, Product, Price, Quantity, DropDownListCategory);
            LabelSelectedItem.Text = $"Product: {PageGridView.Rows[id - 1].Cells[1].Text} selected! You can now update or delete this item";
            SelectedIdText.Text = id.ToString();
        }

        protected void Update_Click(object sender, EventArgs e) {
            SelectedIdItem = Convert.ToInt32(SelectedIdText.Text);
            m.AddOrUpdate(Product, Price, Quantity, DropDownListCategory, LabelSelectedItem, SelectedIdItem);
            m.Load(PageGridView, DropDownListCategory);
            SelectedIdItem = 0;
            SelectedIdText.Text = "";

        }

       
    }
}