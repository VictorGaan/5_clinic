using TRPOFirst.Domian;

namespace TRPOFirst.Contracts.Hospital.Requests;

public class CreateDoctorRequest
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    public Guid IdDoctor { get; set; }

    /// <summary>
    /// Имя доктора
    /// </summary>
    public string FirstName { get; set; }

    /// <summary>
    /// Фамилия доктора
    /// </summary>
    public string LastName { get; set; }

    /// <summary>
    /// Отчество доктора
    /// </summary>
    public string MiddleName { get; set; }
    
    /// <summary>
    /// Навигационное свойство, получающая значение посредством связи с сущностью DoctorsInfo
    /// </summary>
    public Posts? post { get; set; }

    /// <summary>
    /// Связь между ReceptionSchedule и Doctor
    /// </summary>
    public ICollection<ReceptionSchedule>? receptionSchedule { get; set; }
    
    /// <summary>
    /// Навигационное свойство, получающая значение посредством связи с сущностью DoctorsInfo
    /// </summary>
    public DoctorsInfo? DoctorInfo { get; set; }
}