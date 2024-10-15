using Core.Repositories;
using HospitalAppointmentSystem.DataAccess.Abstracts;
using HospitalAppointmentSystem.DataAccess.Contexts;
using HospitalAppointmentSystem.Models.Entities;
namespace HospitalAppointmentSystem.DataAccess.Concretes;
public class EfDoctorRepository : EfRepositoryBase<BaseDbContext, Doctor, int>, IDoctorRepository
{
    public EfDoctorRepository(BaseDbContext context) : base(context)
    {
    }
}
