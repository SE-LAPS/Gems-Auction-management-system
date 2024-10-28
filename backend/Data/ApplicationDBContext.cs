﻿using backend.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace backend.Data
{
    public class ApplicationDBContext : IdentityDbContext<User>
    {
        public ApplicationDBContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //Art Model Relations
            builder.Entity<Art>(x => x.HasKey(p => new { p.Id }));

            builder.Entity<Art>()
            .HasOne(a => a.Store)
            .WithMany(u => u.Arts)
            .HasForeignKey(a => a.StoreId)
            .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Art>()
             .HasOne(a => a.Category)
             .WithMany(u => u.Arts)
             .HasForeignKey(a => a.CategoryId)
             .OnDelete(DeleteBehavior.Restrict);

            //Auction Model Relations
            builder.Entity<Auction>()
                .HasOne(a => a.Art)
                .WithOne(u => u.Auction)
                .HasForeignKey<Auction>(a => a.ArtId)
                .OnDelete(DeleteBehavior.Restrict);

            //Bid Model Relations
            builder.Entity<Bid>()
                .HasOne(a => a.Auction)
                .WithMany(u => u.Bids)
                .HasForeignKey(a => a.AuctionId)
                .OnDelete(DeleteBehavior.Restrict);

            //Store Model Relations
            builder.Entity<Store>(x => x.HasKey(p => new { p.Id }));

            builder.Entity<Store>()
                .HasOne(a => a.User)
                .WithOne(u => u.Store)
                .HasForeignKey<Store>(a => a.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            List<IdentityRole> roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                new IdentityRole
                {
                    Name = "User",
                    NormalizedName = "USER"
                }
            };
            builder.Entity<IdentityRole>().HasData(roles);
        }
        public DbSet<Store> Store { get; set; }
        public DbSet<Art> Art { get; set; }
        public DbSet<Auction> Auction { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Bid> Bid { get; set; }


    }
}
