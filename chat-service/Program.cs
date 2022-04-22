using SignalRChat.Hubs;
using MongoDB.Driver;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders();
builder.Logging.AddConsole();

IConfigurationRoot CONFIG = builder.Configuration.AddJsonFile("appsettings.json").Build();

Console.WriteLine($"{CONFIG.GetConnectionString("MongoDb").ToString()}");



// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddSignalR();
builder.Services.AddSingleton<IMongoClient>(s => new MongoClient(CONFIG.GetConnectionString("MongoDb")));
builder.Services.AddTransient<IMessageService, MessageService>();



WebApplication app = builder.Build();


//app.UseAuthorization();
app.MapControllers();
app.MapHub<ChatHub>("/chat");

app.Run();
