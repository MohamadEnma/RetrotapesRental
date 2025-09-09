using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Retrotapes.DAL.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Retrotapes.DAL.Configurations
{
    public class ActorConfiguration : IEntityTypeConfiguration<Actor>
    {
        public void Configure(EntityTypeBuilder<Actor> builder)
        {
            builder.ToTable("Actors");


            builder.HasKey(c => c.ActorId);

        }  
    }
}
