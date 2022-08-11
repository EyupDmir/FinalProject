using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    //Context = Db tabloları ile proje classlarını bağlamak
    public class NorthwindContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server =(localdb)\mssqllocaldb;Database=Northwind;Trusted_Connection=true");
            //başına @ yazıyoruz çünkü ters slashın(\) stringin içinde veya dışındada yazsak bir anlamı var.
            //C# ta \ kullanacağımız yerlerde çift kullanıyoruz. Bu ters slaşı normal olan \ anla demektir.
        
        }
        //Hangi veritabanındaki hangi tabloya hangi veri denk gelicek
        //Product Products'a karşılık gelicek
        //Category Categories'e karşılık gelicek
        //Customer Customers'e karşılık gelicek
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }

    }
}
