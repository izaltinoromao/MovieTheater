using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieTheater_Console;

namespace MovieTheater.Shared.Models
{
    public class TicketEntity
    {
        public TicketEntity()
        {
            Date = DateTime.Now;
        }

        public TicketEntity(string ownerName, MovieTheaterEntity movieTheaterEntity)
        {
            OwnerName = ownerName;
            Date = DateTime.Now;
            MovieTheaterEntity = movieTheaterEntity;
        }

        public int Id { get; set; }
        public string OwnerName { get; set; }
        public DateTime Date { get; private set; }
        public virtual MovieTheaterEntity? MovieTheaterEntity { get; set; }

        public override string ToString()
        {
            return $@"Dono do ingresso: {OwnerName}, data da compra: {Date}";
        }
    }
}
