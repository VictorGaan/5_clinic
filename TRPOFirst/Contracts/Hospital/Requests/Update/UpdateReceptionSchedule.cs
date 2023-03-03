namespace TRPOFirst.Contracts.Hospital.Requests;

public class UpdateReceptionSchedule
{
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