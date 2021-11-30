using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace CarpathianFurniture.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Furniture> Furnitures { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
          // Database.EnsureDeleted();
          Database.EnsureCreated();
        }

        



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            string adminRoleName = "admin";
            string userRoleName = "user";

            string adminEmail = "admin@gmail.com";
            string adminPassword = "12345678";

            

            // add roles
            Role adminRole = new Role { Id = 1, Name = adminRoleName };
            Role userRole = new Role { Id = 2, Name = userRoleName };

            User adminUser = new User { Id = 1, Email = adminEmail, Password = adminPassword, RoleId = adminRole.Id };

          //  Category categories = new Category { CategoryId = 1, Name = "Sofas", ImagePath = "\\wwwroot\\images\\sofas.jpg" };
           // Furniture furniture = new Furniture { FurnitureId = 1, Title = "Sofa", Price = 60000, Description = "Soft corner sofa", ImagePath = "\\wwwroot\\images\\cheap_and_comfortable_sofa.jpg"};


            modelBuilder.Entity<Role>().HasData(new Role[] { adminRole, userRole });
            modelBuilder.Entity<User>().HasData(new User[] { adminUser });

           // modelBuilder.Entity<Furniture>().HasData(new Furniture[] { furniture });
            base.OnModelCreating(modelBuilder);
          
        }
        
    }
}
