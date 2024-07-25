using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MovieTheater.Shared.Data.Models;
using MovieTheater.Shared.Models;
using MovieTheater_Console;

namespace MovieTheater.Shared.Data.DB
{
    public class MovieTheaterContext : IdentityDbContext<AccessUser, AccessRole, int>
    {
        public DbSet<MovieTheaterEntity> MovieTheaterEntity { get; set; }
        public DbSet<MovieEntity> MovieEntity { get; set; }
        public DbSet<TicketEntity> TicketEntity { get; set; }

        private string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MovieTheater_BD_V1;Integrated Security=True;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString).UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}
