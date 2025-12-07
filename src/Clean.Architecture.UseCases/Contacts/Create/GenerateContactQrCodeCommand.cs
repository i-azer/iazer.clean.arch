namespace Clean.Architecture.UseCases.Contacts.Create;

public record GenerateContactQrCodeCommand(string Name, string PhoneNumber)
      : Ardalis.SharedKernel.ICommand<Result<byte[]>>;

