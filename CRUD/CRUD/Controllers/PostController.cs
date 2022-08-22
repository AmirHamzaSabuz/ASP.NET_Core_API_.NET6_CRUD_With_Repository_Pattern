using CRUD.Context;
using CRUD.Manager;
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
        PostManager _postManager;
        public PostController(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
            _postManager = new PostManager(applicationDbContext);
        }

        [HttpGet]
        public List<Post> GettAll()
        {
            //var posts = _applicationDbContext.Posts.ToList();
            var posts = _postManager.GetAll().ToList();
            return posts;
        }

        [HttpPost]
        public Post Add(Post post)
        { 
            post.CreatedDate = DateTime.Now;
            //_applicationDbContext.Posts.Add(post);
            //bool isSaved = _applicationDbContext.SaveChanges() > 0;
            bool isSaved = _postManager.Add(post);
            if (isSaved)
            {
                return post;
            }
            return null;
        }
    }
}
