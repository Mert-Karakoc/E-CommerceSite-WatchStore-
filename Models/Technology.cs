using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Models
{
    public class Technology
    {
        [Display(Name = "Teknoloji")]
        public int TechnologyID { get; set; }
        [Display(Name = "Teknoloji")]
        public string TechnologyName { get; set; }
        [JsonIgnore]
        public virtual ICollection<Watch> Watches { get; set; }

    }
}
