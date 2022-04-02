using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Models;

namespace SaatSatış.DAL
{
    public class InitDB :DropCreateDatabaseIfModelChanges<WatchContext>
    {
        protected override void Seed(WatchContext context)
        {
            context.Users.Add(new User { UserFirstName = "Cevdet", UserLastName = "Mevdet", UserName = "Admin", Password = "123456", EmailAddress = "cevdet@gmail.com", HomeAddress = "Kadıköy", IdentityNumber = "12345678912", PhoneNumber = "05321648579", Status = "Admin" });
            context.SaveChanges();
        }
    }
}