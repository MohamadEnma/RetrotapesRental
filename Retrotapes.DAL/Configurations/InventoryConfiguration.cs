using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Retrotapes.DAL.Models;

namespace Retrotapes.DAL.Configurations
{
    public class InventoryConfiguration : IEntityTypeConfiguration<Inventory>
    {
        public void Configure(EntityTypeBuilder<Inventory> builder)
        {
            builder.ToTable("Inventories");

            builder.HasKey(i => i.InventoryId);

            
            builder.HasOne(i => i.Film)
                   .WithMany(f => f.Inventories) 
                   .HasForeignKey(i => i.FilmId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(i => i.Store)
                   .WithMany(s => s.Inventories)
                   .HasForeignKey(i => i.StoreId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}