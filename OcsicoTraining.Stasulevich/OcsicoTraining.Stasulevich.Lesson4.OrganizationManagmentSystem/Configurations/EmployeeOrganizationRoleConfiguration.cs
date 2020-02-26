using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OcsicoTraining.Stasulevich.Lesson4.OrganizationManagmentSystem.Configurations
{
    public class EmployeeOrganizationRoleConfiguration : IEntityTypeConfiguration<EmployeeOrganizationRole>
    {
        public void Configure(EntityTypeBuilder<EmployeeOrganizationRole> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.HasOne(x => x.Employee)
                .WithMany(x => x.EmployeeOrganizationRoles)
                .HasForeignKey(x => x.EmployeeId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(x => x.Organization)
                .WithMany(x => x.EmployeeOrganizationRoles)
                .HasForeignKey(x => x.OrganizationId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(x => x.Role)
                .WithMany(x => x.EmployeeOrganizationRoles)
                .HasForeignKey(x => x.RoleId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.ToTable("EmployeeOrganizationRoles");
        }
    }
}
