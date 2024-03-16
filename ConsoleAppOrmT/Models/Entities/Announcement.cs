using TurboAzDB.Models.StableModels;

namespace TurboAzDB.Models.Entities
{
    public class Announcement
    {
        public int Id { get; private set; }
        public int Price { get; private set; }
        public int Year { get; private set; }
        public decimal Mileage { get; private set; }
        public int BrandId { get; private set; }
        public int ModelId { get; private set; }
        public FuelType FuelType { get; private set; }
        public SpeedBox SpeedBox { get; private set; }
        public BanType BanType { get; private set; }
        public Transmitter Transmitter { get; private set; }

        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public int LastModifiedBy { get; set; }
        public DateTime LastModifiedAt { get; set; }
        public int DeletedBy { get; set; }
        public DateTime DeletedAt { get; set; }

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
