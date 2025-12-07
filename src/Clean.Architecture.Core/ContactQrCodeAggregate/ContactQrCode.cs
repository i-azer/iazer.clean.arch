namespace Clean.Architecture.Core.ContactQrCodeAggregate;

public class ContactQrCode : EntityBase<Guid>, IAggregateRoot
{
  public string Name { get; private set; }
  public string PhoneNumber { get; private set; }
  public byte[] QrImage { get; private set; }

  public ContactQrCode(string name, string phoneNumber, byte[] qrImage)
  {
    Name = name;
    PhoneNumber = phoneNumber;
    QrImage = qrImage;
  }
}
