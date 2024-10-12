namespace HospitalAppointmentSystem.Models.Dtos.Appointments.Requests;
public sealed record UpdateAppointmentRequest(
    Guid Id,
    string PatientName,
    DateTime AppointmentDate,
    int DoctorId);