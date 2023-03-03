namespace TRPOFirst.Domian;

/// <summary>
/// Сущность представляющая специальности докторов
/// </summary>
public class Posts
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