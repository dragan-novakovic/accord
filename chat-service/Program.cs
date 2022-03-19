using SignalRChat.Hubs;
using MongoDB.Driver;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

IConfiguration CONFIG = builder.Configuration;

System.Diagnostics.Debug.WriteLine($"{CONFIG}");
System.Diagnostics.Debug.WriteLine("HIIJIFJEIJFIEJIEJEIJFIEFJIJFI");



// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddSignalR();
builder.Services.AddSingleton<IMongoClient>(s => new MongoClient(CONFIG.GetConnectionString("MongoDb")));



WebApplication app = builder.Build();


//app.UseAuthorization();
app.MapControllers();
app.MapHub<ChatHub>("/chat");

app.Run();
