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
    public class FilmTextConfiguration : IEntityTypeConfiguration<FilmText>
    {
        public void Configure(EntityTypeBuilder<FilmText> builder)
        {
            builder.ToTable("FilmTexts");

            builder.HasKey(e => e.FilmId);
        }
    }
}
