using TurboAzDB.Extensions;
using TurboAzDB.Models.DataContexts;
using TurboAzDB.Models.Entities;
using TurboAzDB.Models.Stable;
using TurboAzDB.Models.StableModels;

namespace TurboAzDB
{
    internal class Program
    {
        static TurboAzDbContext db = new TurboAzDbContext();
        static ConsoleColor backupColor = Console.ForegroundColor;
        static bool changesSaved = true;
        static void Main()
        {
        l1:
            if (!changesSaved)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("CHANGES IN DATABASE ARE NOT SAVED !");
                Console.ForegroundColor = backupColor;
            }
            MenuOption menuOption = Extension.ChooseOption<MenuOption>("Choose from list: ", "Please choose option from list below");

            switch (menuOption)
            {
                //[ BRAND ]\\
                case MenuOption.AddBrand:
                    AddBrand();
                    changesSaved = false;
                    Console.Clear();
                    goto l1;
                case MenuOption.DeleteBrand:
                    DeleteBrand();
                    Console.Clear();
                    goto l1;
                case MenuOption.UpdateBrand:
                    UpdateBrand();
                    Console.Clear();
                    goto l1;
                case MenuOption.GetAllBrands:
                    Console.Clear();
                    GetAllBrands();
                    goto l1;
                case MenuOption.GetBrandById:
                    Console.Clear();
                    GetBrandById();
                    goto l1;


                //[ MODEL ]\\
                case MenuOption.AddModel:
                    AddModel();
                    changesSaved = false;
                    Console.Clear();
                    goto l1;
                case MenuOption.DeleteModel:
                    DeleteModel();
                    Console.Clear();
                    goto l1;
                case MenuOption.UpdateModel:
                    UpdateModel();
                    Console.Clear();
                    goto l1;
                case MenuOption.GetAllModels:
                    Console.Clear();
                    GetAllModels();
                    goto l1;
                case MenuOption.GetModelById:
                    Console.Clear();
                    GetModelById();
                    goto l1;


                //[ ANNOUNCEMENT ]\\
                case MenuOption.AddAnnouncement:
                    AddAnnouncemet();
                    changesSaved = false;
                    Console.Clear();
                    goto l1;
                case MenuOption.DeleteAnnouncement:
                    DeleteAnnouncemet();
                    Console.Clear();
                    goto l1;
                case MenuOption.UpdateAnnouncement:
                    UpdateAnnouncemet();
                    Console.Clear();
                    goto l1;
                case MenuOption.GetAllAnnouncements:
                    Console.Clear();
                    GetAllAnnouncemets();
                    goto l1;
                case MenuOption.GetAnnouncementById:
                    Console.Clear();
                    GetAnnouncementById();
                    goto l1;
                case MenuOption.GetAnnouncementByBrand:
                    Console.Clear();
                    GetAnnouncementByBrand();
                    goto l1;
                default:
                    break;

                case MenuOption.SaveChanges:
                    db.SaveChanges();
                    changesSaved = true;
                    Console.Clear();
                    goto l1;
            }

        }

        //[ BRAND METHODS ]\\
        static public void AddBrand()
        {
            Brand brand = new(Extension.ReadString("Enter the name of a new brand: "));

            db.Brands.Add(brand);
        }

        static public void UpdateBrand()
        {
            int id = Extension.GetIdFromList(db, db.Brands);

            if (ConfirmAction("update", "brand") == true)
            {
                Brand brand = db.Brands.FirstOrDefault(b => b.Id == id)!;
                if (brand != null)
                {
                    brand.Name = Extension.ReadString("Enter new name of the brand: ");
                    brand.LastModifiedAt = DateTime.Now;
                    brand.LastModifiedBy = 1;

                    db.Brands.Update(brand);
                }
                changesSaved = false;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("ACTION WAS CANCELLED!");
                Console.ForegroundColor = backupColor;
                Thread.Sleep(2000);
            }
        }

