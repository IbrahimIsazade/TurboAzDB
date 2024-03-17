using TurboAzDB.Models.StableModels;

namespace TurboAzDB.Models.Entities
{
    public class Announcement
    {
        public int Id { get; private set; }
        public int Price { get; set; }
        public int Year { get; set; }
        public decimal Mileage { get; set; }
        public int BrandId { get; set; }
        public int ModelId { get; set; }
        public FuelType FuelType { get; set; }
        public SpeedBox SpeedBox { get; set; }
        public BanType BanType { get; set; }
        public Transmitter Transmitter { get; set; }

        public int CreatedBy { get; set; } = 1;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public int? LastModifiedBy { get; set; }
        public DateTime? LastModifiedAt { get; set; }
        public int? DeletedBy { get; set; }
        public DateTime? DeletedAt { get; set; }

        public Announcement(int price, int year, decimal mileage, int brandId, int modelId, FuelType fuelType, SpeedBox speedBox, BanType banType, Transmitter transmitter)
        {
            Price = price;
            Year = year;
            Mileage = mileage;
            BrandId = brandId;
            ModelId = modelId;
            FuelType = fuelType;
            SpeedBox = speedBox;
            BanType = banType;
            Transmitter = transmitter;
        }

        public void Edit(int price, int year, decimal mileage, int brandId, int modelId, FuelType fuelType, SpeedBox speedBox, BanType banType, Transmitter transmitter)
        {
            this.Price = price;
            this.Year = year;
            this.Mileage = mileage;
            this.BrandId = brandId;
            this.ModelId = modelId;
            this.FuelType = fuelType;
            this.SpeedBox = speedBox;
            this.BanType = banType;
            this.Transmitter = transmitter;
        }

        public override string ToString()
        {
            return $"---- Announcement {Id} ----\nBrand: {BrandId}\nModel: {ModelId}\nYear: {Year}\nMileage: {Mileage}\nFuel type: {Enum.GetName(typeof(FuelType), FuelType)}\nSpeed box: {Enum.GetName(typeof(SpeedBox), SpeedBox)}\nBan type: {Enum.GetName(typeof(BanType), BanType)}\nTransmitter: {Enum.GetName(typeof(Transmitter), Transmitter)}\n----------";
        }
    }
}
