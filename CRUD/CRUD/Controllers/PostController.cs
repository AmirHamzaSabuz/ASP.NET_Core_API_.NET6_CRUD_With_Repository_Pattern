using CoreApiResponse;
using CRUD.Context;
using CRUD.Interfaces.Manager;
using CRUD.Manager;
using CRUD.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CRUD.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PostController : BaseController
    {
        IPostManager _postManager;
        public PostController(IPostManager postManager)
        {
            _postManager = postManager;
        }

        [HttpGet]
        public IActionResult GetAllPOsts()
        {
            try
            {
                var posts = _postManager.GetAll().OrderBy(p=>p.Title).ThenBy(p=>p.Description).ToList();
                return CustomResult("Data loaded successfully", posts);
            }
            catch(Exception ex)
            {
                return CustomResult(ex.Message, HttpStatusCode.BadRequest);
            }
           
        }

        [HttpGet("title")]
        public IActionResult GetAllPosts(string title)
        {
            try
            {
                var posts = _postManager.GetAllByTitle(title).ToList();
                return CustomResult("Data loaded successfully", posts);
            }
            catch (Exception ex)
            {
                return CustomResult(ex.Message, HttpStatusCode.BadRequest);
            }

        }

        [HttpGet]
        public IActionResult GetAllPostsDescending()
        {
            try
            {
                var posts = _postManager.GetAll().OrderByDescending(p => p.Title).ThenByDescending(p=>p.Description).ToList();
                return CustomResult("Data loaded successfully", posts);
            }
            catch (Exception ex)
            {
                return CustomResult(ex.Message, HttpStatusCode.BadRequest);
            }

        }

        [HttpGet("{id}")]
        public IActionResult GetPostById(int id)
        {
            try
            {
                var post = _postManager.GetById(id);
                if (post == null)
                {
                    return CustomResult("Data Not Found", HttpStatusCode.NotFound);
                }
                return CustomResult("Data Found",post);
            }
            catch(Exception ex)
            {
                return CustomResult(ex.Message, HttpStatusCode.BadRequest);
            }
            
        }

        [HttpPost]
        public IActionResult AddPost(Post post)
        {
            try
            {
                post.CreatedDate = DateTime.Now;
                bool isSaved = _postManager.Add(post);
                if (isSaved)
                {
                    return CustomResult("Post has been created", post);
                }
                return CustomResult("Post save failed", HttpStatusCode.BadRequest);
            }
            catch(Exception ex)
            {
                return CustomResult(ex.Message, HttpStatusCode.BadRequest);
            }
            
        }

        [HttpPut]
        public IActionResult EditPost(Post post)
        {
            try
            {
                if (post.Id == 0)
                {
                    return CustomResult("Id is missing", HttpStatusCode.BadRequest);
                }
                bool isUpdate = _postManager.Update(post);
                if (isUpdate)
                {
                    return CustomResult("Post updated done", post);
                }
                return CustomResult("Post update failed", HttpStatusCode.BadRequest);               
            }
            catch(Exception ex)
            {
                return CustomResult(ex.Message, HttpStatusCode.BadRequest);
            }
        }   

        [HttpDelete]
        public IActionResult DeletePost(int id)
        {
            try
            {
                var post = _postManager.GetById(id);
                if (post == null)
                {
                    return CustomResult("Data not found", HttpStatusCode.NotFound);
                }
                bool isDelete = _postManager.Delete(post);
                if (isDelete)
                {
                    return CustomResult("Post has been deleted");
                }
                return CustomResult("Post deleted failed", HttpStatusCode.BadRequest);
            }
            catch (Exception ex)
            {
                return CustomResult(ex.Message, HttpStatusCode.BadRequest);
            }
            
        }
    }
}

