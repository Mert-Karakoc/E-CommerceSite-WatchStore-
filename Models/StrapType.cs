using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Models
{
    public class StrapType
    {
        [Display(Name = "Kayış Tipi")]
        public int StrapTypeID { get; set; }
        [Display(Name = "Kayış Tipi")]
        public string StrapTypeName { get; set; }
        [JsonIgnore]
        public virtual ICollection<Watch> Watches { get; set; }
    }
}
