using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using MvcApplication1.Models;

namespace MvcApplication1.DAL
{
    public class ColorPickerContext : DbContext
    {
        public ColorPickerContext() : base("ColorPickerContext")
        { 
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Color> Colors { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}