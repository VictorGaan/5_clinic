namespace TRPOFirst.Contracts.Hospital.Requests;

public class CreatePostsRequest
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