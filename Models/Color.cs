using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Models
{
    public class Color
    {
        [Display(Name = "Renk")]
        public int ColorID { get; set; }
        [Display(Name = "Renk")]
        public string ColorName { get; set; }

        [JsonIgnore]
        public virtual ICollection<Watch> Watches { get; set; }

    }
}
