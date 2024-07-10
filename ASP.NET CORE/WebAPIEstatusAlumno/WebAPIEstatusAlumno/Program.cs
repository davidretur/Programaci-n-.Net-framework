using Microsoft.EntityFrameworkCore;
using WebAPIEstatusAlumno.Model.Context;


var builder = WebApplication.CreateBuilder(args);

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      builder =>
                      {
                          builder.WithOrigins("https://localhost:44313").AllowAnyMethod().AllowAnyHeader();
                      });
});
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<EstatusContext>(config => {
    config.UseSqlServer(builder.Configuration.GetConnectionString("pruebasConnection"));
});


builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseCors(MyAllowSpecificOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();
