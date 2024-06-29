using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

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

        public List<MovieEntity> movies = new List<MovieEntity>();

        public void AddMovie(MovieEntity movie)
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
