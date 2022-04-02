using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Models;

namespace SaatSatış.Models
{
    public class CartItemVM
    {
        public Watch Watch { get; set; }
        public int Quantity { get; set; }
    }
}