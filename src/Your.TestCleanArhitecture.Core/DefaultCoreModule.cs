using Autofac;
using Your.TestCleanArhitecture.Core.Interfaces;
using Your.TestCleanArhitecture.Core.Services;

namespace Your.TestCleanArhitecture.Core;

public class DefaultCoreModule : Module
{
  protected override void Load(ContainerBuilder builder)
  {
    builder.RegisterType<ToDoItemSearchService>()
        .As<IToDoItemSearchService>().InstancePerLifetimeScope();

    builder.RegisterType<DeleteContributorService>()
        .As<IDeleteContributorService>().InstancePerLifetimeScope();
  }
}
