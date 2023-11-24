using SignalRChat.Hubs;
using MongoDB.Driver;
using System.Security.Cryptography.X509Certificates;
// using Microsoft.AspNetCore.Authentication.Certificate;
using Microsoft.AspNetCore.Http.Connections;
using Microsoft.EntityFrameworkCore;


WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders();
builder.Logging.AddConsole();

IConfigurationRoot CONFIG = builder.Configuration.AddJsonFile("appsettings.json").Build();
IConfigurationRoot CONFIG_CERT = builder.Configuration.AddJsonFile("certificate.json").Build();

// var certificateSettings = CONFIG_CERT.GetSection("certificateSettings");
// string certificateFileName = certificateSettings.GetValue<string>("filename");
// string certificatePassword = certificateSettings.GetValue<string>("password");

// var cerificate = new X509Certificate2(certificateFileName, certificatePassword);

Console.WriteLine("Using" + CONFIG.GetValue<string>("useDB"));
switch (CONFIG.GetValue<string>("useDB"))

{
    case "MongoDb":
        {
            builder.Services.AddSingleton<IMongoClient>(s =>
            {
                try
                {
                    return new MongoClient(CONFIG.GetConnectionString("MongoDb"));
                }
                catch (System.Exception e)
                {
                    Console.WriteLine($"ERRRR, {e}");
                    throw;
                }

            });
            break;
        }
    default:
        Console.WriteLine("No DB connection provided!");
        break;

}
// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddSignalR(hubOptions => { hubOptions.HandshakeTimeout = TimeSpan.FromSeconds(15); hubOptions.KeepAliveInterval = TimeSpan.FromSeconds(15); hubOptions.EnableDetailedErrors = true; });
builder.Services.AddMemoryCache();
builder.Services.AddDbContext<GenericDbContext>(o => o.UseNpgsql(CONFIG.GetConnectionString("Postgres")));
builder.Services.AddScoped<IMessageService, MessageService>(sp => new MessageService(sp.GetService<IMongoClient>()));
//builder.Services.AddAuthentication(CertificateAuthenticationDefaults.AuthenticationScheme).AddCertificate();


WebApplication app = builder.Build();

app.UseAuthentication();
app.MapControllers();
app.MapHub<ChatHub>("/chat", options => { options.Transports = HttpTransportType.WebSockets; });
app.Seed();
app.Run();
