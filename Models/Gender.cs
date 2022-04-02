using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Models
{
    public class Gender
    {
        [Display(Name = "Cinsiyet")]
        public int GenderID { get; set; }
        [Display(Name = "Cinsiyet")]
        public string GenderName { get; set; }
        [JsonIgnore]
        public virtual ICollection<Watch> Watches { get; set; }
    }
}
