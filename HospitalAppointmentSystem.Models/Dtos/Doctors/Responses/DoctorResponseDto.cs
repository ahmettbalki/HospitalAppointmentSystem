using HospitalAppointmentSystem.Models.Entities;
using HospitalAppointmentSystem.Models.Enums;
namespace HospitalAppointmentSystem.Models.Dtos.Doctors.Responses;
public sealed record DoctorResponseDto(
    int Id,
    string Name,
    string Surname,
    Branch Branch,
    List<Appointment> Appointments);