using EarlyBird.API.DomainModels;
using EarlyBirdTestAPI.Data;
using Microsoft.AspNetCore.Mvc;

namespace EarlyBird.API.Controllers
{
    [ApiController]
    [Route("package")]
    public class PackageController : ControllerBase
    {
        List<Package> _packages;
        public PackageController() => _packages = DataItems.GetPackages();

        //Hämta alla paket
        [HttpGet()]
        public IActionResult GetAllPackages()
        {
            try
            {
                return Ok(_packages);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}