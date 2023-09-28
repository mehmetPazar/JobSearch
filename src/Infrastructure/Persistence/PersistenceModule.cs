using Autofac;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using Persistence.Repositories;
using Persistence.Repositories.Interfaces;
using Microsoft.Extensions.Configuration;

namespace Persistence;

public class PersistenceModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.Register(ctx =>
        {
            var configuration = ctx.Resolve<IConfiguration>();
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseNpgsql(configuration.GetConnectionString("KariyerNetDbConnection"))
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors()
                .Options;

            return new ApplicationDbContext(options);
        }).AsSelf().InstancePerLifetimeScope();

        builder.RegisterGeneric(typeof(GenericRepository<>)).As(typeof(IGenericRepository<>)).InstancePerLifetimeScope();
        builder.RegisterType<EmployerRepository>().As<IEmployerRepository>().InstancePerLifetimeScope();
        builder.RegisterType<JobPostingRepository>().As<IJobPostingRepository>().InstancePerLifetimeScope();
        builder.RegisterType<ForbiddenWordRepository>().As<IForbiddenWordRepository>().InstancePerLifetimeScope();
    }
}