using AutoMapper;
using HospitalAppointmentSystem.Models.Dtos.Doctors.Requests;
using HospitalAppointmentSystem.Models.Dtos.Doctors.Responses;
using HospitalAppointmentSystem.Models.Entities;
namespace HospitalAppointmentSystem.Service.Profiles.Doctor;
public class DoctorMappingProfiles : Profile
{
    public DoctorMappingProfiles()
    {
        CreateMap<HospitalAppointmentSystem.Models.Entities.Doctor, DoctorResponseDto>()
            .ForMember(dest => dest.Branch, opt => opt.MapFrom(src => src.Branch.ToString())); // Enum'u string'e çevir

        //CreateMap<CreateDoctorRequest, HospitalAppointmentSystem.Models.Entities.Doctor>()
        //    .ForMember(dest => dest.Branch, opt => opt.MapFrom(src => src.Branch));
        CreateMap<CreateDoctorRequest, HospitalAppointmentSystem.Models.Entities.Doctor>()
            .ForMember(dest => dest.Branch, opt => opt.MapFrom(src => src.Branch));
        CreateMap<HospitalAppointmentSystem.Models.Entities.Doctor, DoctorWithAppointmentsResponseDto>()
            .ForMember(dest => dest.Branch, opt => opt.MapFrom(src => src.Branch));
    }
}
