using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieTheater_Console;

namespace MovieTheater.Shared.Data.DB
{
    public class MovieEntityDAL
    {
        private readonly MovieTheaterContext context;

        public MovieEntityDAL(MovieTheaterContext context)
        {
            this.context = context;
        }

        public IEnumerable<MovieEntity> Read()
        {
            return context.MovieEntity.ToList();
        }

        public void Create(MovieEntity movieEntity)
        {
            context.MovieEntity.Add(movieEntity);
            context.SaveChanges();
        }

        public void Update(MovieEntity movieEntity)
        {
            context.MovieEntity.Update(movieEntity);
            context.SaveChanges();
        }

        public void Delete(MovieEntity movieEntity)
        {
            context.MovieEntity.Remove(movieEntity);
            context.SaveChanges();
        }

        public MovieEntity? ReadByName(string name)
        {
            return context.MovieEntity.FirstOrDefault(x => x.Name == name);
        }

    }
}
