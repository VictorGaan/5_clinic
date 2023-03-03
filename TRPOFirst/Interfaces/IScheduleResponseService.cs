using TRPOFirst.Domian;

namespace TRPOFirst.Services;

public interface IScheduleResponseService
{
    List<ReceptionSchedule> GetReceptionSchedule();

    ReceptionSchedule GetReceptionScheduleById(Guid idReceptionSchedule);

    bool UpdateReceptionSchedule(ReceptionSchedule updateReceptionSchedule);
}