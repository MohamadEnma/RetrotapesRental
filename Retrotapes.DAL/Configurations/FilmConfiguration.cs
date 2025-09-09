using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Retrotapes.DAL.Models;
using Retrotapes.DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retrotapes.DAL.Configurations
{
    public class FilmConfiguration : IEntityTypeConfiguration<Film>
    {

        public void Configure(EntityTypeBuilder<Film> builder)
        {
            builder.ToTable("Films");

            // Primary Key
            builder.HasKey(c => c.FilmId);


            // Main Language (required)
            builder.HasOne(f => f.Language)
                   .WithMany(l => l.FilmLanguages)
                   .HasForeignKey(f => f.LanguageId)
                   .IsRequired();

            // Original Language (optional)
            builder.HasOne(f => f.OriginalLanguage)
                   .WithMany(l => l.FilmOriginalLanguages)
                   .HasForeignKey(f => f.OriginalLanguageId)
                   .IsRequired(false);

            builder.Property(e => e.ReplacementCost)
                .HasPrecision(10, 2);

            builder.Property(e=> e.RentalRate)
                .HasPrecision(10, 2);

            
        }
    }
}