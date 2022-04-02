using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Brand
    {
        [Display(Name = "Marka")]
        public int BrandID { get; set; }
        [Display(Name = "Marka")]
        public string BrandName { get; set; }
        [JsonIgnore]
        public virtual ICollection<Watch> Watches { get; set; }
    }
}
