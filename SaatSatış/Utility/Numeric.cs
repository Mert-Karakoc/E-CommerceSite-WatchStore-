using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SaatSatış.Utility
{
    public class Numeric : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            string str = value.ToString();
            if (Int32.TryParse(str, out int result) == false)
            {
                return false;
            }
            else

                return true;
        }
    }
}