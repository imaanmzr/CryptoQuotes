using Services.CryptoQuotes.Application;
using Services.CryptoQuotes.Infrastructure;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddApplication([Services.CryptoQuotes.Application.AssemblyReference.Assembly]);
builder.Services.AddCryptoQuotesService(builder.Configuration);

builder.Configuration
    .AddJsonFile("appsettings.Development.json", optional: false, reloadOnChange: true)
    .AddUserSecrets<Program>()
    .AddEnvironmentVariables();

WebApplication app = builder.Build();


if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

RegisterInfrastructureServices.MapEndpoints(app);

app.UseHttpsRedirection();

app.Run();
