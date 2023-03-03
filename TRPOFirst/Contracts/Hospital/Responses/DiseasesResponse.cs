namespace TRPOFirst.Contracts.Hospital.Responses;

public class DiseasesResponse
{
    /// <summary>
    /// Атрибут представляющий собой уникальный для каждого диагноза идентификатор
    /// </summary>
    public Guid? IdDiseases { get; set; }
    
    /// <summary>
    /// Атрибут представляющий собой название заболевания
    /// </summary>
    public string? Title { get; set; }
    
    /// <summary>
    /// Атрибут представляющий собой код заболевания
    /// </summary>
    public string? Code { get; set; }
    
    /// <summary>
    /// Атрибут представляющий собой описание заболевания
    /// </summary>
    public string? Discription { get; set; }
}