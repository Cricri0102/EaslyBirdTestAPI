using Microsoft.AspNetCore.Mvc;

namespace EarlyBird.API.Controllers
{
    [ApiController]
    [Route("package")]
    public class PackageController : ControllerBase
    {

        public PackageController()
        {
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IActionResult GetPackage()
        {
            return Ok();
        }
    }
}