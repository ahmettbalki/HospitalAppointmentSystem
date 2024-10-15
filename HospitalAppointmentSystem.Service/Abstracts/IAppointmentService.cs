using Core.Results;
using HospitalAppointmentSystem.Models.Dtos.Appointments.Requests;
using HospitalAppointmentSystem.Models.Dtos.Appointments.Responses;
namespace HospitalAppointmentSystem.Service.Abstracts;
public interface IAppointmentService
{
    Task<DataResult<List<AppointmentResponseDto>>> GetAllAppointmentAsync();
    Task<DataResult<AppointmentResponseDto>> GetByIdAsync(Guid id);
    Task<DataResult<CreateAppointmentRequest>> AddAsync(CreateAppointmentRequest request);
    Task<Result> UpdateAsync(Guid id, UpdateAppointmentRequest request);
    Task<Result> DeleteAsync(Guid id);
    Task<Result> DeletePastAppointmentsAsync();
}