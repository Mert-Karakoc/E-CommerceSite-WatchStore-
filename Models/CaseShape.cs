using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class CaseShape
    {
        [Display(Name = "Kasa Şekli")]
        public int CaseShapeID { get; set; }
        [Display(Name = "Kasa Şekli")]
        public string CaseShapeName { get; set; }
        [JsonIgnore]
        public virtual ICollection<Watch> Watches { get; set; }
    }
}
