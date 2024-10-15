using HospitalAppointmentSystem.Models.Entities;
using HospitalAppointmentSystem.Models.Enums;
namespace HospitalAppointmentSystem.Models.Dtos.Doctors.Responses;
public sealed record DoctorWithAppointmentsResponseDto(
    int Id,
    string Name,
    Branch Branch,
    List<Appointment> Appointments);