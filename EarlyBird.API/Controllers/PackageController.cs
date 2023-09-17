using EarlyBird.API.DomainModels;
using EarlyBirdTestAPI.Data;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

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

        [HttpGet("{id}")]
        public IActionResult GetPackage(string id)
        {
            try
            {
                //KolliId ska vara exact 18 tecken långt
                if (id.Length != 18)
                {
                    return BadRequest($"Package {id} måste vara 18 tecken långt.");
                }

                //KolliId ska bara innehålla siffror
                if (!Regex.IsMatch(id, @"^[0-9]+$"))
                {
                    return BadRequest($"Package {id} måste innehålla bara siffror.");
                }

                //KolliId ska börja på 999
                if (!id.StartsWith("999"))
                {
                    return BadRequest($"Package {id} måste börja med 999.");
                }

                //KolliId måste finnas i 'databasen'
                var package = _packages.Where(exp => exp.KolliId == id).FirstOrDefault();
                if (package == null)
                {
                    return NotFound($"Package {id} finns inte.");
                }

                return Ok(_packages.FirstOrDefault());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        public IActionResult CreatePackage(Package package)
        {
            try
            {
                if (!package.IsValid)
                {
                    return BadRequest("Inmatade data är felaktigt enligt EarlyBirs paketbegränsningar.");
                }

                //Scapa en random KolliId för nya paketet
                Random rnd = new Random();

                package.KolliId = "999" + rnd.Next(1000000, 9999999);
                package.KolliId += rnd.Next(10000000, 99999999);

                _packages.Add(package);

                return GetPackage(package.KolliId);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}