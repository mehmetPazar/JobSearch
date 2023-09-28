using Application.Features.Employer.Commands.CreateEmployer;
using Application.Features.Employer.Commands.UpdateEmployer;
using Application.Features.Employer.Queries.GetAllEmployer;
using Application.Features.Employer.Queries.GetEmployerById;
using Application.Features.ForbiddenWord.Commands.CreateForbiddenWord;
using Application.Features.ForbiddenWord.Commands.UpdateForbiddenWord;
using Application.Features.ForbiddenWord.Queries.GetAllForbiddenWord;
using Application.Features.ForbiddenWord.Queries.GetForbiddenWordById;
using Application.Features.JobPosting.Commands.CreateJobPosting;
using Application.Features.JobPosting.Commands.UpdateJobPosting;
using Application.Features.JobPosting.Queries.GetAllJobPosting;
using Application.Features.JobPosting.Queries.GetJobPostingById;
using System.Reflection;
using Application.Common;
using Autofac;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Application;

public class ApplicationModulen : Autofac.Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterAssemblyTypes(typeof(IMediator).GetTypeInfo().Assembly)
                .AsImplementedInterfaces();

        builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
           .Where(t => typeof(Profile).IsAssignableFrom(t))
           .As<Profile>();

        builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
           .Where(t => t.IsClosedTypeOf(typeof(IValidator<>)))
           .AsImplementedInterfaces();

        builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
        .AsClosedTypesOf(typeof(IRequestHandler<,>));

        builder.Register(context => new MapperConfiguration(cfg =>
        {
            cfg.AddProfile(new CreateEmployerMapper());
            cfg.AddProfile(new UpdateEmployerMapper());
            cfg.AddProfile(new GetAllEmployerMapper());
            cfg.AddProfile(new GetEmployerByIdMapper());
            cfg.AddProfile(new CreateForbiddenWordMapper());
            cfg.AddProfile(new UpdateForbiddenWordMapper());
            cfg.AddProfile(new GetAllForbiddenWordMapper());
            cfg.AddProfile(new GetForbiddenWordByIdMapper());
            cfg.AddProfile(new CreateJobPostingMapper());
            cfg.AddProfile(new UpdateJobPostingMapper());
            cfg.AddProfile(new GetAllJobPostingMapper());
            cfg.AddProfile(new GetJobPostingByIdMapper());
        }).CreateMapper()).As<IMapper>();

        builder.RegisterGeneric(typeof(ValidatorBehavior<,>)).As(typeof(IPipelineBehavior<,>));
    }
}