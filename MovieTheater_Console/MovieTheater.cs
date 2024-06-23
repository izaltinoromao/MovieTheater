using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace MovieTheater_Console
{
    internal class MovieTheater
    {

        public MovieTheater(string name, string address)
        {
            Name = name;
            Address = address;
        }

        public string Name { get; set; }
        public string Address { get; set; }

        public List<Movie> movies = new List<Movie>();

        public void AddMovie(Movie movie)
        {
            movies.Add(movie);
        }

        public void ShowMovies()
        {
            Console.WriteLine($"Filmes passandro em {Name}:");
            foreach (var movie in movies)
            {
                Console.WriteLine(movie);
            }
        }

        public override string ToString()
        {
            return $@"Nome: {Name}";
        }

    }
}
