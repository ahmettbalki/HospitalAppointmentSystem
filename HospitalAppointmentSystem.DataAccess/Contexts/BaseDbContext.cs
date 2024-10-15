using HospitalAppointmentSystem.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
namespace HospitalAppointmentSystem.DataAccess.Contexts;
public class BaseDbContext(DbContextOptions<BaseDbContext> options) : DbContext(options)
{
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Appointment> Appointments { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //Bu katman içindeki IEntityTypeConfiguration interfaceni implement eden tüm sınıfları geçer.
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }
}