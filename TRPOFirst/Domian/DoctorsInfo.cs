namespace TRPOFirst.Domian;

/// <summary>
/// Сущность представляющая дополнительную информацию о докторе
/// </summary>
public class DoctorsInfo
{
    /// <summary>
    /// Атрибут представляющий собой уникальный для каждого пациента идентификатор
    /// </summary>
    public Guid IdDoctorsInfo { get; set; }
    
    /// <summary>
    /// Атрибут представляющий собой Имя пациента
    /// </summary>
    public string ReceptionTime { get; set; }
}