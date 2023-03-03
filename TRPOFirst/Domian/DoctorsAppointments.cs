namespace TRPOFirst.Domian;

/// <summary>
/// Сущьность представляющая собой таблицу первичных приёмов у врача
/// </summary>
public class DoctorsAppointments
{
    /// <summary>
    /// Атрибут представляющий собой уникальный для каждого приёма идентификатор
    /// </summary>
    public Guid idDoctorsAppointments { get; set; }
    
    /// <summary>
    /// Атрибут представляющий собой ссылку на доктора, который проводил первичный осмотр
    /// </summary>
    public Doctors? IdDoctor { get; set; }
    
    /// <summary>
    /// Атрибут представляющий собой ссылку на пациента, который был осмотрен
    /// </summary>
    public Pacients? IdPatient { get; set; }
    
    /// <summary>
    /// Атрибут представляющий собой дату осмотра
    /// </summary>
    public DateTime? DateRecording { get; set; }
}