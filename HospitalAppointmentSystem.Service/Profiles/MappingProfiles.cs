using AutoMapper;
using HospitalAppointmentSystem.Models.Dtos.Appointments.Requests;
using HospitalAppointmentSystem.Models.Dtos.Doctors.Requests;
using HospitalAppointmentSystem.Models.Entities;
namespace HospitalAppointmentSystem.Service.Profiles;
public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateDoctorRequest, Doctor>();
        CreateMap<CreateAppointmentRequest, Appointment>();
    }
}