using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUD.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        
        [HttpGet]
        public string GetName()
        {
            return "Test";
        }

        
        [HttpGet]
        public string GetFullName()
        {
            return "Md Rasel";
        }
    }
}
