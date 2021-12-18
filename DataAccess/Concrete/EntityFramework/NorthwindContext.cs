using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{

    //Db tabloları ile proje class larını ilişkilendiriyoruz
   public  class NorthwindContext:DbContext
    {
        /// <summary>
        /// Bu method senin projenin hangi veri tabanı ile ilişkili olduğunu belirttiğimiz yer
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=Northwind;Trusted_Connection=true");
            
        }

        /// <summary>
        /// hangi sınıfın hangi tablo ile eşleştirileceğini yazıyoruz
        /// </summary>
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    // fluent mapping
        //    modelBuilder.Entity<Personel>().ToTable("Employees");
        //    // eşleştirme işlemini diğer property ler için de yapabilirsin.
        //    modelBuilder.Entity<Personel>().Property(p => p.ID).HasColumnName("EmployeeID");
        //}

    }

}
