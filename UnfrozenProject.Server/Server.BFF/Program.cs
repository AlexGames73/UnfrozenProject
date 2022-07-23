using System.Net;
using Answers;
using Server.BFF;
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
        foreach (var gameSession in server.Sessions)
        {
            if (gameSession.UserId.HasValue)
            {
                gameSession.Send(new SendMessageAns());
            }
        }
    })
    .AddPipeline(builder =>
    {
        builder.UseEncryption();
    })
    .BuildServer();

server.IoCService.GetInstance<IDatabaseSettingsRegistration>()
    .RegisterConnectionString("Host=localhost;Port=5432;Database=unfrozen-project;User id=postgres;Password=postgres;");

await server.RunAsync();
