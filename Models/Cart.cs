using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Cart
    {
        public int CartID { get; set; }
        [Display(Name = "Kullanıcı Adı")]
        public int UserID { get; set; }
        [Display(Name = "Saat")]
        public int WatchID { get; set; }
        public int Number { get; set; }
        [JsonIgnore]
        public virtual User User { get; set; }
        [JsonIgnore]
        public virtual Watch Watch { get; set; }
        public bool Active { get; set; }
    }
}
