using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Identity
{
    public partial class MyDBContext : IdentityDbContext<ApplicationUser>
    {
        public MyDBContext(DbContextOptions<MyDBContext> options)
       : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
    public class ApplicationRole : IdentityRole
    {

    }
    public class ApplicationUser : IdentityUser
    {

        public string RedirectToUrl { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.UtcNow;
        public bool IsBlocked { get; set; }
        public string CreateUserId { get; set; }
    }
}
