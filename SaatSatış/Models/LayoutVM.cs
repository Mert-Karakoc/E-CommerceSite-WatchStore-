using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Models;

namespace SaatSatış.Models
{
    public class LayoutVM
    {
        public List<Gender> Genders { get; set; }
        public List<Brand> Brands { get; set; }
        public List<Color> Colors { get; set; }
        public List<CaseShape> CaseShapes { get; set; }
        public List<GlassType> GlassTypes { get; set; }
        public List<StrapType> StrapTypes { get; set; }
        public List<Technology> Technologies { get; set; }
    }
}