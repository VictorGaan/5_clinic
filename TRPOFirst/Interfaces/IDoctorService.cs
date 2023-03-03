using TRPOFirst.Domian;

namespace TRPOFirst.Services;

public interface IDoctorService
{
    List<Doctors> GetDoctors();

    Doctors GetDoctorById(Guid IdDoctor);

    bool UpdateDoctor(Doctors updateToDoctors);
}