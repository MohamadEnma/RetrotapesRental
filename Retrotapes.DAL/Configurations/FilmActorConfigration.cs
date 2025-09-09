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
    public class FilmActorConfigration : IEntityTypeConfiguration<FilmActor>
    {
        public void Configure(EntityTypeBuilder<FilmActor> builder)
        {
            builder.ToTable("FilmActors");

            //Primary Key
            builder.HasKey(e => new { e.ActorId, e.FilmId });

            //Relations
            builder.HasOne(e => e.Actor)
                  .WithMany(a => a.FilmActors) 
                  .HasForeignKey(e => e.ActorId)
                  .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(e => e.Film)
                  .WithMany(f => f.FilmActors) 
                  .HasForeignKey(e => e.FilmId)
                  .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
