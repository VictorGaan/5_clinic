using TRPOFirst.Domian;

namespace TRPOFirst.Services;

public interface IDoctorsAppointmentsService
{
    List<DoctorsAppointments> GetDoctorsAppointments();

    DoctorsAppointments GetDoctorsAppointmentsById(Guid IdDiseases);

    bool UpdateDoctorsAppointments(DoctorsAppointments updateToDoctorsAppointments);
}