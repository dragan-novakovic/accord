using SignalRChat.Hubs;
using MongoDB.Driver;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders();
builder.Logging.AddConsole();

IConfigurationRoot CONFIG = builder.Configuration.AddJsonFile("appsettings.json").Build();




// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddSignalR();
builder.Services.AddSingleton<IMongoClient>(s =>
{
    try
    {
        IMongoClient _client = new MongoClient(CONFIG.GetConnectionString("MongoDb"));
        return _client;
    }
    catch (System.Exception e)
    {
        Console.WriteLine("ERRRR", e.ToString());
        throw;
    }

});
builder.Services.AddSingleton<IMessageService, MessageService>();



WebApplication app = builder.Build();


//app.UseAuthorization();
app.MapControllers();
app.MapHub<ChatHub>("/chat");

app.Run();
