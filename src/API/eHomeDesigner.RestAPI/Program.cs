using Microsoft.OpenApi.Models;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using eHomeDesigner.Data.Setup;
using Autofac.Extensions.DependencyInjection;
using Autofac;
using eHomeDesigner.Application.Interfaces.Converters;
using eHomeDesigner.Converters.AutoMapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "eHomeDesigner.RestAPI", Version = "v1" });
});
builder.Services.SetupDbContext(builder.Configuration.GetConnectionString("eHomeDesigner_Db"));

// TODO: Transfer this logic in eHomeDesigner.DI
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(builder => 
{
    builder.RegisterType<Converter>().As<IConverter>();
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (builder.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "eHomeDesigner.RestAPI v1"));
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
