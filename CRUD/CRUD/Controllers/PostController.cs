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
        public ActionResult<List<Post>> GettAll()
        {
            var posts = _postManager.GetAll().ToList();
            return Ok(posts);
        }

        [HttpGet("{id}")]
        public ActionResult<Post> GetById(int id)
        {
            var post = _postManager.GetById(id);
            if (post == null)
            { 
                return NotFound("Data has not been found");
            }
            return Ok(post);
        }

        [HttpPost]
        public ActionResult<Post> Add(Post post)
        { 
            post.CreatedDate = DateTime.Now;
            bool isSaved = _postManager.Add(post);
            if (isSaved)
            {
                return Created("", post);
            }
            return BadRequest("Post save failed");
        }

        [HttpPut]
        public ActionResult<Post> Edit(Post post)
        {
            if (post.Id == 0)
            {
                return BadRequest("Id is missing");
            }
            bool isUpdate = _postManager.Update(post);
            if (isUpdate)
            {
                return Ok(post);
            }
            return BadRequest("Post update failed");
        }

        [HttpDelete]
        public ActionResult<string> Delete(int id)
        {
            var post = _postManager.GetById(id);
            if (post == null)
            {
                return NotFound("Data not found");
            }
            bool isDelete = _postManager.Delete(post);
            if (isDelete)
            {
                return Ok("Post has been deleted");
            }
            return BadRequest("Post delete faild");
        }
    }
}

