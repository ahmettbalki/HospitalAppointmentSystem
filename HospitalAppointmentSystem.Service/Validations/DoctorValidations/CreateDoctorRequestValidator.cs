using FluentValidation;
using HospitalAppointmentSystem.Models.Dtos.Doctors.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalAppointmentSystem.Service.Validations.DoctorValidations
{
    public class CreateDoctorRequestValidator : AbstractValidator<CreateDoctorRequest>
    {
        public CreateDoctorRequestValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Doktor ismi boş olamaz.")
                .Length(2, 128).WithMessage("Doktor ismi 2 ile 128 karakter arası olmalıdır.");
            RuleFor(x => x.Branch)
                .NotEmpty().WithMessage("Branş alanı boş olamaz");
        }
    }
}
