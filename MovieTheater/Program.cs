using System.Net;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MovieTheater.EndPoints;
using MovieTheater.Shared.Data.DB;
using MovieTheater.Shared.Data.Models;
using MovieTheater.Shared.Models;
using MovieTheater_Console;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options => options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
builder.Services.AddDbContext<MovieTheaterContext>();
builder.Services.AddTransient<DAL<MovieTheaterEntity>>();
builder.Services.AddTransient<DAL<ParkingDetailEntity>>();
builder.Services.AddTransient<DAL<MovieEntity>>();
builder.Services.AddTransient<DAL<TicketEntity>>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddIdentityApiEndpoints<AccessUser>().AddEntityFrameworkStores<MovieTheaterContext>();
builder.Services.AddAuthorization();

var app = builder.Build();

app.UseAuthorization();

app.AddEndPointsMovieTheater();
app.AddEndPointsParkingDetail();
app.AddEndPointsMovie();
app.AddEndPointsTicket();

app.MapGroup("auth").MapIdentityApi<AccessUser>().WithTags("Authorization");

app.MapPost("auth/logout", async ([FromServices] SignInManager<AccessUser> signInManager)
=> {
    await signInManager.SignOutAsync();
    return Results.Ok();
}).RequireAuthorization().WithTags("Authorization");

app.UseSwagger();
app.UseSwaggerUI();

app.Run();
