using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Web;

namespace GigHubMVC.ViewModels
{
    public class FutureDate : ValidationAttribute
    {
        public override bool IsValid(object value)      // kano override tin IsValid tis ValidationAttribute
        {
            DateTime dateTime;

            
            var isValid = DateTime.TryParseExact(Convert.ToString(value),   //metatrepo to object se string kai
                "dd MMM yyyy",      //tsekarei an einai se format "dd MMM yyyy"
                DateTimeFormatInfo.InvariantInfo,   //aneksartita apo pias xoras format tou dinouyme
                DateTimeStyles.None,    //mas to epistrefei sto default Style
                out dateTime);      //kai tha mas to epistrepsei an einai true o elegxos tou format

            //an girisei san apotelesma false kai to exo valei san annotation sto date tha petaksei minima pos to field Date einai invalid
            return (isValid && (dateTime > DateTime.Now));
        }
    }
}