using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [Route("ABCD")]
        [HttpGet]
        public string GetName()
        {
            return "Test";
        }

        [Route("GetFullName")]
        [HttpGet]
        public string GetFullName()
        {
            return "Md Rasel";
        }
    }
}
