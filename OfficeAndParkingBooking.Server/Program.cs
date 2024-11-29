using OfficeAndParkingBooking.Data;
using OfficeAndParkingBooking.Data.Models;
using OfficeAndParkingBooking.Services;
using OfficeAndParkingBooking.Services.Interfaces;
using OfficeAndParkingBooking.Services.Mapping;

using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Diagnostics;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddAuthentication();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder => builder
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

app.UseExceptionHandler(x =>
{
    x.Run(async context =>
    {
        context.Response.StatusCode = 500;
        context.Response.ContentType = "application/json";

        var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
        if (contextFeature is not null)
        {
            await context.Response.WriteAsJsonAsync(new
            {
                StatusCodes = context.Response.StatusCode,
                Message = "Internal Server Error"
            });
        }
    });
});

app.UseHttpsRedirection();

app.MapGroup("api/identity").MapIdentityApi<Employee>();

app.UseAuthorization();

app.UseCors("AllowAll");

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();