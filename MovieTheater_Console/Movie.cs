using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTheater_Console
{
    internal class Movie
    {
        public Movie(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
        public int Duration { get; set; }

        public override string ToString()
        {
            return $@"Filme: {Name}";
        }
    }
}
