using DELIGHT.Core.Domain.Common;

namespace DELIGHT.Core.Domain.Entities
{
    public class Mint : BaseEntity
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
