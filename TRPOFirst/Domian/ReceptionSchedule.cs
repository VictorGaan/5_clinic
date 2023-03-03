namespace TRPOFirst.Domian;

/// <summary>
/// Сущность представляющая расписание доктора
/// </summary>
public class ReceptionSchedule
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    public Guid IdReceptionSchedule { get; set; }

    /// <summary>
    /// Время начала работы
    /// </summary>
    public DateTime StartWorkingTime { get; set; }

    /// <summary>
    /// Время окончания работы
    /// </summary>
    public DateTime EndWorkingTime { get; set; }
    
    /// <summary>
    /// Продолжительность приема
    /// </summary>
    public string DurationReception { get; set; }
}