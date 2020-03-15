using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace P11_BMI_2 {
    public partial class TestCounter : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {

        }

        protected void Button1_Click(object sender, EventArgs e) {
            if (Session["click"] == null) {
                Session["click"] = 0;
            } else if (((int) Session["Click"]) >= 3) {
                return;
            }
            Session["click"] = ((int) Session["click"]) + 1;
            if (((int) Session["click"])%2 == 0) {
                Label1.Text = "Grad " + Session["click"];
            } else {
                Label1.Text = "Ungrad " + Session["click"];
            }

            switch(Session["click"]) {
                case 1: case 2:
                    Label1.Text += " Bitch";
                    break;
                case 3:
                    Label1.Text += " Brudi";
                    break;
            }
        }
    }
}