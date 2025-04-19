using System.Reflection;
using Autofac;

namespace Biblioteca.Application.Cors.Context;

public class ApplicationAutofacModule : Autofac.Module
{
    protected override void Load(ContainerBuilder builder)
    {
        base.Load(builder);
        builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
            .AsImplementedInterfaces()
            .InstancePerLifetimeScope();
    }
}