namespace Clean.Architecture.Core.MemberAggregate;

public class MaritalStatus(string name, int value) : SmartEnum<MaritalStatus>(name, value)
{
  public static readonly MaritalStatus NotSet = new(nameof(NotSet), 0);
  public static readonly MaritalStatus Single = new(nameof(Single), 1);
  public static readonly MaritalStatus Married = new(nameof(Married), 2);
}
