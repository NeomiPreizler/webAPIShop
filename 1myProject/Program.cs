
using BL;
using DL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NLog.Web;

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseNLog();

// Add services to the container.
builder.Services.AddTransient<IUserBL, UserBL>();
builder.Services.AddTransient<IUserDL, UserDL>();
builder.Services.AddTransient<IPasswordBL, PasswordBL>();
builder.Services.AddTransient<IProductDL, ProductDL>();
builder.Services.AddTransient<IProductBL, ProductBL>();
builder.Services.AddTransient<ICategoryDL, CategoryDL>();
builder.Services.AddTransient<ICategoryBL, CategoryBL>();
builder.Services.AddTransient<IOrderBL, OrderBL>();
builder.Services.AddTransient<IOrderDL, OrderDL>();
builder.Services.AddControllers();

string connectionString = builder.Configuration["connectionString"];

builder.Services.AddDbContext<MyShopDbContext>(option => option.UseSqlServer(connectionString));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

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
