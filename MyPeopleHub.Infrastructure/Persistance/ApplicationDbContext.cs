﻿using Microsoft.EntityFrameworkCore;
using MyPeopleHub.Domain.Entities;

namespace MyPeopleHub.Infrastructure.Persistance
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasKey(x => x.Id);
        }
    }
}
