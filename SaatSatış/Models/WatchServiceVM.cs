using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SaatSatış.Models
{
    public class WatchServiceVM
    {
        public int WatchID { get; set; }
        public string WatchModel { get; set; }
        public string BrandName { get; set; }
        public string CaseShapeName { get; set; }
        public string ColorName { get; set; }
        public string GenderName { get; set; }
        public string GlassTypeName { get; set; }
        public string StrapTypeName { get; set; }
        public string TechnologyName { get; set; }
        public decimal Price { get; set; }

    }
}