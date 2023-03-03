using TRPOFirst.Domian;

namespace TRPOFirst.Contracts.Hospital.Requests;

public class UpdateDoctorsAppointment
{
    /// <summary>
    /// Атрибут представляющий собой ссылку на доктора, который проводил первичный осмотр
    /// </summary>
    public Doctors? idDoctor { get; set; }
    
    /// <summary>
    /// Атрибут представляющий собой ссылку на пациента, который был осмотрен
    /// </summary>
    public Pacients? IdPatient { get; set; }
    
    /// <summary>
    /// Атрибут представляющий собой дату осмотра
    /// </summary>
    public DateTime? DateRecording { get; set; }
}