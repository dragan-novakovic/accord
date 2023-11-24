public static class DataSeeder
{
    public static void Seed(this IHost host)
    {
        using var scope = host.Services.CreateScope();
        using var context = scope.ServiceProvider.GetRequiredService<RoomDataContext>();
        context.Database.EnsureCreated();
        AddRooms(context);

    }


    public static void AddRooms(RoomDataContext context)
    {
        var room = context.Rooms.FirstOrDefault();
        if (room != null) return;


        context.Rooms.Add(new RoomModel
        {
            Id = 1,
            RoomName = "Probna Soba 1",

        });
        context.Rooms.Add(new RoomModel
        {
            Id = 2,
            RoomName = "Probna Soba 2",

        });
        context.Rooms.Add(new RoomModel
        {
            Id = 3,
            RoomName = "Probna Soba 3",

        });
        context.SaveChanges();
    }


}