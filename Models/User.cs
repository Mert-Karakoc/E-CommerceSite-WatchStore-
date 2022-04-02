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
    public class User
    {
        [Display(Name = "Kullanıcı")]
        public int UserID { get; set; }
        [Required]
        [Index(IsUnique = true)]
        [StringLength(20)]
        [Display(Name = "Kullanıcı Adı")]
        public string UserName { get; set; }
        [Required]
        [Display(Name = "Şifre")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [StringLength(11)]
        [Index(IsUnique = true)]
        [RegularExpression("([0-9]+)", ErrorMessage = "Sadece sayı içermelidir.")]
        [Display(Name = "T.C. Kimlik Numarası")]
        //[Range(10, 12, ErrorMessage = "11 Karakter uzunluğunda olmalı.")]
        public string IdentityNumber { get; set; }
        [Required]
        [Display(Name = "Ad")]
        public string UserFirstName { get; set; }
        [Required]
        [Display(Name = "Soyad")]
        public string UserLastName { get; set; }
        [Required]
        [Display(Name = "Adres")]
        public string HomeAddress { get; set; }
        [Required]
        [Index(IsUnique = true)]
        [StringLength(11,ErrorMessage = "11 Karakter uzunluğunda olmalı.")]
        [Display(Name = "Telefon Numarası")]
        //[Range(10,12, ErrorMessage = "11 Karakter uzunluğunda olmalı.")]
        public string PhoneNumber { get; set; }
        [Required]
        [EmailAddress]
        [Index(IsUnique = true)]
        [StringLength(40)]
        [Display(Name = "E-mail")]
        public string EmailAddress { get; set; }
        [Display(Name = "Admin")]
        public string Status { get; set; }
        [Display(Name = "Sepet")]
        [JsonIgnore]
        public virtual ICollection<Cart> Cart { get; set; }

    }
}
