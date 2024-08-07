﻿using MovieTheater.Requests;
using MovieTheater.Shared.Data.DB;
using MovieTheater_Console;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MovieTheater.Responses;
using MovieTheater.Shared.Models;

namespace MovieTheater.EndPoints
{
    public static class TicketExtension
    {
        public static void AddEndPointsTicket(this WebApplication app)
        {
            var groupBuilder = app.MapGroup("ticket")
                .RequireAuthorization()
                .WithTags("Ticket");

            groupBuilder.MapGet("", ([FromServices] DAL<TicketEntity> dal) =>
            {
                var ticketEntityList = dal.Read();
                if (ticketEntityList is null) return Results.NotFound();
                var ticketResponseList = EntityListToResponseList(ticketEntityList);
                return Results.Ok(ticketResponseList);
            });

            groupBuilder.MapGet("/{id}", ([FromServices] DAL<TicketEntity> dal, int id) =>
            {
                var ticketEntity = dal.ReadBy(a => a.Id == id);
                if (ticketEntity is null) return Results.NotFound();
                return Results.Ok(EntityToResponse(ticketEntity));
            });

            groupBuilder.MapPost("", ([FromServices] DAL<TicketEntity> ticketDal, 
                [FromServices] DAL <MovieTheaterEntity> movieTheaterDal, 
                [FromBody] TicketRequest ticketRequest) =>
            {
                var movieTheaterEntity = movieTheaterDal.ReadBy(a => a.Id == ticketRequest.movieTheaterId);
                if (movieTheaterEntity is null) return Results.NotFound();
                var ticketEntity = new TicketEntity(ticketRequest.ownerName, movieTheaterEntity);

                ticketDal.Create(ticketEntity);

                var resourceUrl = $"/ticket/{ticketEntity.Id}";
                return Results.Created(resourceUrl, EntityToResponse(ticketEntity));
            });

            groupBuilder.MapDelete("/{id}", ([FromServices] DAL<TicketEntity> dal, int id) =>
            {
                var ticket = dal.ReadBy(m => m.Id == id);
                if (ticket is null) return Results.NotFound();
                dal.Delete(ticket);
                return Results.NoContent();
            });

            groupBuilder.MapPut("", ([FromServices] DAL<TicketEntity> ticketDal, 
                [FromServices] DAL<MovieTheaterEntity> movieTheaterDal, [FromBody] 
            TicketEditRequest ticketEditRequest) =>
            {
                var ticketToEdit = ticketDal.ReadBy(m => m.Id == ticketEditRequest.id);
                if (ticketToEdit is null) return Results.NotFound("Ticket not found");

                var movieTheaterEntity = movieTheaterDal.ReadBy(a => a.Id == ticketEditRequest.movieTheaterId);
                if (movieTheaterEntity is null) return Results.NotFound("Movie theater not found");

                ticketToEdit.OwnerName = ticketEditRequest.ownerName;
                ticketToEdit.MovieTheaterEntity = movieTheaterEntity;

                ticketDal.Update(ticketToEdit);

                return Results.Ok(EntityToResponse(ticketToEdit));
            });
        }

        private static ICollection<TicketResponse> EntityListToResponseList(IEnumerable<TicketEntity> ticketEntityList)
        {
            return ticketEntityList.Select(t => EntityToResponse(t)).ToList();
        }
        private static TicketResponse EntityToResponse(TicketEntity ticketEntity)
        {
            return new TicketResponse(
                ticketEntity.Id,
                ticketEntity.OwnerName ?? string.Empty,
                ticketEntity.Date,
                ticketEntity.MovieTheaterEntity?.Id ?? 0,
                ticketEntity.MovieTheaterEntity?.Name ?? "No linked MovieTheater");
        }
    }
}
