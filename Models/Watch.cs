using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Watch
    {
        [Display(Name = "Saat")]
        public int WatchID { get; set; }
        [Display(Name = "Marka")]
        public int BrandID { get; set; }
        [Display(Name = "Model")]
        public string WatchModel { get; set; }
        [Display(Name = "Renk")]
        public int ColorID { get; set; }
        [Display(Name = "Kasa Şekli")]
        public int CaseShapeID { get; set; }
        [Display(Name = "Cam Türü")]
        public int GlassTypeID { get; set; }
        [Display(Name = "Kayış Tipi")]
        public int StrapTypeID { get; set; }
        [Display(Name = "Teknoloji")]
        public int TechnologyID { get; set; }
        [Display(Name = "Cinsiyet")]
        public int GenderID { get; set; }
        [Display(Name = "Fiyat")]
        public decimal Price { get; set; }

        [Display(Name = "Resim")]
        [JsonIgnore]
        public virtual ICollection<Picture> Pictures { get; set; }
        
        [Display(Name = "Marka")]
        [JsonIgnore]
        public virtual Brand Brand { get; set; }
        [Display(Name = "Kasa Şekli")]
        [JsonIgnore]
        public virtual CaseShape CaseShape { get; set; }
        [Display(Name = "Cam Türü")]
        [JsonIgnore]
        public virtual GlassType GlassType { get; set; }
        [Display(Name = "Kayış Tipi")]
        [JsonIgnore]
        public virtual StrapType StrapType { get; set; }
        [Display(Name = "Teknoloji")]
        [JsonIgnore]
        public virtual Technology Technology { get; set; }
        [Display(Name = "Cinsiyet")]
        [JsonIgnore]
        public virtual Gender Gender { get; set; }
        [Display(Name = "Renk")]
        [JsonIgnore]
        public virtual Color Color { get; set; }
    }
}