        static public void DeleteBrand()
        {
            int id = Extension.GetIdFromList(db, db.Brands);

            if (ConfirmAction("delete", "brand") == true)
            {
                Brand brand = db.Brands.FirstOrDefault(b => b.Id == id)!;
                if (brand != null)
                {
                    brand.DeletedAt = DateTime.Now;
                    brand.DeletedBy = 1;
                    db.Brands.Update(brand);
                }
                else
                {
                    Console.WriteLine($"THERE'S NO ANY BRAND BY ID ${id}");
                }
                changesSaved = false;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("ACTION WAS CANCELLED!");
                Console.ForegroundColor = backupColor;
                Thread.Sleep(2000);
            }
        }

        static public void GetAllBrands()
        {
            var rows = db.Brands;
            Console.WriteLine("===== Brands =====");
            foreach (var item in rows)
            {
                if (item.DeletedAt == null)
                    Console.WriteLine($"{item.Id}. {item.Name}");
            }
            Console.WriteLine("==================");
        }

        static public void GetBrandById()
        {
            var id = Extension.GetIdFromList(db, db.Brands);
            Console.Clear();
            Console.WriteLine($"===== Brand by id {id} =====");
            var item = db.Brands.FirstOrDefault(b => b.Id == id);
            if (item!.DeletedAt == null)
                Console.WriteLine($"Brand ID: {item.Id}, Brand Name: {item.Name}");
            Console.WriteLine("==================");
        }

        //[ MODEL METHODS ]\\
        static public void AddModel()
        {
            int id = Extension.GetIdFromList(db, db.Brands);
        getName:
            string name = Extension.ReadString("Enter the name of a new model: ");
            if (string.IsNullOrWhiteSpace(name)) { Console.WriteLine("Wrong model name!"); goto getName; }
            Models.Entities.Model model = new(name, id);

            db.Models.Add(model);
        }

        static public void UpdateModel()
        {
            int brandId = Extension.GetIdFromList(db, db.Brands);
            if (ConfirmAction("update", "model") == true)
            {
                var rows = db.Models.Where(m => m.BrandId == brandId);

                int modelId = Extension.GetIdFromList(db, rows);
                Model model = db.Models.FirstOrDefault(m => m.Id == modelId)!;
                if (model != null)
                {
                    model.Name = Extension.ReadString("Enter new name of the model: ");
                    model.BrandId = Extension.GetIdFromList(db, db.Brands);
                    model.LastModifiedAt = DateTime.Now;
                    model.LastModifiedBy = 1;

                    db.Models.Update(model);
                }
                changesSaved = false;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("ACTION WAS CANCELLED!");
                Console.ForegroundColor = backupColor;
                Thread.Sleep(2000);
            }
        }

        static public void DeleteModel()
        {
            int brandId = Extension.GetIdFromList(db, db.Brands);
            if (ConfirmAction("delete", "model") == true)
            {
                var rows = db.Models.Where(m => m.BrandId == brandId);

                int modelId = Extension.GetIdFromList(db, rows);
                Model model = db.Models.FirstOrDefault(m => m.Id == modelId)!;
                model.DeletedAt = DateTime.Now;
                model.DeletedBy = 1;
                db.Models.Update(model);
                changesSaved = false;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("ACTION WAS CANCELLED!");
                Console.ForegroundColor = backupColor;
                Thread.Sleep(2000);
            }
        }

        static public void GetAllModels()
        {
            var query = (from m in db.Models
                         join b in db.Brands on m.BrandId equals b.Id
                         where m.DeletedAt == null && b.DeletedAt == null
                         select new { m.Id, m.Name, brandId = b.Id, brandName = b.Name, m.DeletedAt }).ToList();

            Console.WriteLine("===== Models =====");
            foreach (var item in query)
            {
                Console.WriteLine($"{item.Id}. {item.brandName} {item.Name}, brandId: {item.brandId}");
            }
            Console.WriteLine("==================");
        }

