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
    public class FilmListConfiguration : IEntityTypeConfiguration<FilmList>
    {
        public void Configure(EntityTypeBuilder<FilmList> builder)
        {
            builder.ToTable("FilmLists");
            builder.HasNoKey();
            builder.ToView("film_list"); 
            builder.Property(e => e.Fid).HasColumnName("FID");
            builder.Property(e => e.Title).HasMaxLength(255);
            builder.Property(e => e.Description);
            builder.Property(e => e.Category).IsRequired().HasMaxLength(25);
            builder.Property(e => e.Price).HasPrecision(4, 2); 
            builder.Property(e => e.Length);
            builder.Property(e => e.Rating).HasMaxLength(10);
            builder.Property(e => e.Actors);

        }
    }
}
