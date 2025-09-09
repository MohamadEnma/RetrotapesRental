using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Retrotapes.DAL.Models;

namespace Retrotapes.DAL.Configurations
{
    public class CustomerSpendningConfiguration : IEntityTypeConfiguration<CustomerSpendning>
    {
        public void Configure(EntityTypeBuilder<CustomerSpendning> builder)
        {
            builder.ToTable("CustomerSpendning");

            builder.HasNoKey(); 

          
            builder.Property(c => c.Billigast).HasPrecision(10, 2);
            builder.Property(c => c.Dyrast).HasPrecision(10, 2);
            builder.Property(c => c.Medelkostnad).HasPrecision(10, 2);
            builder.Property(c => c.Totalbetalning).HasPrecision(10, 2);

            
        }
    }
}