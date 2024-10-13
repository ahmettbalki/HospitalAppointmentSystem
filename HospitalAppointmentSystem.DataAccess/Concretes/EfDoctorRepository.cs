using Core.Repositories;
using HospitalAppointmentSystem.DataAccess.Contexts;
using HospitalAppointmentSystem.Models.Entities;
namespace HospitalAppointmentSystem.DataAccess.Concretes;
public class EfDoctorRepository : EfRepositoryBase<BaseDbContext, Doctor, int>
{
    public EfDoctorRepository(BaseDbContext context) : base(context)
    {
    }
}
