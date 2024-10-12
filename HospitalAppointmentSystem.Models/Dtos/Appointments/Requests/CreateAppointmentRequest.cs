namespace HospitalAppointmentSystem.Models.Dtos.Appointments.Requests;
public sealed record CreateAppointmentRequest(
    string PatientName,
    DateTime AppointmentDate,
    int DoctorId);