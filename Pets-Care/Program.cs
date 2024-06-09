using Microsoft.EntityFrameworkCore;
using PetsCareCore.Context;
using PetsCareCore.Models.Entities;
using PetsCareCore.Repos;
using PetsCareCore.Services;
using PetsCareInfra.Repos;
using PetsCareInfra.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<PetCareDbcontext>(option => option.UseMySQL(builder.Configuration.GetConnectionString("mysqlconnect")));

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepos, UserRepos>();

builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ICategoryRepos, CategoryRepos>();

builder.Services.AddScoped<IClinicService, ClinicService>();
builder.Services.AddScoped<IClinicRepos, ClinicRepos>();

builder.Services.AddScoped<IClinicAppointmentService, ClinicAppointmentService>();
builder.Services.AddScoped<IClinicAppointmentRepos, ClinicAppointmentRepos>();

builder.Services.AddScoped<IItemService, ItemService>();
builder.Services.AddScoped<IItemRepos, ItemRepos>();

builder.Services.AddScoped<ILoginService, LoginService>();
builder.Services.AddScoped<IloginRepos, LoginRepos>();

builder.Services.AddScoped<IPetService, PetService>();
builder.Services.AddScoped<IPetRepos, PetRepos>();

builder.Services.AddScoped<IServicesService, ServiceService>();
builder.Services.AddScoped<IServiceRepos, ServiceRepos>();

builder.Services.AddScoped<IWishListService, WishListService>();
builder.Services.AddScoped<IWishListRepos, WishListRepos>();
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
