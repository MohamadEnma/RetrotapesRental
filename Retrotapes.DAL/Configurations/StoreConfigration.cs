using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Retrotapes.DAL.Models;

namespace Retrotapes.DAL.Configurations
{
    public class StoreConfiguration : IEntityTypeConfiguration<Store>
    {
        public void Configure(EntityTypeBuilder<Store> builder)
        {
            builder.ToTable("Stores");

            builder.HasKey(s => s.StoreId);

            // ManagerStaff should not cascade delete (prevents multiple cascade paths)
            builder.HasOne(s => s.ManagerStaff)
                   .WithMany()
                   .HasForeignKey(s => s.ManagerStaffId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Address: do not cascade deleting an Address -> Store
            // (deleting an address should be explicit and not remove Stores)
            builder.HasOne(s => s.Address)
                   .WithMany(a => a.Stores)
                   .HasForeignKey(s => s.AddressId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}