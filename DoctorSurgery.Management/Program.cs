using DoctorSurgery.Domain.Contracts;
using DoctorSurgery.Infrastructure.Reposititories;
using DoctorSurgery.Management;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped <IDoctorService, DoctorService>();
builder.Services.AddScoped <IDoctorRepository, DoctorInMemoryRepository>();
builder.Services.AddScoped <ITimeSlotService, TimeSlotService>();
builder.Services.AddScoped <ITimeSlotRepository, TimeSlotInMemoryRepository>(); 
builder.Services.AddControllers();

var app = builder.Build();

app.MapGet("/", () => "Hello Doctor Surgery Management System!");

app.MapControllers();
app.Run();
