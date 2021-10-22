using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MovieKnight.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {

        [HttpGet]
        [Route("test")]
        public IActionResult Test()
        {
            return Ok("Hello");
        }
    }
}
