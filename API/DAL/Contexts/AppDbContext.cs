//===================================================
// Date         : 
// Author       : 
// Description  : Application data context
//===================================================
// Revision History:
// Name             Date            Description
//
//===================================================
using API.DAL.Configurations;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.DAL.Contexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> User { get; set; }
        public DbSet<Master> Master { get; set; }
        public DbSet<Detail> Detail { get; set; }
        public DbSet<Common> Common { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MasterConfig());
        }
    }

}