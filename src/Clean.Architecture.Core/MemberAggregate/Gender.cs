namespace Clean.Architecture.Core.MemberAggregate;

public class Gender(string name, int value) : SmartEnum<Gender>(name, value)
{
  public static readonly Gender NotSet = new(nameof(NotSet), 0);
  public static readonly Gender Male = new(nameof(Male), 1);
  public static readonly Gender Female = new(nameof(Female), 2);
}
