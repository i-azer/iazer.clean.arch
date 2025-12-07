using Clean.Architecture.UseCases.Contacts.Create;

namespace Clean.Architecture.Web.Contacts;

public class Create(IMediator _mediator)
  : Endpoint<CreateContactRequest, CreateContactResponse>
{

  public override void Configure()
  {
    Post(CreateContactRequest.Route);
    AllowAnonymous();
    Summary(s =>
    {
      s.Summary = "Generate a QR code for a contact.";
      s.Description = "Takes a name and phone number, generates a QR code, saves it, and returns the image embedded in the response.";
      s.ExampleRequest = new CreateContactRequest
      {
        Name = "Ibrahim",
        PhoneNumber = "0501234567"
      };
    });
  }

  public override async Task HandleAsync(
    CreateContactRequest request,
    CancellationToken cancellationToken)
  {
    var result = await _mediator.Send(
      new GenerateContactQrCodeCommand(
        request.Name!,
        request.PhoneNumber!),
      cancellationToken);

    if (result.IsSuccess)
    {
      var qrBytes = result.Value;
      var qrBase64 = Convert.ToBase64String(qrBytes);
      var qrDataUri = $"data:image/png;base64,{qrBase64}";

      Response = new CreateContactResponse(
        request.Name!,
        request.PhoneNumber!,
        qrDataUri
      );
      return;
    }

    // TODO: Handle failure cases
    AddError("Failed to generate QR code.");
  }
}
