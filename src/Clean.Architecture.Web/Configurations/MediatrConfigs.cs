using System.Reflection;
using Ardalis.SharedKernel;
using Clean.Architecture.Core.ContactQrCodeAggregate;
using Clean.Architecture.Core.ContributorAggregate;
using Clean.Architecture.Core.MemberAggregate;
using Clean.Architecture.UseCases.Contacts.Create;
using Clean.Architecture.UseCases.Contributors.Create;
using Clean.Architecture.UseCases.Members.Create;

namespace Clean.Architecture.Web.Configurations;

public static class MediatrConfigs
{
  public static IServiceCollection AddMediatrConfigs(this IServiceCollection services)
  {
    var mediatRAssemblies = new[]
      {
        Assembly.GetAssembly(typeof(Contributor)), // Core
        Assembly.GetAssembly(typeof(CreateContributorCommand)), // UseCases
        Assembly.GetAssembly(typeof(Member)), // Core
        Assembly.GetAssembly(typeof(CreateMemberCommand)), // UseCases
        Assembly.GetAssembly(typeof(ContactQrCode)), // Core
        Assembly.GetAssembly(typeof(GenerateContactQrCodeCommand)) // UseCases
      };

    services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(mediatRAssemblies!))
            .AddScoped(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>))
            .AddScoped<IDomainEventDispatcher, MediatRDomainEventDispatcher>();

    return services;
  }
}
