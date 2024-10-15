using HospitalAppointmentSystem.Models.Enums;

namespace HospitalAppointmentSystem.Models.Dtos.Doctors.Responses;
public  record DoctorResponseDto(
    int Id,
    string Name,
    Branch Branch);
