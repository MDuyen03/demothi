using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using demothi.Models;

namespace demothi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<demothi.Models.lam1> lam1 { get; set; } = default!;
        public DbSet<demothi.Models.lam2> lam2 { get; set; } = default!;
    }
}
