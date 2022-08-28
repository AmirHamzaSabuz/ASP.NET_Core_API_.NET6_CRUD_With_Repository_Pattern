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
        public IActionResult GettAll()
        {
            try
            {
                var posts = _postManager.GetAll().ToList();
                return Ok(posts);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
           
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var post = _postManager.GetById(id);
                if (post == null)
                {
                    return NotFound("Data has not been found");
                }
                return Ok(post);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        [HttpPost]
        public IActionResult Add(Post post)
        {
            try
            {
                post.CreatedDate = DateTime.Now;
                bool isSaved = _postManager.Add(post);
                if (isSaved)
                {
                    return Created("", post);
                }
                return BadRequest("Post save failed");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        [HttpPut]
        public IActionResult Edit(Post post)
        {
            try
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
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }   

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            try
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
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }
    }
}

