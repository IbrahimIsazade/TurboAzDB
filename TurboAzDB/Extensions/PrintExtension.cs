using TurboAzDB.Models.Entities;
using TurboAzDB.Models.Stable;

namespace TurboAzDB.Extensions
{
    public static partial class Extension
    {
        public static void Print(string message, Paint type = Paint.White)
        {
            var backupColor = Console.ForegroundColor;

            switch (type)
            {
                case Paint.Red:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case Paint.Green:
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case Paint.Blue:
                    Console.ForegroundColor = ConsoleColor.Blue;
                    break;
                case Paint.Yellow:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case Paint.White:
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                default:
                    Console.ForegroundColor = backupColor;
                    break;
            }

            Console.Write(message);
            Console.ForegroundColor = backupColor;
        }

        public static void PrintLine(string message, Paint type = Paint.White)
        {
            Print($"{message}\n", type);
        }

        //public static bool ShowAll(List<Brand> list)
        //{
        //    if (list.Count == 0)
        //    {
        //        return false;
        //    }

        //    PrintLine("================= Brands =================", Paint.Yellow);
        //    foreach (Brand item in list)
        //    {
        //        PrintLine($"{item.Id}. {item.Name}");
        //    }
        //    PrintLine("==========================================", Paint.Yellow);
        //    return true;
        //}


    }
}
