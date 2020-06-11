using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace simple_web_crud {
    public partial class Index : System.Web.UI.Page {
        
        

        protected void Page_Load(object sender, EventArgs e) {
            MySqlConn m = new MySqlConn();
            m.Load(GridView1);
            
            
            
        }

        protected void Save_Click(object sender, EventArgs e) {
            
            
        }
    }
}