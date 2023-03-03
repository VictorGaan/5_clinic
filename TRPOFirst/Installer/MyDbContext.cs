using Microsoft.EntityFrameworkCore;
using TRPOFirst.Domian;

namespace TRPOFirst.Installer;

public class MyDbContext : DbContext
{
    public DbSet<Doctors> Doctors { get; set; } //
    public DbSet<Pacients> Pacients { get; set; } //
    public DbSet<Posts> Posts { get; set; } //
    public DbSet<Reseption> Reseptions { get; set; } //
    public DbSet<ReceptionSchedule> ReceptionSchedule { get; set; } //
    public DbSet<DoctorsAppointments> DoctorsAppointments { get; set; } //
    public DbSet<DoctorsInfo> DoctorsInfo { get; set; } //
    public DbSet<Diseases> Diseases { get; set; } //

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(
            "Host=localhost;" +
                     "Port=5432;" +
                      "Database=Hospital;" +
                      "Username=postgres;" +
                      "Password=****");
        // Не могу разобратся с CodeFirst подъодом
    }
}