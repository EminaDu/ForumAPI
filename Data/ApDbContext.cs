using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace ForumAPI.Data
{
    public class ApDbContext: DbContext
    { 
        public ApDbContext(DbContextOptions<ApDbContext> options) : base(options)
        {

        }
        public DbSet<Models.ForumMainCategory> ForumMainCategory { get; set; }
    }
}
