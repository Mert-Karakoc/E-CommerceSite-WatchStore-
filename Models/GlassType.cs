using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Models
{
    public class GlassType
    {
        [Display(Name = "Cam Türü")]
        public int GlassTypeID { get; set; }
        [Display(Name = "Cam Türü")]
        public string GlassTypeName { get; set; }
        [JsonIgnore]
        public virtual ICollection<Watch> Watches { get; set; }
    }
}
