using Microsoft.EntityFrameworkCore;
using MyProject.Core.Abstract;
using MyProject.Core.Configuration;
using MyProject.Core.Repository;
using MyProject.Data;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("BookingWebsiteDatabase");
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddAutoMapper(typeof(MapperConfig));
builder.Services.AddSwaggerGen();
try
{
    builder.Services.AddDbContext<MyProjectDbContext>(options =>
    {
        options.UseNpgsql(connectionString);
    });
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
    throw;
}

builder.Services.AddScoped<DbContext>(provider => provider.GetService<MyProjectDbContext>());
builder.Services.AddScoped<IBookingRepository, BookingRepository>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
