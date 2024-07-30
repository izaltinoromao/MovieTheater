using MovieTheater.Requests;
using MovieTheater.Shared.Data.DB;
using MovieTheater_Console;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MovieTheater.Responses;
using MovieTheater.Shared.Models;

namespace MovieTheater.EndPoints
{
    public static class MovieTheaterExtension
    {
        public static void AddEndPointsMovieTheater(this WebApplication app)
        {
            var groupBuilder = app.MapGroup("movie-theater")
                .RequireAuthorization()
                .WithTags("MovieTheater");

            groupBuilder.MapGet("", ([FromServices] DAL<MovieTheaterEntity> dal) =>
            {
                var movieTheaterEntityList = dal.Read();
                if (movieTheaterEntityList is null) return Results.NotFound();
                var movieTheaterResponseList = EntityListToResponseList(movieTheaterEntityList);
                return Results.Ok(movieTheaterResponseList);
            });

            groupBuilder.MapGet("/{id}", ([FromServices] DAL<MovieTheaterEntity> dal, int id) =>
            {
                var movieTheaterEntity = dal.ReadBy(a => a.Id == id);
                if (movieTheaterEntity is null) return Results.NotFound();
                return Results.Ok(EntityToResponse(movieTheaterEntity));
            });

            groupBuilder.MapGet("/details/{id}", ([FromServices] DAL<MovieTheaterEntity> dal, int id) =>
            {
                var movieTheaterEntity = dal.ReadBy(a => a.Id == id);
                if (movieTheaterEntity is null) return Results.NotFound("Movie theater not found");


                ParkingDetailMovieTheaterResponse parkingDetail = null;
                if (movieTheaterEntity.ParkingDetailEntity != null)
                {
                    parkingDetail = new ParkingDetailMovieTheaterResponse(
                        movieTheaterEntity.ParkingDetailEntity.Id,
                        movieTheaterEntity.ParkingDetailEntity.NumberOfSpaces,
                        movieTheaterEntity.ParkingDetailEntity.IsCovered,
                        movieTheaterEntity.ParkingDetailEntity.HasEVChargingStations
                    );
                }

                var moviesStaring = MovieEntityListToResponseList(movieTheaterEntity.Movies);
                var validTickets = TicketEntityListToResponseList(movieTheaterEntity.Tickets);
                validTickets = ValidateTicketsExpiration(validTickets);
                
                var movieTheaterDetailResponse = new MovieTheaterDetailResponse(movieTheaterEntity.Id,
                    movieTheaterEntity.Name,
                    movieTheaterEntity.Address,
                    parkingDetail,
                    moviesStaring,
                    validTickets
                    );

                return Results.Ok(movieTheaterDetailResponse);
            });

            groupBuilder.MapGet("/movies/{movieName}", async ([FromServices] DAL<MovieTheaterEntity> dal, string movieName) =>
            {
                var movieTheaterEntities = dal.Read();
                var theatersWithMovie = movieTheaterEntities
                    .Where(theater => theater.Movies.Any(movie => movie.Name.Equals(movieName, StringComparison.OrdinalIgnoreCase)))
                    .ToList();

                if (!theatersWithMovie.Any()) return Results.NotFound();
                return Results.Ok(theatersWithMovie.Select(EntityToResponse));
            });

            groupBuilder.MapPost("", ([FromServices] DAL<MovieTheaterEntity> dal, [FromBody] MovieTheaterRequest movieTheaterRequest) =>
            {
                var movieTheaterEntity = new MovieTheaterEntity(movieTheaterRequest.name, movieTheaterRequest.address);

                dal.Create(movieTheaterEntity);

                var resourceUrl = $"/movie-theater/{movieTheaterEntity.Id}";
                return Results.Created(resourceUrl ,EntityToResponse(movieTheaterEntity));
            });

            groupBuilder.MapDelete("/{id}", ([FromServices] DAL<MovieTheaterEntity> dal, int id) =>
            {
                var movieTheater = dal.ReadBy(m => m.Id == id);
                if (movieTheater is null) return Results.NotFound();
                dal.Delete(movieTheater);
                return Results.NoContent();
            });

            groupBuilder.MapPut("", ([FromServices] DAL<MovieTheaterEntity> dal, [FromBody] MovieTheaterEditRequest movieTheaterEditRequest) =>
            {
                var movieTheaterToEdit = dal.ReadBy(m => m.Id == movieTheaterEditRequest.id);
                if (movieTheaterToEdit is null) return Results.NotFound();
                movieTheaterToEdit.Name = movieTheaterEditRequest.name;
                movieTheaterToEdit.Address = movieTheaterEditRequest.address;
                dal.Update(movieTheaterToEdit);
                return Results.Ok();
            });
        }

        private static ICollection<MovieTheaterResponse> EntityListToResponseList(IEnumerable<MovieTheaterEntity> movieTheaterEntityList)
        {
            return movieTheaterEntityList.Select(a => EntityToResponse(a)).ToList();
        }

        private static MovieTheaterResponse EntityToResponse(MovieTheaterEntity movieTheaterEntity)
        {
            return new MovieTheaterResponse(movieTheaterEntity.Id, movieTheaterEntity.Name, movieTheaterEntity.Address);
        }
        private static ICollection<MovieMovieTheaterResponse> MovieEntityListToResponseList(IEnumerable<MovieEntity> movieEntityList)
        {
            return movieEntityList.Select(m => MovieEntityToResponse(m)).ToList();
        }

        private static MovieMovieTheaterResponse MovieEntityToResponse(MovieEntity movieEntity)
        {
            return new MovieMovieTheaterResponse(movieEntity.Id, movieEntity.Name, movieEntity.Duration);
        }

        private static ICollection<TicketMovieTheaterResponse> TicketEntityListToResponseList(IEnumerable<TicketEntity> ticketEntityList)
        {
            return ticketEntityList.Select(t => TicketEntityToResponse(t)).ToList();
        }

        private static TicketMovieTheaterResponse TicketEntityToResponse(TicketEntity ticketEntity)
        {
            return new TicketMovieTheaterResponse(ticketEntity.Id, ticketEntity.OwnerName, ticketEntity.Date, ticketEntity.Date.AddDays(3));
        }

        private static ICollection<TicketMovieTheaterResponse> ValidateTicketsExpiration(ICollection<TicketMovieTheaterResponse> tickets)
        {
            List<TicketMovieTheaterResponse> validatedTickets = new List<TicketMovieTheaterResponse>();

            foreach (var ticket in tickets)
            {
                if (ticket.expireAt >= DateTime.Now)
                {
                    validatedTickets.Add(ticket);
                }
            }

            return validatedTickets;
        }

    }
}
