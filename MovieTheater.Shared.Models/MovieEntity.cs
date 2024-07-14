using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTheater_Console
{
    public class MovieEntity
    {
        public MovieEntity()
        {
        }

        public MovieEntity(string name, int duration, ICollection<MovieTheaterEntity> movieTheaters)
        {
            Name = name;
            Duration = duration;
            MovieTheaters = movieTheaters;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Duration { get; set; }
        public virtual ICollection<MovieTheaterEntity> MovieTheaters { get; set; }

        public override string ToString()
        {
            return $@"Filme: {Name}";
        }
    }
}
