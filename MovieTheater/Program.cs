using System.Text.Json.Serialization;
using MovieTheater.Shared.Data.DB;
using MovieTheater_Console;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options => options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

var app = builder.Build();

app.MapGet("/", () => 
{
    var dal = new DAL<MovieTheaterEntity>(new MovieTheaterContext());

    return dal.Read();
});

app.Run();
