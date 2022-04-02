using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Models;

namespace SaatSatış.Models
{
    public class WatchVM
    {
        public Watch Watch { get; set; }
        public ICollection<Picture> Pictures { get; set; }
    }
}