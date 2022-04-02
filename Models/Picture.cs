using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Models
{
    public class Picture
    {
        [Display(Name = "Resim")]
        public int PictureID { get; set; }
        [Display(Name = "Resim")]
        public string PictureName { get; set; }
        [Display(Name = "Saat")]
        public int WatchID { get; set; }
        [JsonIgnore]
        public virtual Watch Watch { get; set; }
    }
}
