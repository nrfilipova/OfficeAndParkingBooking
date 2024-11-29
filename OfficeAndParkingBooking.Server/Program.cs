using OfficeAndParkingBooking.Data;
using OfficeAndParkingBooking.Data.Models;
using OfficeAndParkingBooking.Services;
using OfficeAndParkingBooking.Services.Interfaces;
using OfficeAndParkingBooking.Services.Mapping;
using OfficeAndParkingBooking.Server.Middleware;

using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddAuthentication();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder => builder
    .WithOrigins("http://localhost:57171")
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());
});

builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("bearerAuth", new OpenApiSecurityScheme
    {
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference {Type = ReferenceType.SecurityScheme, Id = "bearerAuth"}
            },
            []
        }
    });
});

builder.Services.AddIdentityApiEndpoints<Employee>()
    .AddEntityFrameworkStores<OfficeAndParkingBookingDbContext>();

builder.Services.AddDbContext<OfficeAndParkingBookingDbContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped(typeof(IRepository), typeof(Repository));

builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

builder.Services.AddLogging();
builder.Services.AddTransient<GlobalExceptionHandlingMiddleware>();

builder.Services.AddTransient<IParkingBookingService, ParkingBookingService>();
builder.Services.AddTransient<IOfficeBookingService, OfficeBookingService>();
builder.Services.AddTransient<ICarService, CarService>();

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseHsts();
}

app.UseHttpsRedirection();

app.MapGroup("api/identity").MapIdentityApi<Employee>();

app.UseAuthorization();

app.UseCors("AllowAll");

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.UseMiddleware<GlobalExceptionHandlingMiddleware>();

app.Run();