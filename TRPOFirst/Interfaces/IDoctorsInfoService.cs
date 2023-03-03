using TRPOFirst.Domian;

namespace TRPOFirst.Services;

public interface IDoctorsInfoService
{
    List<DoctorsInfo> GetDoctorsInfo();

    DoctorsInfo GetDoctorsInfoById(Guid IdDoctorsInfo);

    bool UpdateDoctorsInfo(DoctorsInfo updateToDoctorsInfo);
}