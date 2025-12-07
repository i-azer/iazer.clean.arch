namespace Clean.Architecture.Web.Contacts;

public class CreateContactRequest
{
  public const string Route = "/Contacts";
  public string? Name { get; set; }
  public string? PhoneNumber { get; set; }
}
