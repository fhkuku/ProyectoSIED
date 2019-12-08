using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace SIED.Models
{
    public class alertas
    {

        public string SweetAlert(string[]data) {
            String  alert = "";
            if (data[0].ToString() == "reload")
            {
                alert = "Swal.fire({" +
                    "type: '" + data[1].ToString() + "'," +
                    "title: '" + data[2].ToString() + "'," +
                    "text: '" + data[3].ToString() + "'," +
                    "confirmButtonText:'Accepter'" +
                    "}).then((result) => {" +
                    "if(result.value){" +
                    "location.reload();" +
                    "}" +
                    "});;";
            }
            else if (data[0].ToString() == "simple")
            {
                alert = "Swal.fire({" +
                    "type: '" + data[1].ToString() + "'," +
                    "title: '" + data[2].ToString() + "'," +
                    "text: '" + data[3].ToString() +
                    "'});";

            }
            else if (data[0].ToString() == "clean") { 
                alert = "Swal.fire({" +
                    "title: '"+ data[2].ToString()+"'," +
                    "text: '" + data[3].ToString() + "'," +
                    "type: '" + data[1].ToString() + "'," +
                    "confirmButtonText: 'Accepter'" +
                    "}).then((result) => {" +
                    "if (result.value){" +
                    "$('.FormAjax')[0].reset();" +
                    "table.ajax.reload(null, false);"+
                    "}" +
                    "});";
            }
            return alert;
        
        
        }


    }
}