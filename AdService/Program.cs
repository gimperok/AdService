using AdApi;
using AdDBService.DBContext;
using AdJson.Models;
using AdDBService.Services.Repository.Implementations;
using AdDBService.Services.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    var basePath = AppContext.BaseDirectory;

    var xmlPath = Path.Combine(basePath, "swaggerConfig.xml");
    options.IncludeXmlComments(xmlPath);
});

builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlite(AppSettings.ConnectionString));

builder.Services.AddScoped<IAdvertRepository<Advert>, AdvertRepository>();
builder.Services.AddScoped<IBaseRepository<User>, UserRepository>();


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