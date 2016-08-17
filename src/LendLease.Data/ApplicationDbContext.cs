using System;
using LendLease.Models;
using Microsoft.EntityFrameworkCore;
using LendLease.Data;

namespace LendLease.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        //public DbSet<Address> Addresses { get; set; }
        //public DbSet<PaymentInfo> PaymentInfos { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }

        public ApplicationDbContext()
        { }

        //        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //        {
        ////#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
        //            //optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Blogging;Trusted_Connection=True;");
        //        }


        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Customer>(builder =>
        //    {
        //        builder.HasKey(i => i.Id);
        //        builder.Property(b => b.Name).IsRequired();
        //    });
        //}
    }
}
