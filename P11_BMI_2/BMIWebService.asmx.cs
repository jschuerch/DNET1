using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace P11_BMI_2 {
    /// <summary>
    /// Summary description for BMIWebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class BMIWebService : System.Web.Services.WebService {

        [WebMethod(Description = "Returnes the calculated BMI")]
        public double calculateBMI(double weight, double height) {
            return BMI.calculateBMI(weight, height);
        }
    }
}
