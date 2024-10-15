using Core.Repositories;
using HospitalAppointmentSystem.DataAccess.Abstracts;
using HospitalAppointmentSystem.DataAccess.Contexts;
using HospitalAppointmentSystem.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace HospitalAppointmentSystem.DataAccess.Concretes;
public class EfAppointmentRepository : EfRepositoryBase<BaseDbContext, Appointment, Guid>, IAppointmentRepository
{
    public EfAppointmentRepository(BaseDbContext context) : base(context)
    {
    }

    public async Task<int> GetCountByDoctorIdAsync(int doctorId)
    {
        return await Context.Appointments.CountAsync(a => a.DoctorId == doctorId);
    }
}
