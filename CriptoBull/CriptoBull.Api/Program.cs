using CriptoBull.Api;
using CriptoBull.Api.Endpoints;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddIntegrations()
    .AddServices();

var app = builder.Build();

app.UseHttpsRedirection();

app.MapWalletEndpoints();

app.MapCurrencyEndpoints();

app.Run();