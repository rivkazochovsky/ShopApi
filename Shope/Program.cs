using Microsoft.EntityFrameworkCore;
using Repository;
using Service;
using Microsoft.Extensions.Configuration;
using Shope;
using NLog.Web;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddScoped<IServiceUser, ServiceUser>();

builder.Services.AddScoped<IRepositoryUser, RepositoryUser>();

builder.Services.AddScoped<IServiceCategory, ServiceCategory>();

builder.Services.AddScoped<IRepositoryCategory, RepositoryCategory>();

builder.Services.AddScoped<IServiceOrder, ServiceOrder>();

builder.Services.AddScoped<IRepositoryOrder, RepositoryOrder>();

builder.Services.AddScoped<IServiceProduct, ServiceProduct>();

builder.Services.AddScoped<IRepositoryProduct, RepositoryProduct>();


builder.Services.AddScoped<IRatingRepository, RatingRepository>();
builder.Services.AddScoped<IRatingService, RatingService>();


builder.Services.AddDbContext<ShopApiContext>(options => options.UseSqlServer("Server=SRV2\\PUPILS;Database=ShopApi;Trusted_Connection=True;TrustServerCertificate=True"));
//builder.Configuration["seminar"];
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Host.UseNLog();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


// Configure the HTTP request pipeline.
app.UseRatingMiddleware();
//app.TryCatchMiddleware();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseAuthorization();

app.MapControllers();

app.Run();
