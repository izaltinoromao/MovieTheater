using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTheater_Console
{
    public class MovieEntity
    {
        public MovieEntity(string name, int duration)
        {
            Name = name;
            Duration = duration;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Duration { get; set; }

        public override string ToString()
        {
            return $@"Filme: {Name}";
        }
    }
}
