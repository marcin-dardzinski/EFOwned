using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EFOwned
{
    class Program
    {
        static void Main(string[] args)
        {

        }
    }

    class MyDbContext : DbContext
    {
        public DbSet<Parent> Parents => Set<Parent>();

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options
                .UseSqlServer("Server=server;Database=db;User Id=sa;Password = password;");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Parent>(cfg =>
            {
                cfg.OwnsMany(e => e.Children, child =>
                {
                    child.WithOwner()
                        .HasForeignKey(e => e.ParentId);
                });

                // cfg.HasMany(e => e.Children)
                //     .WithOne()
                //     .HasForeignKey(e => e.ParentId);
            });
        }
    }

    class Parent
    {
        public Guid Id { get; set; }
        public List<Child> Children { get; set; }
    }

    class Child
    {
        public Guid Id { get; set; }
        public Guid ParentId { get; set; }
    }
}
