using Seranet.Spec.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace Seranet.Spec.Data
{
    public class SpecDbContext: DbContext
    {

        public SpecDbContext() : base("SpecDbContext")
        {
        }

        public DbSet<Level> Levels { get; set; }
        public DbSet<Area> Areas { get; set; }
        public DbSet<SubArea> SubAreas { get; set; }
        public DbSet<Practice> Practices { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}