using Autofac;
using Autofac.Extensions.DependencyInjection;
using Biblioteca.Application.Cors.Context;
using Biblioteca.Domain.Repositories;
using Biblioteca.Infrastructure.Cores.Contexts;
using Biblioteca.Infrastructure.Persistences;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

//add Application
builder.Services.AddApplicationServices();

//Add Infrastructure
builder.Services.AddInfrastructureServices(builder.Configuration);

//Autofac
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory())
    .ConfigureContainer<ContainerBuilder>(options =>
    {
        options.RegisterModule(new InfrastructureAutofacModule());
        options.RegisterModule(new ApplicationAutofacModule());
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage(); // 👈 AÑADE ESTA LÍNEA
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}