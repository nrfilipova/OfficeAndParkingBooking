using OfficeAndParkingBooking.Data;
using OfficeAndParkingBooking.Data.Models;
using OfficeAndParkingBooking.Services;
using OfficeAndParkingBooking.Services.Interfaces;
using OfficeAndParkingBooking.Services.Mapping;

using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddAuthentication();

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

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<OfficeAndParkingBookingDbContext>();

builder.Services.AddScoped(typeof(IRepository), typeof(Repository));

builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

builder.Services.AddTransient<IParkingBookingService, ParkingBookingService>();
builder.Services.AddTransient<IEmployeeService, EmployeeService>();
builder.Services.AddTransient<IOfficeBookingService, OfficeBookingService>();
builder.Services.AddTransient<IRoomService, RoomService>();

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
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

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
