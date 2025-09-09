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
    public class SalesByFilmCategoryConfiguration : IEntityTypeConfiguration<SalesByFilmCategory>
    {
        public void Configure(EntityTypeBuilder<SalesByFilmCategory> builder)
        {
            builder.ToTable("SalesByFilmCategories");
            builder.HasNoKey();
            builder.ToView("sales_by_film_category");
            builder.Property(e => e.TotalSales).HasPrecision(18, 2);
        }
    }
}
