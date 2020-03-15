using Kawaii.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kawaii.DataAccess.Context.Configurations
{
    public class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.HasOne(x => x.User)
                .WithMany(x => x.Posts)
                .OnDelete(DeleteBehavior.Restrict);

            builder.ToTable("Posts");
        }
    }
}
