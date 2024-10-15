using FluentValidation;
using HospitalAppointmentSystem.Models.Dtos.Appointments.Requests;
namespace HospitalAppointmentSystem.Service.Validations.AppointmentValidations;
public class CreateAppointmentValidation : AbstractValidator<CreateAppointmentRequest>
{
    public CreateAppointmentValidation()
    {
        RuleFor(x => x.PatientName)
                .NotEmpty().WithMessage("Hasta ismi boş olamaz.")
                .Length(2, 128).WithMessage("Hasta ismi 2 ile 128 karakter arası olmalıdır.");
        RuleFor(x => x.DoctorId)
            .NotEmpty().WithMessage("Doktor alanı boş olamaz");
    }
}