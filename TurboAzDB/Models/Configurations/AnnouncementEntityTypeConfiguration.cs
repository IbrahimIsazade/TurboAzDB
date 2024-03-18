using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TurboAzDB.Models.Entities;
using TurboAzDB.Models.StableModels;

namespace TurboAzDB.Models.Configuration
{
    public class AnnouncementEntityTypeConfiguration : IEntityTypeConfiguration<Announcement>
    {
        public void Configure(EntityTypeBuilder<Announcement> builder)
        {
            builder.Property(m => m.Id).HasColumnType("int").IsRequired();
            builder.Property(m => m.Price).HasColumnType("int").IsRequired();
            builder.Property(m => m.Year).HasColumnType("int").IsRequired();
            builder.Property(m => m.Mileage).HasColumnType("decimal").IsRequired();
            builder.Property(m => m.BrandId).HasColumnType("int").IsRequired();
            builder.Property(m => m.ModelId).HasColumnType("int").IsRequired();
            builder.Property(m => m.FuelType).HasColumnType("int").IsRequired();
            builder.Property(m => m.SpeedBox).HasColumnType("int").IsRequired();
            builder.Property(m => m.BanType).HasColumnType("int").IsRequired();
            builder.Property(m => m.Transmitter).HasColumnType("int").IsRequired();

            // Common
            builder.Property(m => m.CreatedBy).HasColumnType("int").IsRequired();
            builder.Property(m => m.CreatedAt).HasColumnType("datetime").IsRequired();
            builder.Property(m => m.LastModifiedBy).HasColumnType("int");
            builder.Property(m => m.LastModifiedAt).HasColumnType("datetime");
            builder.Property(m => m.DeletedBy).HasColumnType("int");
            builder.Property(m => m.DeletedAt).HasColumnType("datetime");

            builder.HasKey(x => x.Id);
            builder.ToTable("Announcements");

        }
    }
}
