using Core.Results;
using HospitalAppointmentSystem.Models.Dtos.Doctors.Requests;
using HospitalAppointmentSystem.Models.Dtos.Doctors.Responses;
namespace HospitalAppointmentSystem.Service.Abstracts;
public interface IDoctorService
{
    Task<ServiceResult<List<DoctorResponseDto>>> GetAllDoctorsAsync();
    Task<ServiceResult<DoctorResponseDto>> GetByIdAsync(int id);
    Task<ServiceResult<CreateDoctorRequest>> CreateAsync(CreateDoctorRequest request);
    Task<ServiceResult> UpdateAsync(int id, UpdateDoctorRequest request);
    Task<ServiceResult> DeleteAsync(int id);
}