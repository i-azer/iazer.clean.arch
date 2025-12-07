using Clean.Architecture.Core.MemberAggregate;

namespace Clean.Architecture.Web.Members;

public class CreateMemberRequest
{
  public const string Route = "/Members";
  public string? Name { get; set; }
  public Gender? Gender { get; set; } = Gender.NotSet;
  public MaritalStatus? MaritalStatus { get; set; } = MaritalStatus.NotSet;
  public DateTime Dob { get; set; }
  public string? Address { get; set; }
}
