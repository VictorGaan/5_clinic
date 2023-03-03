using TRPOFirst.Domian;
using TRPOFirst.Settings;

namespace TRPOFirst.Services;

public class DiseasesService : IDiseasesService
{
    private readonly List<Diseases> _diseases; // Сущность представляющая доктора

    public DiseasesService()
    {
        _diseases = new List<Diseases>();
        for (int i = 0; i < DataApi.QuantityRequest; i++)
        {
            _diseases.Add(new Diseases
            {
                IdDiseases = Guid.NewGuid(),
                Title = $"Болезьнь под номером {i+1}",
                Code = $"{i+1000}",
                Discription = "Какое-то описание которое нечего не значит"
            });
        }
    }

    public List<Diseases> GetDiseases()
    {
        return _diseases;
    }

    public Diseases GetDiseasesById(Guid IdDiseases)
    {
        var result = _diseases.SingleOrDefault(x => x.IdDiseases == IdDiseases);
        return result;
    }

    public bool UpdateDiseases(Diseases updateToDiseases)
    {
        var exist = GetDiseasesById(updateToDiseases.IdDiseases) != null;

        if (!exist)
            return false;

        var index = _diseases.FindIndex(x => x.IdDiseases == updateToDiseases.IdDiseases);
        _diseases[index] = updateToDiseases;
        return true;
    }
}