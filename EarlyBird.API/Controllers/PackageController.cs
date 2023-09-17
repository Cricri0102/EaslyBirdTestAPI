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

        //H�mta alla paket
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
                //KolliId ska vara exact 18 tecken l�ngt
                if (id.Length != 18)
                {
                    return BadRequest($"Package {id} m�ste vara 18 tecken l�ngt.");
                }

                //KolliId ska bara inneh�lla siffror
                if (!Regex.IsMatch(id, @"^[0-9]+$"))
                {
                    return BadRequest($"Package {id} m�ste inneh�lla bara siffror.");
                }

                //KolliId ska b�rja p� 999
                if (!id.StartsWith("999"))
                {
                    return BadRequest($"Package {id} m�ste b�rja med 999.");
                }

                //KolliId m�ste finnas i 'databasen'
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
                    return BadRequest("Inmatade data �r felaktigt enligt EarlyBirs paketbegr�nsningar.");
                }

                //Scapa en random KolliId f�r nya paketet
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