namespace Clean.Architecture.Core.MemberAggregate;

public class Member(string fullName,
  Gender gender,
  MaritalStatus maritalStatus,
  DateTime dateOfBirth,
  string address) : EntityBase<Guid>, IAggregateRoot
{
  public string FullName { get; private set; } = Guard.Against.NullOrEmpty(fullName, nameof(fullName));
  public DateTime MembershipStartDate { get; private set; } = DateTime.Now;
  public Gender Gender { get; private set; } = gender;
  public MaritalStatus MaritalStatus { get; private set; } = maritalStatus;
  public DateTime DateOfBirth { get; private set; } = Guard.Against.OutOfSQLDateRange(dateOfBirth, nameof(dateOfBirth));
  public List<PhoneNumber> PhoneNumbers { get; private set; } = [];
  public string Address { get; private set; } = Guard.Against.NullOrEmpty(address, nameof(address));
  public bool IsActive { get; private set; } = true;
}

public class PhoneNumber(string FamilyMemberName,
  string number) : ValueObject
{
  public string FamilyMemberName { get; private set; } = FamilyMemberName;
  public string Number { get; private set; } = number;
  public bool IsActive { get; private set; } = true;
  protected override IEnumerable<object> GetEqualityComponents()
  {
    yield return FamilyMemberName;
    yield return Number;
    yield return IsActive;
  }
}
