using HospitalAppointmentSystem.Models.Entities;
using Microsoft.EntityFrameworkCore;
namespace HospitalAppointmentSystem.DataAccess.Contexts;
public class BaseDbContext : DbContext
{
    public BaseDbContext(DbContextOptions opt) : base(opt)
    {  
    }
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Appointment> Appointments { get; set; }
}