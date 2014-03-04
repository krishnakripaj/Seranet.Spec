using Seranet.SpecM2.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace Seranet.SpecM2.Data
{
    public class SpecDbContext: DbContext
    {

        public SpecDbContext() : base("SpecDbContext")
        {
        }

        public DbSet<Project> Projects { get; set; }
        public DbSet<Level> Levels { get; set; }
        public DbSet<Area> Areas { get; set; }
        public DbSet<SubArea> SubAreas { get; set; }
        public DbSet<Practice> Practices { get; set; }
        public DbSet<Claim> Claims { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}