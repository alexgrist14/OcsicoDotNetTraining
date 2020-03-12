using System;
using System.Collections.Generic;
using System.Text;
using Kawaii.Domain;
using Kawaii.Domain.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kawaii.DataAccess.Context.Configurations
{
    public class ProfileImageConfiguration : IEntityTypeConfiguration<ProfileImage>
    {
        public void Configure(EntityTypeBuilder<ProfileImage> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.HasOne(x => x.User)
                .WithOne(x => x.ProfileImage)
                .HasForeignKey<User>(x => x.ProfileImageId)
                .OnDelete(DeleteBehavior.SetNull);


            builder.ToTable("ProfileImages");
        }
    }
}
