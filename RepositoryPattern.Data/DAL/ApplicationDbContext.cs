using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryPattern.Data.DAL
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Student> Students { get; set; }
        public DbSet<NotificationLog> notificationLogs { get; set; }

        public DbSet<NotificationLogUser> NotificationLogUser { get; set; }

        public DbSet<Blog> Blogs { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Cities> Cities { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Blog>().HasData(
                new Blog { Id = 1, BlogUrl = "http://sample.com" },
                new { Id = 2, BlogUrl = "http://facebook.com" }

                );

            builder.Entity<Employee>().HasData(
                new Employee { EmployeeId = 1, CityId = 1, Department = "JDNT", Gender = "Male", Name = "Ganesh" },
                new Employee { EmployeeId = 2, CityId = 2, Department = "HR", Gender = "Male", Name = "Sanjay" }
                );

            builder.Entity<Cities>().HasData(
               new Cities { CityId = 1, CityName = "KTM" },
               new Cities { CityId = 2, CityName = "Pokhara" }
               );
            base.OnModelCreating(builder);
        }
    }
}
