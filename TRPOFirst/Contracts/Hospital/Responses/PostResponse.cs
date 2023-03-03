namespace TRPOFirst.Contracts.Hospital.Responses;

public class PostResponse
{
    // <summary>
    /// Идентификатор
    /// </summary>
    public Guid IdPost { get; set; }

    /// <summary>
    /// Название специальности
    /// </summary>
    public string PostTitle { get; set; }
}