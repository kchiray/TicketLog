using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TicketLog.Models;

namespace TicketLog.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Statistic> Statistics { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ticket>().ToTable("Ticket");
            modelBuilder.Entity<Ticket>().ToTable("Statistic");
            base.OnModelCreating(modelBuilder);
        }
    }
}
