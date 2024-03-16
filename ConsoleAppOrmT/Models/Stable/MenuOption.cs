namespace TurboAzDB.Models.Stable
{
    internal enum MenuOption : byte
    {
        //Brand
        AddBrand = 1,
        DeleteBrand, // Not finished
        EditBrand,
        GetAllBrands,

        //Model
        AddModel,
        DeleteModel,// Not finished
        EditModel,
        GetAllModels,
        GetModelById,

        // Announcement
        AddAnnouncement,
        DeleteAnnouncement,// Not finished
        EditAnnouncement,// Not finished
        GetAllAnnouncements,
        GetAnnouncementById,
    }
}
