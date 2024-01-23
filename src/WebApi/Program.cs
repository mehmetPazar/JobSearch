using Autofac.Extensions.DependencyInjection;
using Persistence;
using Application;
using Autofac;
using Persistence.Middleware;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using HealthChecks.UI.Client;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.Services.AddControllers();
builder.Services.AddApiVersioning(_ =>
{
    _.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1, 0);
    _.AssumeDefaultVersionWhenUnspecified = true;
    _.ReportApiVersions = true;
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

// builder.Services.AddHealthChecks()
//     .AddNpgSql(
//         connectionString: builder.Configuration.GetConnectionString("KariyerNetDbConnection"),
//         healthQuery: "SELECT 1;",
//         name: "kariyernet",
//         failureStatus: HealthStatus.Degraded,
//         timeout: TimeSpan.FromSeconds(30),
//         tags: new[] { "db", "sql", "npgServer", });
// builder.Services.AddHealthChecksUI().AddPostgreSqlStorage(builder.Configuration.GetConnectionString("KariyerNetDbConnection"));

builder.Host.ConfigureContainer<ContainerBuilder>(builder =>
{
    builder.RegisterModule(new PersistenceModule());
    builder.RegisterModule(new ApplicationModule());
});

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ErrorHandlingMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

// app.UseHealthChecks("/healthchecks", new HealthCheckOptions
// {
//     Predicate = registration => true,
//     ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
// });
// app.UseHealthChecksUI();

app.MapControllers();

app.Run();
