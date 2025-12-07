namespace Clean.Architecture.Web.Contacts;

public class CreateContactResponse
{
  public CreateContactResponse(string name, string phoneNumber, string qrCodeBase64)
  {
    Name = name;
    PhoneNumber = phoneNumber;
    QrCodeBase64 = qrCodeBase64;
  }

  public string Name { get; }
  public string PhoneNumber { get; }
  // Base64 string representing the QR code image
  public string QrCodeBase64 { get; }
}
