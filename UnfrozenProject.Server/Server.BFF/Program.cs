using System.Net;
using Server.BFF;
using Server.BFF.Factories;
using Server.Database;
using TriaStudios.NetworkLib.Core.Abstract;
using TriaStudios.NetworkLib.Core.Middlewares;

using var server = NetworkSocket<GameSession>.Builder()
    .AddLogger((layer, s) => Console.WriteLine($"[{layer}] {s}"))
    .BindAddress(IPEndPoint.Parse("127.0.0.1:1234"))
    .AddConnectHandler(session => Console.WriteLine($"{session.FromInfo.EndPoint} Connected!"))
    .AddDisconnectHandler((session, server) =>
    {
        session.UserId = null;
        Console.WriteLine($"{session.FromInfo.EndPoint} Disconnected!");

        var gameSessions = server.Sessions.Where(x => x.UserId.HasValue).ToArray();
        server.IoCService.GetInstance<UpdateAppFactory>().Send(gameSessions);
    })
    .AddPipeline(builder =>
    {
        builder.UseEncryption();
    })
    .BuildServer();

server.IoCService.GetInstance<IDatabaseSettingsRegistration>()
    .RegisterSqlLiteConnectionString("Data Source=UnfrozenDatabase.sqlite;");
    // .RegisterNpgsqlConnectionString("Host=localhost;Port=5432;Database=unfrozen-project;User id=postgres;Password=postgres;");

await server.RunAsync();
