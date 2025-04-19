using System.Reflection;
using Autofac;

namespace Biblioteca.Infrastructure.Cores.Contexts;

public class InfrastructureAutofacModule : Autofac.Module
{
    protected override void Load(ContainerBuilder builder)
    {
        base.Load(builder);

        builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
            .AsImplementedInterfaces()
            .InstancePerLifetimeScope();
    }
}