        static public void GetModelById()
        {
            var id = Extension.GetIdFromList(db, db.Models);
            Console.Clear();
            Console.WriteLine($"===== Model by id {id} =====");
            var item = db.Models.FirstOrDefault(m => m.Id == id);
            if (item!.DeletedAt == null)
                Console.WriteLine($"Model ID: {item.Id}, Model Name: {item.Name}, Model Brand Id: {item.BrandId}");
            Console.WriteLine("==================");
        }

        //[ ANNOUNCEMENT METHODS ]\\
        static public void AddAnnouncemet()
        {
        getPrice:
            int price = Extension.Read<int>("Enter the price of the car: ");
        getYear:
            int year = Extension.Read<int>("Enter the year of the car: ");
        getMileage:
            int mileage = Extension.Read<int>("Enter the mileage of the car: ");
            if (mileage < 0) { goto getPrice; }
            else if (year < 0) { goto getYear; }
            else if (mileage < 0) { goto getMileage; }

            int brandId = Extension.GetIdFromList(db, db.Brands, "Enter the brand of the car: ");

            var rows = db.Models.Where(m => m.BrandId == brandId);
            int modelId = Extension.GetIdFromList(db, rows, "Enter the model of the car: ");

            var fuelType = Extension.ChooseOption<FuelType>("Choose fuel type of the car");
            var speedbox = Extension.ChooseOption<SpeedBox>("Choose speed box of the car");
            var banType = Extension.ChooseOption<BanType>("Choose ban type of the car");
            var transmitter = Extension.ChooseOption<Transmitter>("Choose transmitter of the car");
            Announcement announcement = new(price, year, mileage, brandId, modelId, fuelType, speedbox, banType, transmitter);

            db.Announcements.Add(announcement);
        }

        static public void UpdateAnnouncemet()
        {
            int id = Extension.GetIdFromList(db, db.Announcements);
            Announcement announcement = db.Announcements.FirstOrDefault(b => b.Id == id)!;
            if (announcement != null)
            {
            getValues:
                announcement.Price = Extension.Read<int>("Enter the price of the car: ");
                announcement.Year = Extension.Read<int>("Enter the year of the car: ");
                announcement.Mileage = Extension.Read<int>("Enter the mileage of the car: ");
                if (announcement.Mileage < 0 || announcement.Year < 0 || announcement.Price < 0)
                    goto getValues;
                announcement.BrandId = Extension.GetIdFromList(db, db.Brands, "Enter the brand of the car: ");

                var rows = db.Models.Where(m => m.BrandId == announcement.BrandId);
                announcement.ModelId = Extension.GetIdFromList(db, rows, "Enter the model of the car: ");

                announcement.FuelType = Extension.ChooseOption<FuelType>("Choose fuel type of the car");
                announcement.SpeedBox = Extension.ChooseOption<SpeedBox>("Choose speed box of the car");
                announcement.BanType = Extension.ChooseOption<BanType>("Choose ban type of the car");
                announcement.Transmitter = Extension.ChooseOption<Transmitter>("Choose transmitter of the car");

                announcement.LastModifiedAt = DateTime.Now;
                announcement.LastModifiedBy = 1;

                if (ConfirmAction("update", "announcement") == true)
                {
                    db.Announcements.Update(announcement);
                    changesSaved = false;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("ACTION WAS CANCELLED!");
                    Console.ForegroundColor = backupColor;
                    Thread.Sleep(2000);
                }
            }
        }

