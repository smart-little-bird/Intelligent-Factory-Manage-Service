
using Autofac;
using Intelligent.Factory.Management.API.Applications.Queries;
using Intelligent.Factory.Management.Domain.AggregatesModel.ClientAggregate;
using Intelligent.Factory.Management.Domain.AggregatesModel.ContractAggregate;
using Intelligent.Factory.Management.Domain.AggregatesModel.ProductAggregate;
using Intelligent.Factory.Management.Infrastructure.Repositories;

namespace Intelligent.Factory.Management.API.AutofacModules;

public class ApplicationModule
    : Autofac.Module
{
    private string QueriesConnectionString { get; }

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

        builder.RegisterType<ProductQueries>()
            .As<IProductQueries>()
            .InstancePerLifetimeScope();
        
        builder.RegisterType<ContractQueries>()
            .As<IContractQueries>()
            .InstancePerLifetimeScope();
        
        builder.RegisterType<ProductRepository>()
            .As<IProductRepository>()
            .InstancePerLifetimeScope();
        
        builder.RegisterType<ContractRepository>()
            .As<IContractRepository>()
            .InstancePerLifetimeScope();

    }
}