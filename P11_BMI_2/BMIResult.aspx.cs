using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace P11_BMI_2 {
    public partial class BMIResult : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            if (Request.Form.Count == 0) {
                Response.Redirect("BMI.aspx");
                return;
            }
            gewicht2.Text = Request.Form["gewicht"];
            groesse2.Text = Request.Form["gewicht"];
            calculatedBMI.Text = Request.QueryString["bmi"];
            result.Text = BMI.getBMIDiagnosis(Double.Parse(calculatedBMI.Text));
        }
    }
}