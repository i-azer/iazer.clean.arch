using Clean.Architecture.Core.ContactQrCodeAggregate;

namespace Clean.Architecture.Infrastructure.Data.Config;

internal class ContactQrCodeConfiguration : IEntityTypeConfiguration<ContactQrCode>
{
  public void Configure(EntityTypeBuilder<ContactQrCode> builder)
  {

    builder.HasKey(e => e.Id);
    builder.Property(e => e.Name).IsRequired().HasMaxLength(100);
    builder.Property(e => e.PhoneNumber).IsRequired().HasMaxLength(20);
    builder.Property(e => e.QrImage).IsRequired();
  }
}
