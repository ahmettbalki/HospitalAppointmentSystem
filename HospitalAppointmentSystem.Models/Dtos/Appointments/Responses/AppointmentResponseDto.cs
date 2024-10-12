namespace HospitalAppointmentSystem.Models.Dtos.Appointments.Responses;
public sealed record AppointmentResponseDto(
    Guid Id,
    string PatientName,
    DateTime AppointmentDate,
    int DoctorId);