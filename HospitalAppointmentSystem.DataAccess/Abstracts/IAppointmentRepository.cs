using Core.Repositories;
using HospitalAppointmentSystem.Models.Entities;
namespace HospitalAppointmentSystem.DataAccess.Abstracts;
public interface IAppointmentRepository : IGenericRepository<Appointment, Guid>
{
    Task<int> GetCountByDoctorIdAsync(int doctorId);
}
