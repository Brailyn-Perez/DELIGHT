namespace DELIGHT.Core.Application.Dtos.Mint
{
    public class UpdateMint
    {
        public string Name { get; set; }
        public string Country { get; set; }
        public double SugarContent { get; set; }
        public string Flavor { get; set; }
        public double WeightInGrams { get; set; }
        public double Price { get; set; }
        public double PricePerUnit { get; set; }
    }
}
