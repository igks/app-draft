//===================================================
// Date         : 
// Author       : 
// Description  : Application data context
//===================================================
// Revision History:
// Name             Date            Description
//
//===================================================
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.DAL.Contexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> User { get; set; }
    }
}