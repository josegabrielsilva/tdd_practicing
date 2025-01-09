using CriptoBull.Api.Endpoints;
using CriptoBull.IoC;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddIntegrations()
    .AddServices()
    .AddAuthentication(builder.Configuration)
    .AddAuthorization(builder.Configuration);

var app = builder.Build();

app.UseHttpsRedirection();

app.MapWalletEndpoints();

app.MapCurrencyEndpoints();

app.Run();