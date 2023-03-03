using TRPOFirst.Domian;

namespace TRPOFirst.Services;

public interface IReceptionService
{
    List<Reseption> GetReseption();

    Reseption GetReseptionById(Guid IdReception);

    bool UpdateReseption(Reseption updateReseption);
}