using AutoMapper;
using HospitalAppointmentSystem.Models.Dtos.Appointments.Requests;
using HospitalAppointmentSystem.Models.Dtos.Appointments.Responses;
namespace HospitalAppointmentSystem.Service.Profiles.Appointment;
public class AppointmentMappingProfiles : Profile
{
    public AppointmentMappingProfiles()
    {
        CreateMap<CreateAppointmentRequest, HospitalAppointmentSystem.Models.Entities.Appointment>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(src => DateTime.Now))
                .ForMember(dest => dest.UpdatedDate, opt => opt.MapFrom(src => DateTime.Now));

        CreateMap<UpdateAppointmentRequest, HospitalAppointmentSystem.Models.Entities.Appointment>()
            .ForMember(dest => dest.CreatedDate, opt => opt.Ignore()) 
            .ForMember(dest => dest.UpdatedDate, opt => opt.MapFrom(src => DateTime.Now)); 

        CreateMap<HospitalAppointmentSystem.Models.Entities.Appointment, AppointmentResponseDto>()
            .ForMember(dest => dest.DoctorName, opt => opt.MapFrom(src => src.Doctor != null ? src.Doctor.Name : string.Empty));
    }
}
