using CRUD.Context;
using CRUD.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUD.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        ApplicationDbContext _applicationDbContext;
        public PostController(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        [HttpGet]
        public List<Post> GettAll()
        {
            var posts = _applicationDbContext.Posts.ToList();
            return posts;
        }

        [HttpPost]
        public Post Add(Post post)
        { 
            post.CreatedDate = DateTime.Now;
            _applicationDbContext.Posts.Add(post);
            bool isSaved = _applicationDbContext.SaveChanges() > 0;
            if (isSaved)
            {
                return post;
            }
            return null;
        }
    }
}
