using TRPOFirst.Domian;
using TRPOFirst.Settings;

namespace TRPOFirst.Services;

public class ReceptionService : IReceptionService
{
    private readonly List<Reseption> _reseption; // Сущность представляющая доктора

    public ReceptionService()
    {
        _reseption = new List<Reseption>();
        for (int i = 0; i < DataApi.QuantityRequest; i++)
        {
            _reseption.Add(new Reseption
            {
                IdReception = Guid.NewGuid(),
                IdAppointments = null,
                Complaints = $"Жалоба {i}, Жалоба {i+1}",
                IdDisease = null,
                DateReception = DateTime.Now
            });
        }
    }

    public List<Reseption> GetReseption()
    {
        return _reseption;
    }

    public Reseption GetReseptionById(Guid IdReception)
    {
        var result = _reseption.SingleOrDefault(x => x.IdReception == IdReception);
        return result;
    }

    public bool UpdateReseption(Reseption updateToReseption)
    {
        var exist = GetReseptionById(updateToReseption.IdReception) != null;

        if (!exist)
            return false;

        var index = _reseption.FindIndex(x => x.IdReception == updateToReseption.IdReception);
        _reseption[index] = updateToReseption;
        return true;
    }
}