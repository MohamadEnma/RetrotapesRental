using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Retrotapes.DAL.Models;

namespace Retrotapes.DAL.Configurations
{
    public class StaffConfiguration : IEntityTypeConfiguration<Staff>
    {
        public void Configure(EntityTypeBuilder<Staff> builder)
        {
            builder.ToTable("Staffs");

            builder.HasKey(s => s.StaffId);

            // Prevent cascade delete from Address -> Staff
            builder.HasOne(s => s.Address)
                   .WithMany(a => a.Staff)
                   .HasForeignKey(s => s.AddressId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Prevent cascade delete from Store -> Staff (if you don't want removing a store to delete staff)
            builder.HasOne(s => s.Store)
                   .WithMany(st => st.Staff)
                   .HasForeignKey(s => s.StoreId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}