using System;
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
            //only works when theres no product selected
            if (Product.Text == "" || Price.Text == "" || Quantity.Text == "") {
                Message.Text = "You must fill all the blank fields before save a product";
            }
            else if(SelectedIdText.Text == "") {
                m.AddOrUpdate(Product, Price, Quantity, DropDownListCategory, SelectedIdText, 0);
                m.Load(PageGridView, DropDownListCategory);
                Clear();
                Message.Text = "Product saved!";
            }
            else {
                Message.Text = "You cannot save selected products";
            }





        }

        protected void SelectButton_Click(object sender, EventArgs e) {
            //get the id from product selected and set it into a label 
            int id = Convert.ToInt32((sender as Button).CommandArgument);
            m.SelectProduct(id, Product, Price, Quantity, DropDownListCategory);
            string item = Product.Text;
            Message.Text = $"Product: {item} selected! You can now update or delete this item";
            SelectedIdText.Text = id.ToString();
        }

        protected void Update_Click(object sender, EventArgs e) {

            if (SelectedIdText.Text == "") {
                Message.Text = "Select one product first";
            }
            else {
                //get the id from product selected and use it to update DB
                int id = Convert.ToInt32(SelectedIdText.Text);
                m.AddOrUpdate(Product, Price, Quantity, DropDownListCategory, Message, id);
                m.Load(PageGridView, DropDownListCategory);
                //clear id and text from labels after update
                SelectedIdText.Text = "";
                Message.Text = $"{PageGridView.Rows[id - 1].Cells[1].Text} Updated !";
                Clear();

            }


        }

        protected void Delete_Click(object sender, EventArgs e) {

            if (SelectedIdText.Text == "") {
                Message.Text = "Select one product first";
            }
            else {
                string item = Product.Text;
                int id = Convert.ToInt32(SelectedIdText.Text);
                m.Delete(id);
                m.Load(PageGridView, DropDownListCategory);
                SelectedIdText.Text = "";
                Message.Text = $"{item} DELETED !";
                Clear();
            }



        }






        public void Clear() {
            Product.Text = "";
            Price.Text = "";
            Quantity.Text = "";
        }


    }
}