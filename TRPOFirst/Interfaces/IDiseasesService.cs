using TRPOFirst.Domian;

namespace TRPOFirst.Services;

public interface IDiseasesService
{
    List<Diseases> GetDiseases();

    Diseases GetDiseasesById(Guid IdDiseases);

    bool UpdateDiseases(Diseases updateDiseases);
}