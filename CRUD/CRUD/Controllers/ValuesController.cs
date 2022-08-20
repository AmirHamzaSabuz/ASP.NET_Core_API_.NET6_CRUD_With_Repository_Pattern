using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [Route("[action]")]
        [HttpGet]
        public string GetName()
        {
            return "Test";
        }

        [Route("[action]")]
        [HttpGet]
        public string GetFullName()
        {
            return "Md Rasel";
        }
    }
}
