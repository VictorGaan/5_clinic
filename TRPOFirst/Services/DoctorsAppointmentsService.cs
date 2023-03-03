using TRPOFirst.Domian;
using TRPOFirst.Settings;

namespace TRPOFirst.Services;

public class DoctorsAppointmentsService : IDoctorsAppointmentsService
{
    private readonly List<DoctorsAppointments> _DoctorsAppointments; // Сущность представляющая доктора

    public DoctorsAppointmentsService()
    {
        _DoctorsAppointments = new List<DoctorsAppointments>();
        for (var i = 0; i < DataApi.QuantityRequest; i++)
        {
            _DoctorsAppointments.Add(new DoctorsAppointments
            {
                idDoctorsAppointments = Guid.NewGuid(),
                IdDoctor = null,
                IdPatient = null,
                DateRecording = DateTime.Now
            }); // Нулл будет до тех пор пока не свяяжу с АПИ с БД
        }
    }

    public List<DoctorsAppointments> GetDoctorsAppointments()
    {
        return _DoctorsAppointments;
    }

    public DoctorsAppointments GetDoctorsAppointmentsById(Guid idDoctorsAppointments)
    {
        var result = _DoctorsAppointments.SingleOrDefault(x => x.idDoctorsAppointments == idDoctorsAppointments);
        return result;
    }

    public bool UpdateDoctorsAppointments(DoctorsAppointments updateDoctorsAppointments)
    {
        var exist = GetDoctorsAppointmentsById(updateDoctorsAppointments.idDoctorsAppointments) != null;

        if (!exist)
            return false;

        var index = _DoctorsAppointments.FindIndex(x => x.idDoctorsAppointments == updateDoctorsAppointments.idDoctorsAppointments);
        _DoctorsAppointments[index] = updateDoctorsAppointments;
        return true;
    }
}