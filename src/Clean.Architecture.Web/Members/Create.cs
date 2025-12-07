using Clean.Architecture.Core.MemberAggregate;
using Clean.Architecture.UseCases.Members.Create;

namespace Clean.Architecture.Web.Members;

public class Create(IMediator _mediator)
  : Endpoint<CreateMemberRequest, CreateMemberResponse>
{
  public override void Configure()
  {
    Post(CreateMemberRequest.Route);
    AllowAnonymous();
    Summary(s =>
    {
      // XML Docs are used by default but are overridden by these properties:
      //s.Summary = "Create a new Contributor.";
      //s.Description = "Create a new Contributor. A valid name is required.";
      s.ExampleRequest = new CreateMemberRequest { Name = "Member Name" };
    });
  }

  public override async Task HandleAsync(
    CreateMemberRequest request,
    CancellationToken cancellationToken)
  {
    var gender = request.Gender ?? Gender.NotSet;
    var maritalStatus = request.MaritalStatus ?? MaritalStatus.NotSet;
    var address = request.Address ?? string.Empty;

    var result = await _mediator.Send(
      new CreateMemberCommand(
        request.Name!,
        gender,
        maritalStatus,
        request.Dob,
        address),
      cancellationToken);

    if (result.IsSuccess)
    {
      Response = new CreateMemberResponse(result.Value, request.Name!);
      return;
    }
    // TODO: Handle other cases as necessary
  }
}
