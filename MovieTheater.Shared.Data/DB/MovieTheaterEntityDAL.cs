using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using MovieTheater_Console;

namespace MovieTheater.Shared.Data.DB
{
    public class MovieTheaterEntityDAL
    {

        private readonly MovieTheaterContext context;

        public MovieTheaterEntityDAL(MovieTheaterContext context)
        {
            this.context = context;
        }

        public IEnumerable<MovieTheaterEntity> Read()
        {
            return context.MovieTheaterEntity.ToList();
        }

        public void Create(MovieTheaterEntity movieTheaterEntity)
        {
            context.MovieTheaterEntity.Add(movieTheaterEntity);
            context.SaveChanges();
        }

        public void Update(MovieTheaterEntity movieTheaterEntity)
        {
            context.MovieTheaterEntity.Update(movieTheaterEntity);
            context.SaveChanges();
        }

        public void Delete(MovieTheaterEntity movieTheaterEntity)
        {
            context.MovieTheaterEntity.Remove(movieTheaterEntity);
            context.SaveChanges();
        }

        public MovieTheaterEntity? ReadByName(string name)
        {
            return context.MovieTheaterEntity.FirstOrDefault(x => x.Name == name);
        }

    }
}
