using EarlyBird.API.Controllers;
using EarlyBird.API.DomainModels;
using Microsoft.AspNetCore.Mvc;

namespace EarlyBird.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void GetAllPackage_CorrectNumber()
        {
            //Eftersom det innte finns en databas, använder jag samma data
            var controller = new PackageController();

            var result = controller.GetAllPackages() as OkObjectResult;
            var packages = result.Value as List<Package>;

            //Antal paket
            int count = 15;

            Assert.Equal(count, packages.Count);

        }

        [Fact]
        public void GetPackage_With_LowerId()
        {
            var controller = new PackageController();

            string id = "7805728439";
            var result = controller.GetPackage(id) as BadRequestObjectResult;
            var message = result.Value as string;

            Assert.Equal($"Package {id} måste vara 18 tecken långt.", message);
        }


        [Fact]
        public void GetPackage_That_DoesntStartCorrect()
        {
            var controller = new PackageController();

            string id = "998000000000000000";
            var result = controller.GetPackage(id) as BadRequestObjectResult;
            var message = result.Value as string;

            Assert.Equal($"Package {id} måste börja med 999.", message);
        }

        [Fact]
        public void GetPackage_With_Letters()
        {
            var controller = new PackageController();

            string id = "999000AB0000000015";
            var result = controller.GetPackage(id) as BadRequestObjectResult;
            var message = result.Value as string;

            Assert.Equal($"Package {id} måste innehålla bara siffror.", message);
        }

        [Fact]
        public void GetPackage_That_DoesntExists()
        {
            var controller = new PackageController();

            string id = "999000000000000015";
            var result = controller.GetPackage(id) as NotFoundObjectResult;
            var message = result.Value as string;

            Assert.Equal($"Package {id} finns inte.", message);
        }

        [Fact]
        public void GetPackage_With_CorrectId()
        {
            var controller = new PackageController();

            string id = "999000000000000014";
            var result = controller.GetPackage(id) as OkObjectResult;
            var package = result.Value as Package;

            Assert.NotNull(package);
        }

        [Fact]
        public void CreatePackage_With_WrongDimensions()
        {
            var controller = new PackageController();
            var package = new Package()
            {
                KolliId = "",
                Weight = 1,
                Height = 61,
                Width = 1,
                Length = 1,
            };

            var result = controller.CreatePackage(package) as BadRequestObjectResult;
            var message = result.Value as string;

            Assert.Equal("Inmatade data är felaktigt enligt EarlyBirs paketbegränsningar.", message);
        }

        [Fact]
        public void CreatePackage_With_CorrectDimensions()
        {
            var controller = new PackageController();

            var package = new Package()
            {
                KolliId = "",
                Weight = 1,
                Height = 1,
                Width = 1,
                Length = 1,
            };

            var result = controller.CreatePackage(package) as OkObjectResult;
            var newPackage = result.Value as Package;

            Assert.NotNull(newPackage);

        }
    }
}