using SignalRChat.Hubs;
using MongoDB.Driver;
using Google.Cloud.Firestore;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders();
builder.Logging.AddConsole();

IConfigurationRoot CONFIG = builder.Configuration.AddJsonFile("appsettings.json").Build();

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
    case "Firebase":
        {
            builder.Services.AddSingleton(s =>
                {

                    try
                    {
                        var firestore = new FirestoreDbBuilder
                        {
                            ProjectId = CONFIG.GetConnectionString("Firebase"),
                            EmulatorDetection = Google.Api.Gax.EmulatorDetection.EmulatorOrProduction
                        }
    .Build();
                        return firestore;
                    }
                    catch (System.Exception e)
                    {
                        Console.WriteLine($"ERRRR, {e}");
                        throw;
                    }

                }
                        );

            Console.WriteLine("To-do");
            break;
        };
    default:
        Console.WriteLine("No DB connection provided!");
        break;

}
// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddSignalR(hubOptions => { hubOptions.HandshakeTimeout = TimeSpan.FromSeconds(15); hubOptions.KeepAliveInterval = TimeSpan.FromSeconds(15); hubOptions.EnableDetailedErrors = true; });
builder.Services.AddMemoryCache();
builder.Services.AddScoped<IMessageService, MessageService>(sp => new MessageService(sp.GetService<IMongoClient>()));


WebApplication app = builder.Build();


//app.UseAuthorization();
app.MapControllers();
app.MapHub<ChatHub>("/chat");

app.Run();
