using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using mts.Domain.Entities;

namespace mts.Domain
{
    public class DBContext: IdentityDbContext<IdentityUser>
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options) { }

        public DbSet<CitysBase> citys { get; set; }
        public DbSet<TarifsBase> tarifs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = "44546A06-9178-D4CE-B87A-31AC279D6EAB",
                Name = "admin",
                NormalizedName = "ADMIN"
            }) ;

            modelBuilder.Entity<IdentityUser>().HasData(new IdentityUser
            {
                Id = "546A0644-B87A-79D6-9178-31AC2ED4CEAB",
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                Email = "my@email.com",
                NormalizedEmail = "MY@EMAIL.COM",
                EmailConfirmed = true,
                PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null,"superpassword"),
                SecurityStamp = string.Empty
            });

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = "44546A06-9178-D4CE-B87A-31AC279D6EAB",
                UserId = "546A0644-B87A-79D6-9178-31AC2ED4CEAB"
            });

            modelBuilder.Entity<CitysBase>().HasData(new CitysBase
            {
                Id = new Guid("DA051EC8-DA2E-4A66-B542-473B8D221AB4"),
                ID_city = "22",
                Title = "Волгоградская область",
                Fias = "da051ec8-da2e-4a66-b542-473b8d221ab4",
            }) ;

            modelBuilder.Entity<TarifsBase>().HasData(new TarifsBase
            {
                Id = new Guid("051EC8DA-4A66-DA2E-B542-47221AB3B8D4"),
                Internet =  "100",
                Title = "ФИТ Интернет 100 + ЦТВ",
                Price = "550"
            });
        }
    }
}
