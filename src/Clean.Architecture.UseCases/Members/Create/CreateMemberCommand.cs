using Clean.Architecture.Core.MemberAggregate;

namespace Clean.Architecture.UseCases.Members.Create;

public record CreateMemberCommand(string fullName,
  Gender gender,
  MaritalStatus maritalStatus,
  DateTime dob,
  string address)
  : Ardalis.SharedKernel.ICommand<Result<Guid>>;
