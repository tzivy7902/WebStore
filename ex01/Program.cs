using AutoMapper;
using Entytess;
using Microsoft.EntityFrameworkCore;
using project.Controllers;
using repository;
using servies;
using NLog;
using NLog.Web;
using project.MiddleWare;


var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IUserServies, UserServies>();
builder.Services.AddScoped<IUserRepository,UserRepository>();
builder.Services.AddDbContext<StoreDatabaseContext>();
builder.Services.AddScoped<IProductRepository, ProductReposirory>();
builder.Services.AddScoped<IProductServies, ProductServices>();
builder.Services.AddScoped<ICategoryServies, CategoryServies>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IOrderServies, OrderServies>();
builder.Services.AddScoped<IRatingRepository, RatingRepository>();
builder.Services.AddScoped<IRatingService, RatingService>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddDbContext<StoreDatabaseContext>(opption => opption.UseSqlServer(builder.Configuration.GetConnectionString("School")));
builder.Host.UseNLog();


var app = builder.Build();

// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseStaticFiles();


app.UseAuthorization();

app.MapControllers();


app.UseMiddleware();

app.UseCatchErrorMidlleWare();


app.Run();
