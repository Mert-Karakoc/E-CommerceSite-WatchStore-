using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Models;


namespace SaatSatış.DAL
{
    public class WatchContext : DbContext
    {
        public WatchContext()
        {
            Database.SetInitializer(new InitDB());
        }
        public DbSet<Watch> Watches { get; set; }
        public DbSet<CaseShape> CaseShapes { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<GlassType> GlassTypes { get; set; }
        public DbSet<StrapType> StrapTypes { get; set; }
        public DbSet<Technology> Technologies { get; set; }
        public DbSet<Picture> Pictures { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<Color> Colors { get; set; }
    }
}