        static public void DeleteAnnouncemet()
        {
            int id = Extension.GetIdFromList(db, db.Announcements);
            if (ConfirmAction("delete", "announcement") == true)
            {
                Announcement announcement = db.Announcements.FirstOrDefault(b => b.Id == id)!;
                if (announcement != null)
                {
                    announcement.DeletedAt = DateTime.Now;
                    announcement.DeletedBy = 1;
                    db.Announcements.Update(announcement);
                    changesSaved = false;

                }
                else
                {
                    Console.WriteLine($"THERE'S NO ANY ANNOUNCEMENT BY ID ${id}");
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("ACTION WAS CANCELLED!");
                Console.ForegroundColor = backupColor;
                Thread.Sleep(2000);
            }
            
        }

        static public void GetAllAnnouncemets()
        {
            var query = (from a in db.Announcements
                         join m in db.Models on a.ModelId equals m.Id
                         join b in db.Brands on a.BrandId equals b.Id
                         where m.DeletedAt == null && b.DeletedAt == null && a.DeletedAt == null
                         select new { a.DeletedAt, a.Id, a.Year, a.ModelId, a.BrandId, a.Mileage, a.FuelType, a.BanType, a.Transmitter, a.SpeedBox, modelName = m.Name, brandId = b.Id, brandName = b.Name }).ToList();

            Console.WriteLine("===== Announcements =====");
            foreach (var item in query)
            {
                    Console.WriteLine($"---- Announcement {item.Id} ----\n" +
                    $"Brand Name: {item.brandName}" +
                    $"\nBrand Id: {item.BrandId}" +
                    $"\nModel Name: {item.modelName}" +
                    $"\nModel Id: {item.ModelId}" +
                    $"\nYear: {item.Year}" +
                    $"\nMileage: {item.Mileage}" +
                    $"\nFuel type: {item.FuelType}" +
                    $"\nSpeed box: {item.SpeedBox}" +
                    $"\nBan type: {item.BanType}" +
                    $"\nTransmitter: {item.Transmitter}\n----------");
            }
            Console.WriteLine("==================");
        }

        static public void GetAnnouncementById()
        {
            var id = Extension.GetIdFromList(db, db.Announcements);
            Console.Clear();
            Console.WriteLine($"===== Announcements by id {id} =====");
            var item = db.Announcements.FirstOrDefault(a => a.Id == id);
            if (item!.DeletedAt == null)
                Console.WriteLine(
                    $"Announcement Id: {item.Id}," +
                    $" Model Price: {item.Price}," +
                    $" Model Year: {item.Year}," +
                    $" Model Meliage: {item.Mileage}," +
                    $" Model Brand Id: {item.BrandId}" +
                    $" Model Model Id: {item.ModelId}," +
                    $" Model Fuel type: {item.FuelType}," +
                    $" Model Ban Type: {item.BanType}," +
                    $" Model Speed Box: {item.SpeedBox}," +
                    $" Model Transmitter: {item.Transmitter},"
                    );
            Console.WriteLine("==================");
        }

        static public void GetAnnouncementByBrand()
        {
            var id = Extension.GetIdFromList(db, db.Brands);

            var query = (from a in db.Announcements
                         join m in db.Models on a.ModelId equals m.Id
                         join b in db.Brands on a.BrandId equals b.Id
                         where m.DeletedAt == null && b.DeletedAt == null && a.DeletedAt == null && a.BrandId == id
                         select new { a.DeletedAt, a.Id, a.Year, a.ModelId, a.BrandId, a.Mileage, a.FuelType, a.BanType, a.Transmitter, a.SpeedBox, modelName = m.Name, brandId = b.Id, brandName = b.Name }).ToList();

            Console.WriteLine("===== Announcements =====");
            foreach (var item in query)
            {
                Console.WriteLine($"---- Announcement {item.Id} ----\n" +
                $"Brand Name: {item.brandName}" +
                $"\nBrand Id: {item.BrandId}" +
                $"\nModel Name: {item.modelName}" +
                $"\nModel Id: {item.ModelId}" +
                $"\nYear: {item.Year}" +
                $"\nMileage: {item.Mileage}" +
                $"\nFuel type: {item.FuelType}" +
                $"\nSpeed box: {item.SpeedBox}" +
                $"\nBan type: {item.BanType}" +
                $"\nTransmitter: {item.Transmitter}\n----------");
            }
            Console.WriteLine("==================");
        }

        //[ OTHER ]\\
        static public bool? ConfirmAction(string action, string category)
        {
            string answ = Extension.ReadString($"Are you sure that you want to {action} {category} (y/n): ");

            return answ == "y" ? true : (answ == "n" ? false : null);
        }
    }
}
