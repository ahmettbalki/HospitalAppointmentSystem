using AutoMapper;
using Core.Results;
using HospitalAppointmentSystem.DataAccess.Abstracts;
using HospitalAppointmentSystem.Models.Dtos.Doctors.Requests;
using HospitalAppointmentSystem.Models.Dtos.Doctors.Responses;
using HospitalAppointmentSystem.Service.Abstracts;
namespace HospitalAppointmentSystem.Service.Concretes;
public class DoctorService : IDoctorService
{
    private readonly IMapper _mapper;
    private readonly IDoctorRepository _repository;
    public DoctorService(IMapper mapper, IDoctorRepository repository)
    {
        _mapper = mapper;
        _repository = repository;
    }
    public Task<ServiceResult<CreateDoctorRequest>> CreateAsync(CreateDoctorRequest request)
    {
        throw new NotImplementedException();
    }
    public Task<ServiceResult> DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }
    public Task<ServiceResult<List<DoctorResponseDto>>> GetAllDoctorsAsync()
    {
        throw new NotImplementedException();
    }
    public Task<ServiceResult<DoctorResponseDto>> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }
    public Task<ServiceResult> UpdateAsync(int id, UpdateDoctorRequest request)
    {
        throw new NotImplementedException();
    }
}