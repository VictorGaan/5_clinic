using TRPOFirst.Domian;
using TRPOFirst.Settings;

namespace TRPOFirst.Services;

public class ScheduleResponseService : IScheduleResponseService
{
    private readonly List<ReceptionSchedule> _ReceptionSchedules; // Сущность представляющая доктора

    public ScheduleResponseService()
    {
        _ReceptionSchedules = new List<ReceptionSchedule>();
        for (int i = 0; i < DataApi.QuantityRequest; i++)
        {
            _ReceptionSchedules.Add(new ReceptionSchedule
            {
                IdReceptionSchedule = Guid.NewGuid(),
                StartWorkingTime = DateTime.Now,
                EndWorkingTime = DateTime.Now,
                DurationReception = "15"
            });
        }
    }

    public List<ReceptionSchedule> GetReceptionSchedule()
    {
        return _ReceptionSchedules;
    }

    public ReceptionSchedule GetReceptionScheduleById(Guid idReceptionSchedule)
    {
        var result = _ReceptionSchedules.SingleOrDefault(x => x.IdReceptionSchedule == idReceptionSchedule);
        return result;
    }

    public bool UpdateReceptionSchedule(ReceptionSchedule updateToReceptionSchedule)
    {
        var exist = GetReceptionScheduleById(updateToReceptionSchedule.IdReceptionSchedule) != null;

        if (!exist)
            return false;

        var index = _ReceptionSchedules.FindIndex(x => x.IdReceptionSchedule == updateToReceptionSchedule.IdReceptionSchedule);
        _ReceptionSchedules[index] = updateToReceptionSchedule;
        return true;
    }
}