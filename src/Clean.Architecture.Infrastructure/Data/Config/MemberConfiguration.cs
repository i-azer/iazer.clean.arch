using Clean.Architecture.Core.MemberAggregate;

namespace Clean.Architecture.Infrastructure.Data.Config;

public class MemberConfiguration : IEntityTypeConfiguration<Member>
{
  public void Configure(EntityTypeBuilder<Member> builder)
  {
    builder.Property(p => p.FullName)
    .HasMaxLength(DataSchemaConstants.DEFAULT_NAME_LENGTH)
    .IsRequired();

    builder.Property(p => p.Address)
    .HasMaxLength(DataSchemaConstants.MemberAggregate.DEFAULT_ADDRESS_LENGTH)
    .IsRequired();

    builder.Property(p => p.DateOfBirth)
    .IsRequired();
    builder.Property(p => p.MembershipStartDate)
    .IsRequired();

    builder.OwnsMany(builder => builder.PhoneNumbers);

    builder.Property(x => x.Gender)
      .HasConversion(
          x => x.Value,
          x => Gender.FromValue(x));

    builder.Property(x => x.MaritalStatus)
      .HasConversion(
          x => x.Value,
          x => MaritalStatus.FromValue(x));
  }
}
