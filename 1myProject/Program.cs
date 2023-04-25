
using BL;
using DL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddTransient<IUserBL, UserBL>();
builder.Services.AddTransient<IUserDL, UserDL>();
builder.Services.AddTransient<IPasswordBL, PasswordBL>();
builder.Services.AddTransient<IProductDL, ProductDL>();
builder.Services.AddTransient<IProductBL, ProductBL>();
builder.Services.AddTransient<ICategoryDL, CategoryDL>();
builder.Services.AddTransient<ICategoryBL, CategoryBL>();
//builder.Services.AddTransient<ICategoryBL, CategoryBL>();
builder.Services.AddControllers();
builder.Services.AddDbContext<MyShopDbContext>(option => option.UseSqlServer("Server=srv2\\PUPILS;Database=myShop_db;Trusted_Connection=True;TrustServerCertificate=True"));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Configure the HTTP request pipeline.
//app.UseDefaultFiles();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseStaticFiles();

app.Run();
