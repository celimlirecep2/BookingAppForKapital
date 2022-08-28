using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using MyProject.Core.Abstract;
using MyProject.Core.Configuration;
using MyProject.Core.Repository;
using MyProject.Data;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("BookingWebsiteDatabase");
// Add services to the container.
builder.Services.AddControllers().AddOData(options =>
{
    options.Select().Filter().OrderBy();
});
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddAutoMapper(typeof(MapperConfig));
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "MY POJECT", Version = "v1" });
});
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", x => x.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());
});

    builder.Services.AddDbContext<MyProjectDbContext>(options =>
    {
        options.UseNpgsql(connectionString);
    });



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
app.UseCors("AllowAll");
app.UseAuthorization();

app.MapControllers();

app.Run();
