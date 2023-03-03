using TRPOFirst.Domian;

namespace TRPOFirst.Contracts.Hospital.Responses;

public class ReseptionResponse
{
    // <summary>
    /// Идентификатор
    /// </summary>
    public Guid IdReception { get; set; }

    /// <summary>
    /// Ссылка на первичный осмотр врача
    /// </summary>
    public DoctorsAppointments? IdAppointments { get; set; }
    
    /// <summary>
    /// Жалобы пациента
    /// </summary>
    public string? Complaints { get; set; }
    
    /// <summary>
    /// Диагноз для пациента
    /// </summary>
    public Diseases? IdDisease { get; set; }
    
    /// <summary>
    /// Дата приёма у вврача
    /// </summary>
    public DateTime DateReception { get; set; }
}