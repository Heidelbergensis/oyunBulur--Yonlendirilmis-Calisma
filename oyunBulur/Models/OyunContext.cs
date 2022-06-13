using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.Entity;

namespace oyunBulur.Models
{
    public class OyunContext : DbContext
    {
        public OyunContext() : base("ConnectionString")
        {
            this.Configuration.LazyLoadingEnabled = true;
            this.Configuration.ProxyCreationEnabled = false;
            Database.SetInitializer<OyunContext>(new DropCreateDatabaseAlways<OyunContext>());

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<OyunContext>(null);
            base.OnModelCreating(modelBuilder);

        }



        public DbSet<Oyun> Oyun { get; set; }
        public DbSet<Oneri> Oneri { get; set; }
        public DbSet<Tur> Tur { get; set; }
        public DbSet<Perspektif> Perspektif { get; set; }
        public DbSet<Platform> Platform { get; set; }
        public DbSet<Tema> Tema { get; set; }
        public DbSet<Mod> Mod { get; set; }
        public DbSet<TestViewModel> TestViewModel { get; set; }

    }
}