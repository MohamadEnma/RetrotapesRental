using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Retrotapes.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retrotapes.DAL.Configurations
{
    public class SalesByStoreConfiguration : IEntityTypeConfiguration<SalesByStore>
    {
        public void Configure(EntityTypeBuilder<SalesByStore> builder)
        {
            builder.ToTable("SalesByStores");
            builder.HasNoKey();
            builder.ToView("sales_by_store");
            builder.Property(e => e.TotalSales).HasPrecision(18, 2);
        }
    }
}
