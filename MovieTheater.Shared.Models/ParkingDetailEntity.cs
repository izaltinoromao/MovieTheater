using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieTheater_Console;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MovieTheater.Shared.Models
{
    public class ParkingDetailEntity
    {
        public ParkingDetailEntity()
        {
        }

        public ParkingDetailEntity(int numberOfSpaces, bool isCovered, bool hasEVChargingStations, MovieTheaterEntity movieTheaterEntity)
        {
            NumberOfSpaces = numberOfSpaces;
            IsCovered = isCovered;
            HasEVChargingStations = hasEVChargingStations;
            MovieTheaterEntity = movieTheaterEntity;
        }

        public int Id { get; set; }
        public int MovieTheaterId { get; set; }

        public int NumberOfSpaces { get; set; }
        public bool IsCovered { get; set; }
        public bool HasEVChargingStations { get; set; }

        public virtual MovieTheaterEntity? MovieTheaterEntity { get; set; }
    }
}
