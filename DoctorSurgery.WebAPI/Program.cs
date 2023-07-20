using DoctorSurgery.Domain.Contracts;
using DoctorSurgery.Infrastructure.Reposititories;
using DoctorSurgery.WebAPI.Interfaces;
using DoctorSurgery.WebAPI.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped <IPatientService, PatientService>(); 
builder.Services.AddScoped <IPatientRepository, PatientInMemoryRepository>();   
builder.Services.AddScoped <IAppointmentService, AppointmentService>();
builder.Services.AddScoped <IAppointmentRepository, AppointmentInMemoryRepository>();
builder.Services.AddControllers();

var app = builder.Build();

app.MapGet("/", () => "Hello Doctor Surgery Booking System!");

app.MapControllers();   
app.Run();
