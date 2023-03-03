using Microsoft.AspNetCore.Mvc;
using TRPOFirst.Contracts.Hospital;
using TRPOFirst.Contracts.Hospital.Requests;
using TRPOFirst.Contracts.Hospital.Responses;
using TRPOFirst.Services;
using TRPOFirst.Domian;

namespace TRPOFirst.Controllers.Hospital;

public class PostsController : Controller
{
    private readonly IPostService _postService;
    
    public PostsController(IPostService postService)
    {
        _postService = postService;
    }
    [HttpGet(ApiRoutes.Hospital.GetAllPosts)]
    public IActionResult GetAll()
    {
        return Ok(_postService.GetPosts());
    }
    
    [HttpPut(ApiRoutes.Hospital.UpdatePosts)]
    public IActionResult UpdatePosts([FromRoute]Guid idPost, [FromBody] UpdatePostRequest request)
    {
        var post = new Posts()
        {
            IdPost = idPost,
            PostTitle = request.PostTitle
        };

        var updated = _postService.UpdatePost(post);

        if (updated)
            return Ok(post);
        
        return NotFound();
    }
    
    [HttpGet(ApiRoutes.Hospital.GetPosts)] // Проклетая строчка из за которой 2 дня еб23424к23к2я №;№";
    public IActionResult Get([FromRoute]Guid idPost)
    {
        var post = _postService.GetPostById(idPost);
        if (post == null)
            return NotFound(); // Если результат будет отсутствовать, то вывести ошибку 404
        
        return Ok(post);
    }

    [HttpPost(ApiRoutes.Hospital.CreatePosts)]
    public IActionResult Create([FromBody] CreatePostsRequest postRequest)
    {
        var post = new Posts
        {
            IdPost = postRequest.IdPost,
            PostTitle = postRequest.PostTitle
        };

        if (post.IdPost != Guid.Empty)
            post.IdPost = Guid.NewGuid();

        _postService.GetPosts().Add(post);

        var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";

        var locationUri = baseUrl + "/" +
                          ApiRoutes.Hospital.GetPacients.Replace("{idPost}", post.IdPost.ToString());

        var response = new PostResponse
        {
            IdPost = postRequest.IdPost,
            PostTitle = postRequest.PostTitle
        };

        return Created(locationUri, response);
    }
}