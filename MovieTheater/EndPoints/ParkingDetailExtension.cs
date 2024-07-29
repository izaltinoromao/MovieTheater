using MovieTheater.Requests;
using MovieTheater.Responses;
using MovieTheater.Shared.Data.DB;
using MovieTheater.Shared.Models;
using MovieTheater_Console;
using Microsoft.AspNetCore.Mvc;

namespace MovieTheater.EndPoints
{
    public static class ParkingDetailExtension
    {
        public static void AddEndPointsParkingDetail(this WebApplication app)
        {
            var groupBuilder = app.MapGroup("parking-detail")
                .RequireAuthorization()
                .WithTags("Parking Detail");

            groupBuilder.MapGet("", ([FromServices] DAL<ParkingDetailEntity> dal) =>
            {
                var parkingDetailEntityList = dal.Read();
                if (parkingDetailEntityList is null) return Results.NotFound();
                var parkingDetailResponseList = EntityListToResponseList(parkingDetailEntityList);
                return Results.Ok(parkingDetailResponseList);
            });

            groupBuilder.MapGet("/{id}", ([FromServices] DAL<ParkingDetailEntity> dal, int id) =>
            {
                var parkingDetailEntity = dal.ReadBy(a => a.Id == id);
                if (parkingDetailEntity is null) return Results.NotFound();
                return Results.Ok(EntityToResponse(parkingDetailEntity));
            });

            groupBuilder.MapPost("", ([FromServices] DAL<ParkingDetailEntity> parkingDetailDal, 
                [FromServices] DAL<MovieTheaterEntity> movieTheaterDal, 
                [FromBody] ParkingDetailRequest parkingDetailRequest) =>
            {
                var movieTheaterEntity = movieTheaterDal.ReadBy(a => a.Id == parkingDetailRequest.movieTheaterId);
                if (movieTheaterEntity is null) return Results.NotFound();
                var parkingDetailEntity = new ParkingDetailEntity(parkingDetailRequest.numberOfSpaces, 
                    parkingDetailRequest.isCovered, 
                    parkingDetailRequest.hasEVChargingStations, 
                    movieTheaterEntity);
                parkingDetailDal.Create(parkingDetailEntity);

                var resourceUrl = $"/parking-detail/{parkingDetailEntity.Id}";
                return Results.Created(resourceUrl, EntityToResponse(parkingDetailEntity));
            });

            groupBuilder.MapDelete("/{id}", ([FromServices] DAL<ParkingDetailEntity> dal, int id) =>
            {
                var parkingDetailEntity = dal.ReadBy(p => p.Id == id);
                if (parkingDetailEntity is null) return Results.NotFound();
                dal.Delete(parkingDetailEntity);
                return Results.NoContent();
            });

            groupBuilder.MapPut("", ([FromServices] DAL<ParkingDetailEntity> parkingDetailDal, 
                [FromServices] DAL<MovieTheaterEntity> movieTheaterDal, 
                [FromBody] ParkingDetailEditRequest parkingDetailEditRequest) =>
            {
                var parkingDetailToEdit = parkingDetailDal.ReadBy(m => m.Id == parkingDetailEditRequest.id);
                if (parkingDetailToEdit is null) return Results.NotFound("Parking not found");

                var movieTheaterEntity = movieTheaterDal.ReadBy(a => a.Id == parkingDetailEditRequest.movieTheaterId);
                if (movieTheaterEntity is null) return Results.NotFound("Movie theater not found");

                parkingDetailToEdit.NumberOfSpaces = parkingDetailEditRequest.numberOfSpaces;
                parkingDetailToEdit.IsCovered = parkingDetailEditRequest.isCovered;
                parkingDetailToEdit.HasEVChargingStations = parkingDetailEditRequest.hasEVChargingStations;
                parkingDetailToEdit.MovieTheaterEntity = movieTheaterEntity;

                parkingDetailDal.Update(parkingDetailToEdit);
                return Results.Ok(EntityToResponse(parkingDetailToEdit));
            });
        }

        private static ICollection<ParkingDetailResponse> EntityListToResponseList(IEnumerable<ParkingDetailEntity> parkingDetailEntityList)
        {
            return parkingDetailEntityList.Select(t => EntityToResponse(t)).ToList();
        }
        private static ParkingDetailResponse EntityToResponse(ParkingDetailEntity parkingDetailEntity)
        {
            return new ParkingDetailResponse(
                parkingDetailEntity.Id,
                parkingDetailEntity.NumberOfSpaces,
                parkingDetailEntity.IsCovered,
                parkingDetailEntity.HasEVChargingStations,
                parkingDetailEntity.MovieTheaterEntity?.Id ?? 0,
                parkingDetailEntity.MovieTheaterEntity?.Name ?? "No linked MovieTheater");
        }
    }
}
