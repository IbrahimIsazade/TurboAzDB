using TurboAzDB.Models.DataContexts;
using TurboAzDB.Extensions;
using TurboAzDB.Models.Stable;

namespace TurboAzDB
{
    internal class Program
    {
        static TurboAzDbContext db = new TurboAzDbContext();
        static void Main()
        {
            MenuOption menuOption = Extension.ChooseOption<MenuOption>("Choose from list: ", "Please choose option from list below");

            switch (menuOption)
            {
                //[ BRAND ]\\
                case MenuOption.AddBrand:
                    break;
                case MenuOption.DeleteBrand:
                    break;
                case MenuOption.EditBrand:
                    break;
                case MenuOption.GetAllBrands:
                    break;

                //[ MODEL ]\\
                case MenuOption.AddModel:
                    break;
                case MenuOption.DeleteModel:
                    break;
                case MenuOption.EditModel:
                    break;
                case MenuOption.GetAllModels:
                    break;
                case MenuOption.GetModelById:
                    break;

                //[ ANNOUNCEMENT ]\\
                case MenuOption.AddAnnouncement:
                    break;
                case MenuOption.DeleteAnnouncement:
                    break;
                case MenuOption.EditAnnouncement:
                    break;
                case MenuOption.GetAllAnnouncements:
                    break;
                case MenuOption.GetAnnouncementById:
                    break;
                default:
                    break;
            }

        }
    }
}
