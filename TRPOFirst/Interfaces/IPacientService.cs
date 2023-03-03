using TRPOFirst.Domian;

namespace TRPOFirst.Services;

public interface IPacientService
{
    List<Pacients> GetPacient();

    Pacients GetPacientById(Guid idPacient);

    bool UpdatePacient(Pacients updateToPacient);
}