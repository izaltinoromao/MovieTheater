using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MovieTheater_Console;

namespace MovieTheater.Shared.Data.DB
{
    public class MovieTheaterContext : DbContext
    {
        public DbSet<MovieTheaterEntity> MovieTheaterEntity { get; set; }
        public DbSet<MovieEntity> MovieEntity { get; set; }

        private string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MovieTheater_BD;Integrated Security=True;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }

    }
}
