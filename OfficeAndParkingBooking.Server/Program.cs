using OfficeAndParkingBooking.Data;
using OfficeAndParkingBooking.Services;
using OfficeAndParkingBooking.Services.Interfaces;
using OfficeAndParkingBooking.Services.Mapping;

using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<OfficeAndParkingBookingDbContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

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

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
