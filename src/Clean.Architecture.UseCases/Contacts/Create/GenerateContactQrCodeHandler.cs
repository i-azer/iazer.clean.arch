using System.Drawing;
using System.Runtime.Versioning;
using Clean.Architecture.Core.ContactQrCodeAggregate;

namespace Clean.Architecture.UseCases.Contacts.Create;

[SupportedOSPlatform("windows")]
public class GenerateContactQrCodeHandler
    : ICommandHandler<GenerateContactQrCodeCommand, Result<byte[]>>
{
  private readonly IRepository<ContactQrCode> _repository;

  public GenerateContactQrCodeHandler(IRepository<ContactQrCode> repository)
  {
    _repository = repository;
  }

  public async Task<Result<byte[]>> Handle(GenerateContactQrCodeCommand request, CancellationToken cancellationToken)
  {
    // Generate QR code
    //var payload = $"{request.Name}|{request.PhoneNumber}";
    //  var payload =
    //$"BEGIN:VCARD\n" +
    //$"VERSION:3.0\n" +
    //$"FN:{request.Name}\n" +
    //$"TEL:{request.PhoneNumber}\n" +
    //$"END:VCARD";

    var payload = $"MECARD:N:{request.Name};TEL:{request.PhoneNumber};;";
    using var qrGenerator = new QRCoder.QRCodeGenerator();
    var qrData = qrGenerator.CreateQrCode(payload, QRCoder.QRCodeGenerator.ECCLevel.Q);
    var qrCode = new QRCoder.QRCode(qrData);

    using var bitmap = qrCode.GetGraphic(20, Color.Black, Color.White, true);
    using var ms = new MemoryStream();
    bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
    var qrBytes = ms.ToArray();

    // Save to DB
    var entity = new ContactQrCode(request.Name, request.PhoneNumber, qrBytes);
    await _repository.AddAsync(entity, cancellationToken);

    return qrBytes;
  }
}

