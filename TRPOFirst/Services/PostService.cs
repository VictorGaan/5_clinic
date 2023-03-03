using TRPOFirst.Domian;
using TRPOFirst.Settings;

namespace TRPOFirst.Services;

public class PostService : IPostService
{
    private readonly List<Posts> _posts; // Сущность представляющая доктора

    public PostService()
    {
        _posts = new List<Posts>();
        for (int i = 0; i < DataApi.QuantityRequest; i++)
        {
            _posts.Add(new Posts
            {
                IdPost = Guid.NewGuid(),
                PostTitle = "Должность " + i
            });
        }
    }

    public List<Posts> GetPosts()
    {
        return _posts;
    }

    public Posts GetPostById(Guid idPosts)
    {
        var result = _posts.SingleOrDefault(x => x.IdPost == idPosts);
        return result;
    }

    public bool UpdatePost(Posts updateToPosts)
    {
        var exist = GetPostById(updateToPosts.IdPost) != null;

        if (!exist)
            return false;

        var index = _posts.FindIndex(x => x.IdPost == updateToPosts.IdPost);
        _posts[index] = updateToPosts;
        return true;
    }
}