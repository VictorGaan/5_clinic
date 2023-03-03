using TRPOFirst.Domian;

namespace TRPOFirst.Contracts.Hospital.Responses;

public class DoctorsAppointmentResponse
{
    /// <summary>
    /// Атрибут представляющий собой уникальный для каждого приёма идентификатор
    /// </summary>
    public Guid? idDoctorsAppointments { get; set; }
    
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