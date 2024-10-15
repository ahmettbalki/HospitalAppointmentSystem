using AutoMapper;
using Core.Results;
using Core.UnitOfWorks;
using HospitalAppointmentSystem.DataAccess.Abstracts;
using HospitalAppointmentSystem.Models.Dtos.Doctors.Requests;
using HospitalAppointmentSystem.Models.Dtos.Doctors.Responses;
using HospitalAppointmentSystem.Models.Entities;
using HospitalAppointmentSystem.Service.Abstracts;
using Microsoft.EntityFrameworkCore;
namespace HospitalAppointmentSystem.Service.Concretes;
public class DoctorService : IDoctorService
{
    private readonly IMapper _mapper;
    private readonly IDoctorRepository _repository;
    private readonly IUnitOfWork _unitOfWork;
    public DoctorService(IMapper mapper, IDoctorRepository repository, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _repository = repository;
        _unitOfWork = unitOfWork;
    }
    public async Task<DataResult<CreateDoctorRequest>> AddAsync(CreateDoctorRequest request)
    {
        var doctor = _mapper.Map<Doctor>(request);
        if (doctor == null)
        {
            return DataResult<CreateDoctorRequest>.Fail("Doktor oluşturulamadı");
        }
        await _repository.AddAsync(doctor);
        await _unitOfWork.SaveChangesAsync();
        return DataResult<CreateDoctorRequest>.Success(request);
    }
    public async Task<Result> DeleteAsync(int id)
    {
        var doctor = await _repository.GetByIdAsync(id);
        if (doctor == null)
        {
            return Result.Fail("Doctor oluşturulamadı.");
        }

        _repository.Delete(doctor);
        await _unitOfWork.SaveChangesAsync();
        return Result.Success();
    }
    public async Task<DataResult<List<DoctorResponseDto>>> GetAllDoctorsAsync()
    {
        var doctors = await _repository.GetAll().ToListAsync();
        if (doctors == null)
        {
            return DataResult<List<DoctorResponseDto>>.Fail("Doktor bulunamadı");
        }
        var doctorAsDto = _mapper.Map<List<DoctorResponseDto>>(doctors);
        return DataResult<List<DoctorResponseDto>>.Success(doctorAsDto);
    }
    public async Task<DataResult<DoctorWithAppointmentsResponseDto>> GetByIdAsync(int id)
    {
        var doctor = await _repository.GetByIdAsync(id);
        if (doctor == null)
        {
            return DataResult<DoctorWithAppointmentsResponseDto>.Fail("Doktor bulunamadı");
        }
        var doctorAsDto = _mapper.Map<DoctorWithAppointmentsResponseDto>(doctor);
        return DataResult<DoctorWithAppointmentsResponseDto>.Success(doctorAsDto);
    }
    public async Task<Result> UpdateAsync(int id, UpdateDoctorRequest request)
    {
        var doctor = await _repository.GetByIdAsync(id);
        if (doctor == null)
        {
            return Result.Fail("Doktor bulunamadı");
        }
        _mapper.Map(request, doctor);
        _repository.Update(doctor);
        await _unitOfWork.SaveChangesAsync();
        return Result.Success();
    }
}