using Microsoft.EntityFrameworkCore;
using PriorityList.Domain.Entity;
using PriorityList.Domain.Repository.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace PriorityList.Infastructure.Persistance
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext([NotNullAttribute] DbContextOptions options) : base(options)
        {
        }

        public DbSet<ToDoItem> ToDoItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ToDoItem>(etb =>
            {
                etb.HasKey(e => e.Id);
                etb.Property(e => e.Id).UseSqlServerIdentityColumn();
                etb.Property(e => e.Id).ValueGeneratedOnAdd();
                etb.Property(e => e.Description).IsRequired();
                etb.Property(e => e.PriorityNumber); 
            });

            modelBuilder.Entity<ToDoItem>().HasIndex().IsUnique();

            base.OnModelCreating(modelBuilder);
        } 

    }
}
