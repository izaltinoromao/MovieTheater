using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using MovieTheater.Shared.Models;

namespace MovieTheater_Console
{
    public class MovieTheaterEntity
    {

        public MovieTheaterEntity(string name, string address)
        {
            Name = name;
            Address = address;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        public virtual ParkingDetailEntity ParkingDetailEntity { get; set; }

        public virtual ICollection<MovieEntity> Movies { get; set; }

        public virtual ICollection<TicketEntity> Tickets { get; set; }


        public override string ToString()
        {
            return $@"Nome: {Name}";
        }

    }
}
