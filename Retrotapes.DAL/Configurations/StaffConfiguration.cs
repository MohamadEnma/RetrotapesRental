using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Retrotapes.DAL.Models; // or your actual namespace

namespace Retrotapes.DAL.Configurations
{
    public class StaffConfiguration : IEntityTypeConfiguration<Staff>
    {
        public void Configure(EntityTypeBuilder<Staff> builder)
        {
            builder.ToTable("staff");

            builder.HasKey(s => s.StaffId);
            builder.Property(s => s.StaffId).HasColumnName("staff_id");
            builder.Property(s => s.AddressId).HasColumnName("address_id");
            builder.Property(s => s.FirstName).HasColumnName("first_name");
            builder.Property(s => s.LastName).HasColumnName("last_name");
            builder.Property(s => s.LastUpdate).HasColumnName("last_update");
            builder.Property(s => s.StoreId).HasColumnName("store_id");
            builder.Property(s => s.Active).HasColumnName("active");

            // Prevent cascade delete from Address -> Staff
            builder.HasOne(s => s.Address)
                   .WithMany(a => a.Staff)
                   .HasForeignKey(s => s.AddressId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Prevent cascade delete from Store -> Staff
            builder.HasOne(s => s.Store)
                   .WithMany(st => st.Staff)
                   .HasForeignKey(s => s.StoreId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Map other properties as needed
        }
    }
}