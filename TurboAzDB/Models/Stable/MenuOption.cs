namespace TurboAzDB.Models.Stable
{
    public enum MenuOption : byte
    {
        //Brand
        AddBrand = 1,
        DeleteBrand,
        UpdateBrand,
        GetAllBrands,
        GetBrandById,

        //Model
        AddModel,
        DeleteModel,
        UpdateModel,
        GetAllModels,
        GetModelById,

        // Announcement
        AddAnnouncement,
        DeleteAnnouncement,
        UpdateAnnouncement,
        GetAllAnnouncements,
        GetAnnouncementById,

        // Save Changes
        SaveChanges
    }
}
