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
    public class FilmCategoryconfiguration : IEntityTypeConfiguration<FilmCategory>
    {
        public void Configure(EntityTypeBuilder<FilmCategory> builder)
        {
            builder.ToTable("FilmCategories");

            builder.HasKey(e => new { e.FilmId, e.CategoryId });
            builder.HasOne(e => e.Category)
                .WithMany(c => c.FilmCategories);
        }
    }
}
