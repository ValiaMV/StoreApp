using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreApp.Data
{
    public class StoreIdentityContext : IdentityDbContext<StoreUser, IdentityRole, string>
    {
        public StoreIdentityContext(DbContextOptions<StoreIdentityContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole { Name = "Admin", NormalizedName = "Admin", Id = "admin" },
                new IdentityRole { Name = "User", NormalizedName = "User", Id = "user" });

            var hasher = new PasswordHasher<StoreUser>();
            var adminUser = new StoreUser
            {
                Email = "admin@storeapp.valia",
                EmailConfirmed = true,
                NormalizedEmail = "admin@storeapp.valia",
                UserName = "admin@storeapp.valia",
                NormalizedUserName = "admin@storeapp.valia",
                Id = Guid.NewGuid().ToString("D"),
                SecurityStamp = Guid.NewGuid().ToString("D")
            };

            adminUser.PasswordHash = hasher.HashPassword(adminUser, "Admin_1234");

            builder.Entity<StoreUser>().HasData(adminUser);

            builder.Entity<IdentityUserRole<string>>()
                .HasData(new IdentityUserRole<string> { UserId = adminUser.Id, RoleId = "admin" });

            base.OnModelCreating(builder);
        }
    }
}
