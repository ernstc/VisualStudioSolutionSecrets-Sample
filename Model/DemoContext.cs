using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;


namespace VisualStudioSolutionSecrets_Sample.Model
{
    public class DemoContext : DbContext
    {
        public virtual DbSet<Product> Products { get; set; }


        public DemoContext(DbContextOptions<DemoContext> options)
           : base(options)
        { }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            foreach (var item in optionsBuilder.Options.Extensions)
            {
                if (item is RelationalOptionsExtension extension)
                {
                    optionsBuilder.UseSqlServer(extension.ConnectionString);
                    break;
                }
            }
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Map_Product(modelBuilder);
        }


        private void Map_Product(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Products", "dbo");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });
        }
    }
}
