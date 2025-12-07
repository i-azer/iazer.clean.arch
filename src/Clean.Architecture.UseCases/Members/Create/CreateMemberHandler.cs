using Clean.Architecture.Core.MemberAggregate;

namespace Clean.Architecture.UseCases.Members.Create;

public class CreateMemberHandler(IRepository<Member> _repository)
  : ICommandHandler<CreateMemberCommand, Result<Guid>>
{
  public async Task<Result<Guid>> Handle(CreateMemberCommand request,
  CancellationToken cancellationToken)
  {
    var newMember = new Member(request.fullName,
      request.gender,
      request.maritalStatus,
      request.dob,
      request.address);
    var createdItem = await _repository.AddAsync(newMember, cancellationToken);

    return createdItem.Id;
  }
}
