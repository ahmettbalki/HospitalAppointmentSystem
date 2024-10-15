using HospitalAppointmentSystem.Models.Entities;
using HospitalAppointmentSystem.Models.Enums;
namespace HospitalAppointmentSystem.Models.Dtos.Doctors.Requests;
public sealed record CreateDoctorRequest(
    string Name,
    Branch Branch);