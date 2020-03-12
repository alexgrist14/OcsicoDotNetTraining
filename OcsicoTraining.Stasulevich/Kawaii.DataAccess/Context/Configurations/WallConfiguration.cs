using System;
using System.Collections.Generic;
using System.Text;
using Kawaii.Domain;
using Kawaii.Domain.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kawaii.DataAccess.Context.Configurations
{
    public class WallConfiguration : IEntityTypeConfiguration<Wall>
    {
        public void Configure(EntityTypeBuilder<Wall> builder)
        {

            builder.HasOne(x => x.User)
                .WithOne(x => x.Wall)
                .HasForeignKey<User>(x => x.WallId);

            builder.HasMany(x => x.Posts)
                .WithOne(x => x.Wall)
                .HasForeignKey(x => x.WallId);

            builder.ToTable("Walls");
        }
    }
}
