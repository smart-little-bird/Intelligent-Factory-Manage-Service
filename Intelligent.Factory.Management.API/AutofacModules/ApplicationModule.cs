
using Autofac;
using Intelligent.Factory.Management.API.Applications.Queries;
using Intelligent.Factory.Management.Domain.AggregatesModel.ClientAggregate;
using Intelligent.Factory.Management.Infrastructure.Repositories;

namespace Intelligent.Factory.Management.API.AutofacModules;

public class ApplicationModule
    : Autofac.Module
{
    public string QueriesConnectionString { get; }

    public ApplicationModule(string qconstr)
    {
        QueriesConnectionString = qconstr;
    }

    protected override void Load(ContainerBuilder builder)
    {
        builder.Register(c => new ClientQueries(QueriesConnectionString))
            .As<IClientQueries>()
            .InstancePerLifetimeScope();

        builder.RegisterType<ClientRepository>()
            .As<IClientRepository>()
            .InstancePerLifetimeScope();

        // builder.RegisterType<RequestManager>()
        //     .As<IRequestManager>()
        //     .InstancePerLifetimeScope();
        //

        // builder.RegisterAssemblyTypes(typeof(CreateOrderCommandHandler).GetTypeInfo().Assembly)
        //     .AsClosedTypesOf(typeof(IIntegrationEventHandler<>));

    }
}