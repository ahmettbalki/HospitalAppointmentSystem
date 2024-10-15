using AutoMapper;
using Core.Results;
using Core.UnitOfWorks;
using HospitalAppointmentSystem.DataAccess.Abstracts;
using HospitalAppointmentSystem.Models.Dtos.Appointments.Requests;
using HospitalAppointmentSystem.Models.Dtos.Appointments.Responses;
using HospitalAppointmentSystem.Models.Entities;
using HospitalAppointmentSystem.Service.Abstracts;
using Microsoft.EntityFrameworkCore;
namespace HospitalAppointmentSystem.Service.Concretes;
public class AppointmentService : IAppointmentService
{
    private readonly IMapper _mapper;
    private readonly IAppointmentRepository _repository;
    private readonly IDoctorRepository _doctorRepository;
    private readonly IUnitOfWork _unitOfWork;
    public AppointmentService(IMapper mapper, IAppointmentRepository repository, IUnitOfWork unitOfWork, IDoctorRepository doctorRepository)
    {
        _mapper = mapper;
        _repository = repository;
        _unitOfWork = unitOfWork;
        _doctorRepository = doctorRepository;
    }
    public async Task<DataResult<CreateAppointmentRequest>> AddAsync(CreateAppointmentRequest request)
    {
        var doctor = await _doctorRepository.GetByIdAsync(request.DoctorId);
        if (doctor == null)
        {
            return DataResult<CreateAppointmentRequest>.Fail("Seçilen doktor bulunamadı.");
        }
        var existingAppointmentsCount = await _repository.GetCountByDoctorIdAsync(request.DoctorId);
        if (existingAppointmentsCount >= 10)
        {
            return DataResult<CreateAppointmentRequest>.Fail("Bu doktorun mevcut randevu kapasitesi doludur.");
        }
        var appointment = _mapper.Map<Appointment>(request);
        appointment.Doctor = doctor;
        if (appointment == null)
        {
            return DataResult<CreateAppointmentRequest>.Fail("Randevu  oluşturulamadı.");
        }
        DateTime today = DateTime.Today;
        DateTime minAppointmentDate = today.AddDays(3);
        if (request.AppointmentDate < minAppointmentDate)
        {
            return DataResult<CreateAppointmentRequest>.Fail("Randevu tarihi bugünden en az 3 gün sonrası olmalıdır.");
        }
        await _repository.AddAsync(appointment);
        await _unitOfWork.SaveChangesAsync();
        return DataResult<CreateAppointmentRequest>.Success(request);
    }
    public async Task<Result> DeleteAsync(Guid id)
    {
        var doctor = await _repository.GetByIdAsync(id);
        if (doctor == null)
        {
            return Result.Fail("Randevu bulunamadı.");
        }
        _repository.Delete(doctor);
        await _unitOfWork.SaveChangesAsync();
        return Result.Success();
    }
    public async Task<Result> DeletePastAppointmentsAsync()
    {
        var appointments = await _repository.GetAll()
            .Where(a => a.AppointmentDate < DateTime.Now)
            .ToListAsync();

        if (appointments.Count == 0)
        {
            return Result.Fail("Silinecek geçmiş randevu bulunamadı.");
        }

        foreach (var appointment in appointments)
        {
            _repository.Delete(appointment);
        }

        await _unitOfWork.SaveChangesAsync();
        return Result.Success();
    }

    public async Task<DataResult<List<AppointmentResponseDto>>> GetAllAppointmentAsync()
    {
        var appointments = await _repository.GetAll()
        .Include(a => a.Doctor)
        .ToListAsync();
        if (appointments == null)
        {
            return DataResult<List<AppointmentResponseDto>>.Fail("Randevu bulunamadı");
        }
        var appointmentAsDto = _mapper.Map<List<AppointmentResponseDto>>(appointments);
        return DataResult<List<AppointmentResponseDto>>.Success(appointmentAsDto);
    }
    public async Task<DataResult<AppointmentResponseDto>> GetByIdAsync(Guid id)
    {
        var appointment = await _repository.GetByIdAsync(id);
        if (appointment == null)
        {
            return DataResult<AppointmentResponseDto>.Fail("Randevu bulunamadı");
        }
        var appointmentAsDto = _mapper.Map<AppointmentResponseDto>(appointment);
        return DataResult<AppointmentResponseDto>.Success(appointmentAsDto);
    }
    public async Task<Result> UpdateAsync(Guid id, UpdateAppointmentRequest request)
    {
        var appointment = await _repository.GetByIdAsync(id);
        if (appointment == null)
        {
            return Result.Fail("Randevu bulunamadı");
        }
        _mapper.Map(request, appointment);
        _repository.Update(appointment);
        await _unitOfWork.SaveChangesAsync();
        return Result.Success();
    }
}
