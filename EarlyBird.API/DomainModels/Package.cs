namespace EarlyBird.API.DomainModels
{
    public class Package
    {
        public string KolliId { get; set; }
        public int Weight { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int Length { get; set; }
        public bool IsValid
        {
            get
            {
                return !(Weight > 2000 || Width > 60 || Length > 60 || Height > 60);
            }
        }
    }
}
