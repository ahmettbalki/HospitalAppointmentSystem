using Core.Results;
using HospitalAppointmentSystem.Models.Dtos.Doctors.Requests;
using HospitalAppointmentSystem.Models.Dtos.Doctors.Responses;
namespace HospitalAppointmentSystem.Service.Abstracts;
public interface IDoctorService
{
    Task<DataResult<List<DoctorResponseDto>>> GetAllDoctorsAsync();
    Task<DataResult<DoctorWithAppointmentsResponseDto>> GetByIdAsync(int id);
    Task<DataResult<CreateDoctorRequest>> AddAsync(CreateDoctorRequest request);
    Task<Result> UpdateAsync(int id, UpdateDoctorRequest request);
    Task<Result> DeleteAsync(int id);
}