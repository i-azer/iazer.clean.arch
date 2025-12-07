namespace Clean.Architecture.Web.Members;

public class CreateMemberResponse(Guid id,string name)
{
  public Guid Id { get; set; } = id;
  public string Name { get; set; } = name;
}
