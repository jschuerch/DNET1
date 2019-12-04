using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace P11_BMI_2 {
    public partial class BMI : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
            ScriptManager.ScriptResourceMapping.AddDefinition("jquery",
                new ScriptResourceDefinition {
                    Path = "~/scripts/jquery-1.7.2.min.js",
                    DebugPath = "~/scripts/jquery-1.7.2.min.js",
                    CdnPath = "http://ajax.aspnetcdn.com/ajax/jQuery/jquery-1.4.1.min.js",
                    CdnDebugPath = "http://ajax.aspnetcdn.com/ajax/jQuery/jquery-1.4.1.js"
                });
        }

        protected void Button1_Click(object sender, EventArgs e) {
            if(Page.IsValid) {
                var weight = Double.Parse(gewicht.Text);
                var height = Double.Parse(groesse.Text);
                var bmi = calculateBMI(weight, height);
                calculatedBMI.Text = "<b>BMI:</b> " + bmi.ToString();
                result.Text = getBMIDiagnosis(bmi);
                Server.Transfer("BMIResult.aspx?bmi="+bmi.ToString(), true);
            }
        }

        protected void Reset_Click(object sender, EventArgs e) {
            gewicht.Text = "";
            groesse.Text = "";
            calculatedBMI.Text = "";
            result.Text = "";
            RequiredFieldValidator1.IsValid = true;
            RangeValidator1.IsValid = true;
            RequiredFieldValidator2.IsValid = true;
            RangeValidator2.IsValid = true;
        }

        public static double calculateBMI(double weight, double height) {
            return (weight / (height * height) * 10000);
        }

        public static string getBMIDiagnosis(double bmi) {
            string diagnosis;
            if(bmi < 20) {
                diagnosis = "Untergewicht";
            } else if(bmi < 25) {
                diagnosis = "Normalgewicht";
            } else if(bmi < 30) {
                diagnosis = "leichtes bis mässiges Übergewicht";
            } else if(bmi < 40) {
                diagnosis = "deutliches Übergewicht";
            } else {
                diagnosis = "sehr starkes Übergewicht";
            }
            return diagnosis;
        }
    }
}
