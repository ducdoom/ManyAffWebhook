using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ManyAffWebhook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManyAffController : ControllerBase
    {
        [Route("test")]
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Success!");
        }


    }
}
