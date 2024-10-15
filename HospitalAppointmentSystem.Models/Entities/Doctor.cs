using Core.Entities;
using HospitalAppointmentSystem.Models.Enums;
namespace HospitalAppointmentSystem.Models.Entities;
public class Doctor : Entity<int>
{
    public string Name { get; set; } 
    public Branch Branch { get; set; }
    public List<Appointment> Appointments { get; set; }
}