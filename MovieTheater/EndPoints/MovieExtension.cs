using MovieTheater.Requests;
using MovieTheater.Shared.Data.DB;
using MovieTheater_Console;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MovieTheater.Responses;

namespace MovieTheater.EndPoints
{
    public static class MovieExtension
    {
        public static void AddEndPointsMovie(this WebApplication app)
        {
            var groupBuilder = app.MapGroup("movie")
                .RequireAuthorization()
                .WithTags("Movie");


            groupBuilder.MapGet("", ([FromServices] DAL<MovieEntity> dal) =>
            {
                var movieEntityList = dal.Read();
                if (movieEntityList is null) return Results.NotFound();
                var movieResponseList = EntityListToResponseList(movieEntityList);
                return Results.Ok(movieResponseList);
            });

            groupBuilder.MapGet("/{id}", ([FromServices] DAL<MovieEntity> dal, int id) =>
            {
                var movieEntity = dal.ReadBy(a => a.Id == id);
                if (movieEntity is null) return Results.NotFound();
                return Results.Ok(EntityToResponse(movieEntity));
            });

            groupBuilder.MapPost("", ([FromServices] DAL<MovieEntity> movieDal, [FromServices] DAL <MovieTheaterEntity> theaterDal, [FromBody] MovieRequest movieRequest) =>
            {
                ICollection<MovieTheaterEntity> movieTheaterEntityList = new List<MovieTheaterEntity>();

                foreach (int theaterId in movieRequest.MovieTheaterIds)
                {
                    var movieTheater = theaterDal.ReadBy(t => t.Id == theaterId);
                    if (movieTheater is null) return Results.NotFound("Movie theater with id: " + theaterId + " not found.");
                    else movieTheaterEntityList.Add(movieTheater);
                }

                var movieEntity = new MovieEntity(movieRequest.name, movieRequest.duration, movieTheaterEntityList);

                movieDal.Create(movieEntity);

                var resourceUrl = $"/movie/{movieEntity.Id}";
                return Results.Created(resourceUrl, EntityToResponse(movieEntity));
            });

            groupBuilder.MapDelete("/{id}", ([FromServices] DAL<MovieEntity> dal, int id) =>
            {
                var movie = dal.ReadBy(m => m.Id == id);
                if (movie is null) return Results.NotFound();
                dal.Delete(movie);
                return Results.NoContent();
            });

            groupBuilder.MapPut("", ([FromServices] DAL<MovieEntity> dal, [FromBody] MovieEditRequest movieEditRequest) =>
            {
                var movieToEdit = dal.ReadBy(m => m.Id == movieEditRequest.id);
                if (movieToEdit is null) return Results.NotFound();
                movieToEdit.Name = movieEditRequest.name;
                movieToEdit.Duration = movieEditRequest.duration;
                dal.Update(movieToEdit);
                return Results.Ok();
            });
        }

        private static ICollection<MovieResponse> EntityListToResponseList(IEnumerable<MovieEntity> movieEntityList)
        {
            return movieEntityList.Select(a => EntityToResponse(a)).ToList();
        }
        private static MovieResponse EntityToResponse(MovieEntity movieEntity)
        {
            return new MovieResponse(
                movieEntity.Id,
                movieEntity.Name ?? string.Empty,
                movieEntity.Duration,
                movieEntity.MovieTheaters?.Select(mt => mt.ToResponse()).ToList() ?? new List<MovieTheaterResponse>());
        }

        public static MovieTheaterResponse ToResponse(this MovieTheaterEntity entity)
        {
            return new MovieTheaterResponse(
                entity.Id,
                entity.Name ?? string.Empty,
                entity.Address ?? string.Empty);
        }
    }
}
