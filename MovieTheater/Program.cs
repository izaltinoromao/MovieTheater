using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using MovieTheater.EndPoints;
using MovieTheater.Shared.Data.DB;
using MovieTheater_Console;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options => options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
builder.Services.AddDbContext<MovieTheaterContext>();
builder.Services.AddTransient<DAL<MovieTheaterEntity>>();
builder.Services.AddTransient<DAL<MovieEntity>>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.AddEndPointsMovieTheater();
app.AddEndPointsMovie();

app.UseSwagger();
app.UseSwaggerUI();

app.Run();
