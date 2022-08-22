using CRUD.Context;
using CRUD.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUD.Controllers
{
    [Route("api/[controller]")]
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
    }
}
