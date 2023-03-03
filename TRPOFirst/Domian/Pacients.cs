namespace TRPOFirst.Domian;

/// <summary>
/// Сущьность представляющая собой таблицу с пациентами больницы
/// </summary>
public class Pacients
{
    /// <summary>
    /// Атрибут представляющий собой уникальный для каждого пациента идентификатор
    /// </summary>
    public Guid IdPacient { get; set; }
    
    /// <summary>
    /// Атрибут представляющий собой Имя пациента
    /// </summary>
    public string FirstName { get; set; }
    
    /// <summary>
    /// Атрибут представляющий собой Фамилию пациента
    /// </summary>
    public string LastName { get; set; }
    
    /// <summary>
    /// Атрибут представляющий собой отчество пациента
    /// </summary>
    public string MiddleName { get; set; }
    
    /// <summary>
    /// Атрибут представляющий собой возвраст пациента
    /// </summary>
    public short Age { get; set; }
    
    /// <summary>
    /// Атрибут представляющий собой уникальный для каждого пациента полис
    /// </summary>
    public string Polis { get; set; }
}