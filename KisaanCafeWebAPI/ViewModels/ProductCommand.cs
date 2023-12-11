namespace KisaanCafeWebAPI.ViewModels
{
    public class ProductCommand
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Prize { get; set; }
        public decimal Weight { get; set; }
        public byte[] ImageData { get; set; }
    }
}
