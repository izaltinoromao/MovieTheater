﻿using MovieTheater.Requests;
using MovieTheater.Shared.Data.DB;
using MovieTheater_Console;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MovieTheater.Responses;

namespace MovieTheater.EndPoints
{
    public static class MovieTheaterExtension
    {
        public static void AddEndPointsMovieTheater(this WebApplication app)
        {
            app.MapGet("/MovieTheater", ([FromServices] DAL<MovieTheaterEntity> dal) =>
            {
                var movieTheaterEntityList = dal.Read();
                if (movieTheaterEntityList is null) return Results.NotFound();
                var movieTheaterResponseList = EntityListToResponseList(movieTheaterEntityList);
                return Results.Ok(movieTheaterResponseList);
            });

            app.MapGet("/MovieTheater/{id}", ([FromServices] DAL<MovieTheaterEntity> dal, int id) =>
            {
                var movieTheaterEntity = dal.ReadBy(a => a.Id == id);
                if (movieTheaterEntity is null) return Results.NotFound();
                return Results.Ok(EntityToResponse(movieTheaterEntity));
            });

            app.MapPost("/MovieTheater", ([FromServices] DAL<MovieTheaterEntity> dal, [FromBody] MovieTheaterRequest movieTheaterRequest) =>
            {
                var movieTheaterEntity = new MovieTheaterEntity(movieTheaterRequest.name, movieTheaterRequest.address);
                dal.Create(movieTheaterEntity);
                return Results.Ok(EntityToResponse(movieTheaterEntity));
            });

            app.MapDelete("/MovieTheater/{id}", ([FromServices] DAL<MovieTheaterEntity> dal, int id) =>
            {
                var movieTheater = dal.ReadBy(m => m.Id == id);
                if (movieTheater is null) return Results.NotFound();
                dal.Delete(movieTheater);
                return Results.NoContent();
            });

            app.MapPut("/MovieTheater", ([FromServices] DAL<MovieTheaterEntity> dal, [FromBody] MovieTheaterEditRequest movieTheaterEditRequest) =>
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
    }
}
