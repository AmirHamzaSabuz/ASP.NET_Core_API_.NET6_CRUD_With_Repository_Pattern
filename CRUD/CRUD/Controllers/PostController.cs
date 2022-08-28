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
        public IActionResult GettAll()
        {
            try
            {
                var posts = _postManager.GetAll().ToList();
                return CustomResult("Data loaded successfully", posts);
            }
            catch(Exception ex)
            {
                return CustomResult(ex.Message, HttpStatusCode.BadRequest);
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
        public IActionResult Add(Post post)
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
        public IActionResult Edit(Post post)
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
        public IActionResult Delete(int id)
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

