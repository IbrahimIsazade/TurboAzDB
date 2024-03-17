using Microsoft.EntityFrameworkCore;
using TurboAzDB.Models.DataContexts;
using TurboAzDB.Models.Entities;
using TurboAzDB.Models.Stable;
namespace TurboAzDB.Extensions
{
    public static partial class Extension
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="caption"></param>
        /// <param name="message">Message is Optional parameter,mean of Red Message</param>
        /// <returns></returns>
        public static T Read<T>(this string caption, string? message = null)
            where T : struct
        {
            if (string.IsNullOrWhiteSpace(message))
                message = "Please check value";

            l1:
            Print(caption);

            try
            {
                return (T)(Convert.ChangeType(Console.ReadLine(), typeof(T)) ?? default)!;
            }
            catch (Exception)
            {
                PrintLine(message, Paint.Red);
                goto l1;
            }
        }

        public static string ReadString(this string caption, string? message = null)
        {
            if (string.IsNullOrWhiteSpace(message))
                message = "Please check value";

            string value;

        l1:
            Print(caption);

            value = Console.ReadLine()!;

            if (string.IsNullOrWhiteSpace(message))
            {
                PrintLine(message, Paint.Red);
                goto l1;
            }

            return value!;
        }

        public static T ChooseOption<T>(this string caption, string? message = null)
            where T : Enum
        {
            if (string.IsNullOrWhiteSpace(message))
                message = "Option must be choose from list";

            Type type = typeof(T);
            Type uType = Enum.GetUnderlyingType(type);

            var backupColor = Console.ForegroundColor;
            Console.WriteLine("============== CHOOSE OPTION =============");
            Console.ForegroundColor = ConsoleColor.Yellow;
            foreach (var item in Enum.GetValues(type))
            {
                var orderNo = Convert.ChangeType(item, uType);

                Console.WriteLine($"{orderNo}. {item}");
            }
            Console.ForegroundColor = backupColor;
            Console.WriteLine("==========================================");

        l1:
            Print(caption);
            if (!Enum.TryParse(type, Console.ReadLine(), true, out object? enumValue) || !Enum.IsDefined(type, enumValue))
            {
                PrintLine(message, Paint.Red);
                goto l1;
            }

            return (T)enumValue;
        }

        public static int GetIdFromList(TurboAzDbContext db,IQueryable<Brand> values, string? caption = null)
        {
            if (string.IsNullOrWhiteSpace(caption))
                caption = "Choose from list";

            var backupColor = Console.ForegroundColor;
            Console.WriteLine("============== CHOOSE BRAND =============");
            Console.ForegroundColor = ConsoleColor.Yellow;
            foreach (var item in values)
            {
                var orderNo = item.Id;

                Console.WriteLine($"{item.Id}. {item.Name}");
            }
            Console.ForegroundColor = backupColor;
            Console.WriteLine("==========================================");

            getId:
            int userSelectId = Read<int>("Enter an Id of a brand: ");

            if (userSelectId < 0 || db.Brands.Any(b => b.Id == userSelectId) == false)
            {
                Console.WriteLine("Wrong Id. Please rewrite");
                goto getId;
            }
            return userSelectId;
        }

        public static int GetIdFromList(TurboAzDbContext db,IQueryable<Model> values, string? caption = null)
        {
            if (string.IsNullOrWhiteSpace(caption))
                caption = "Choose from list";

            var backupColor = Console.ForegroundColor;
            Console.WriteLine("============== CHOOSE MODEL =============");
            Console.ForegroundColor = ConsoleColor.Yellow;
            foreach (var item in values)
            {
                var orderNo = item.Id;

                Console.WriteLine($"{item.Id}. {item.Name}");
            }
            Console.ForegroundColor = backupColor;
            Console.WriteLine("==========================================");

            getId:
            int userSelectId = Read<int>("Enter an Id of a model: ");

            if (userSelectId < 0 || db.Models.Any(m => m.Id == userSelectId) == false)
            {
                Console.WriteLine("Wrong Id. Please rewrite");
                goto getId;
            }
            return userSelectId;
        }

        public static int GetIdFromList(TurboAzDbContext db,IQueryable<Announcement> values, string? caption = null)
        {
            if (string.IsNullOrWhiteSpace(caption))
                caption = "Choose from list";

            var backupColor = Console.ForegroundColor;
            Console.WriteLine("============== CHOOSE ANNOUNCEMENT =============");
            Console.ForegroundColor = ConsoleColor.Yellow;
            foreach (var item in values)
            {
                var orderNo = item.Id;

                Console.WriteLine(item);
            }
            Console.ForegroundColor = backupColor;
            Console.WriteLine("==========================================");

            getId:
            int userSelectId = Read<int>("Enter an Id of a model: ");

            if (userSelectId < 0 || db.Announcements.Any(m => m.Id == userSelectId) == false)
            {
                Console.WriteLine("Wrong Id. Please rewrite");
                goto getId;
            }
            return userSelectId;
        }
    }
}
