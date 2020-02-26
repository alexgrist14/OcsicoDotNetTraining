using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OcsicoTraining.Stasulevich.Lesson4.OrganizationManagmentSystem.Configurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();
            builder.Property(x => x.Name)
                .IsRequired();
            builder.ToTable("Employees");
        }
    }
}
