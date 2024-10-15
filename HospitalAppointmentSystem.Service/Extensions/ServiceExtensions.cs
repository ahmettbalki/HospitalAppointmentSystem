using Core.UnitOfWorks;
using FluentValidation;
using FluentValidation.AspNetCore;
using HospitalAppointmentSystem.DataAccess.Contexts;
using HospitalAppointmentSystem.Service.Abstracts;
using HospitalAppointmentSystem.Service.Concretes;
using HospitalAppointmentSystem.Service.ExceptionHandlers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
namespace HospitalAppointmentSystem.Service.Extensions;
public static class ServiceExtensions
{
    public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IDoctorService, DoctorService>();
        services.AddScoped<IAppointmentService, AppointmentService>();
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddFluentValidationAutoValidation();
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.AddExceptionHandler<CriticalExceptionHandler>();
        services.AddExceptionHandler<GlobalExceptionHandler>();
        services.AddScoped<IUnitOfWork, UnitOfWork<BaseDbContext>>();
        return services;
    }
}
