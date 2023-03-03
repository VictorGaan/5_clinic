using TRPOFirst.Domian;

namespace TRPOFirst.Services;

public interface IPostService
{
    List<Posts> GetPosts();

    Posts GetPostById(Guid idPosts);

    bool UpdatePost(Posts updateToPosts);
}