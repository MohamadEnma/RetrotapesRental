using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Retrotapes.DAL.Models;

namespace Retrotapes.DAL.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customers");

            builder.HasKey(c => c.CustomerId);

            // Prevent cascade delete from Store -> Customers
            builder.HasOne(c => c.Store)
                   .WithMany(s => s.Customers)
                   .HasForeignKey(c => c.StoreId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Prevent cascade delete from Address -> Customers
            builder.HasOne(c => c.Address)
                   .WithMany(a => a.Customers)
                   .HasForeignKey(c => c.AddressId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}