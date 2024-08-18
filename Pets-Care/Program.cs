using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;
using PetsCareCore.Context;
using PetsCareCore.Models.Entities;
using PetsCareCore.Repos;
using PetsCareCore.Services;
using PetsCareInfra.Repos;
using PetsCareInfra.Services;
using Serilog;
using System.Configuration;
using System.Reflection;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .Build();

// Retrieve logger path from configuration
string loggerPath = configuration.GetSection("Logger").Value;

if (string.IsNullOrEmpty(loggerPath))
{
    throw new ArgumentNullException(nameof(loggerPath), "Logger path is not configured in appsettings.json");
}

// Log the loggerPath for debugging purposes
Console.WriteLine($"Logger path: {loggerPath}");

// Configure Serilog
Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(configuration)
    .WriteTo.File(loggerPath, rollingInterval: RollingInterval.Day)
    .CreateLogger();

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


builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Version = "v1",
        Title = "Pet Care API",
    });
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

builder.Host.UseSerilog();
var secretKey = builder.Configuration.GetValue<string>("JwtConfig:Secret");
var key = Encoding.ASCII.GetBytes(secretKey);
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateIssuer = false,
            ValidateAudience = false,
            ClockSkew = TimeSpan.Zero
        };
    });

// Add authorization
builder.Services.AddAuthorization();
builder.Services.AddCors(opt =>
{
    opt.AddPolicy(name: "default", builder =>
    {
        builder
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "Pet Care API V1");    
    });
}

app.UseHttpsRedirection();

app.UseStaticFiles(); // To serve files 
// Add custom static files middleware
var imagesDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Images");
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(imagesDirectory),
    RequestPath = "/Images"
});

app.UseAuthorization();

app.UseCors("default");

app.MapControllers();

app.Run();
