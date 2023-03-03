using TRPOFirst.Domian;
using TRPOFirst.Settings;

namespace TRPOFirst.Services;

public class DoctorsInfoService : IDoctorsInfoService
{
    private readonly List<DoctorsInfo> _doctorsInfo; // Сущность представляющая доктора

    public DoctorsInfoService()
    {
        _doctorsInfo = new List<DoctorsInfo>();
        for (int i = 0; i < DataApi.QuantityRequest; i++)
        {
            _doctorsInfo.Add(new DoctorsInfo
            {
                IdDoctorsInfo = Guid.NewGuid(),
                ReceptionTime = $"{i}"
            });
        }
    }

    public List<DoctorsInfo> GetDoctorsInfo()
    {
        return _doctorsInfo;
    }

    public DoctorsInfo GetDoctorsInfoById(Guid idDoctorsInfo)
    {
        var result = _doctorsInfo.SingleOrDefault(x => x.IdDoctorsInfo == idDoctorsInfo);
        return result;
    }

    public bool UpdateDoctorsInfo(DoctorsInfo updateToDoctorsInfo)
    {
        var exist = GetDoctorsInfoById(updateToDoctorsInfo.IdDoctorsInfo) != null;

        if (!exist)
            return false;

        var index = _doctorsInfo.FindIndex(x => x.IdDoctorsInfo == updateToDoctorsInfo.IdDoctorsInfo);
        _doctorsInfo[index] = updateToDoctorsInfo;
        return true;
    }
}