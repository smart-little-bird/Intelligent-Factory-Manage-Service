using System.Reflection;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Intelligent.Factory.Management.API.AutofacModules;
using Intelligent.Factory.Management.Infrastructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// DI dbContext
builder.Services.AddDbContext<IntelligentFactoryManagementContext>(options =>
    {
        options.UseSqlServer(builder.Configuration.GetConnectionString("db"),
            sqlServerOptionsAction: sqlOptions =>
            {
                sqlOptions.MigrationsAssembly(typeof(Program).GetTypeInfo().Assembly.GetName().Name);
                sqlOptions.EnableRetryOnFailure(maxRetryCount: 15, maxRetryDelay: TimeSpan.FromSeconds(30), errorNumbersToAdd: null);
            });
    },
    ServiceLifetime.Scoped  //Showing explicitly that the DbContext is shared across the HTTP request scope (graph of objects started in the HTTP request)
);

//DI autofac
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

builder.Host.ConfigureContainer<ContainerBuilder>(container =>
{
    container.RegisterModule(new MediatorModule());
    container.RegisterModule(new ApplicationModule(builder.Configuration.GetConnectionString("db")));
});

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

if (!app.Environment.IsDevelopment())
{
    app.UseHttpsRedirection();
}

app.UseCors(policy =>
{
    policy.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod();
});
app.UseAuthorization();

app.MapControllers();

app.Run();