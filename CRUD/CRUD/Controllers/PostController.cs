using CRUD.Context;
using CRUD.Interfaces.Manager;
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
        IPostManager _postManager;
        public PostController(IPostManager postManager)
        {
            _postManager = postManager;
        }

        [HttpGet]
        public List<Post> GettAll()
        {
            var posts = _postManager.GetAll().ToList();
            return posts;
        }

        [HttpGet("{id}")]
        public Post GetById(int id)
        {
            var post = _postManager.GetById(id);
            return post;
        }

        [HttpPost]
        public Post Add(Post post)
        { 
            post.CreatedDate = DateTime.Now;
            bool isSaved = _postManager.Add(post);
            if (isSaved)
            {
                return post;
            }
            return null;
        }

        [HttpPut]
        public Post Edit(Post post)
        {
            if (post.Id == 0)
            {
                return null;
            }
            bool isUpdate = _postManager.Update(post);
            if (isUpdate)
            {
                return post;
            }
            return post;
        }

        [HttpDelete]
        public string Delete(int id)
        {
            var post = _postManager.GetById(id);
            if (post == null)
            {
                return "Data not found";
            }
            bool isDelete = _postManager.Delete(post);
            if (isDelete)
            {
                return "Post has been deleted";
            }
            return "Post delete faild";
        }
    }
}

