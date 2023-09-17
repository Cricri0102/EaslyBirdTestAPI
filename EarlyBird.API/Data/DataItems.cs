using EarlyBird.API.DomainModels;

namespace EarlyBirdTestAPI.Data
{
    public class DataItems
    {
        public static List<Package> GetPackages()
        {
            List<Package> Packages = new List<Package>();
            Packages.Add(new Package() { KolliId = "1", Height = 20, Length = 20, Weight = 20, Width = 20 });
            Packages.Add(new Package() { KolliId = "999000000000000001", Height = 20, Length = 20, Weight = 20, Width = 20 });
            Packages.Add(new Package() { KolliId = "999000000000000002", Height = 20, Length = 20, Weight = 20, Width = 20 });
            Packages.Add(new Package() { KolliId = "999000000000000003", Height = 20, Length = 20, Weight = 20, Width = 20 });
            Packages.Add(new Package() { KolliId = "999000000000000004", Height = 120, Length = 20, Weight = 20, Width = 20 });
            Packages.Add(new Package() { KolliId = "999000000000000005", Height = 20, Length = 20, Weight = 20, Width = 20 });
            Packages.Add(new Package() { KolliId = "999000000000000006", Height = 20, Length = 20, Weight = 20, Width = 20 });
            Packages.Add(new Package() { KolliId = "999000000000000007", Height = 20, Length = 20, Weight = 2500, Width = 20 });
            Packages.Add(new Package() { KolliId = "999000000000000008", Height = 20, Length = 20, Weight = 20, Width = 20 });
            Packages.Add(new Package() { KolliId = "999000000000000009", Height = 20, Length = 20, Weight = 20, Width = 20 });
            Packages.Add(new Package() { KolliId = "999000000000000010", Height = 20, Length = 80, Weight = 20, Width = 20 });
            Packages.Add(new Package() { KolliId = "999000000000000011", Height = 20, Length = 20, Weight = 20, Width = 20 });
            Packages.Add(new Package() { KolliId = "999000000000000012", Height = 20, Length = 20, Weight = 20, Width = 610 });
            Packages.Add(new Package() { KolliId = "999000000000000013", Height = 20, Length = 20, Weight = 20, Width = 20 });
            Packages.Add(new Package() { KolliId = "999000000000000014", Height = 20, Length = 20, Weight = 20, Width = 20 });

            return Packages;
        }
    }
}
