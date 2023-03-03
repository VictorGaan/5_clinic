using Microsoft.EntityFrameworkCore;
using TRPOFirst.Domian;
using TRPOFirst.Installer;
using TRPOFirst.Services;

var builder = WebApplication.CreateBuilder(args);

// DbContextOptionsBuilder connection = new DbContextOptionsBuilder();
// connection.UseNpgsql(
//         "Host=localhost;" +
//                       "Port=5432;" +
//                       "Database=Hospital;" +
//                       "Username=postgres;" +
//                       "Password=****");

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// AddSingleton создает один объект для всех последующих запросов,
// при этом объект создается только тогда, когда он непосредственно необходим.
// Этот метод имеет все те же перегруженые версии, что и AddTransient и AddScoped.

builder.Services.AddSingleton<IDoctorService, DoctorService>()
    .AddSingleton<IPacientService, PacientService>()
    .AddSingleton<IPostService, PostService>()
    .AddSingleton<IScheduleResponseService, ScheduleResponseService>()
    .AddSingleton<IDoctorsAppointmentsService, DoctorsAppointmentsService>()
    .AddSingleton<IDoctorsInfoService, DoctorsInfoService>()
    .AddSingleton<IReceptionService, ReceptionService>()
    .AddSingleton<IDiseasesService, DiseasesService>();

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