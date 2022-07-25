using System.Collections.Generic;
using System.Net;
using System.Threading;
using Structs;
using TriaStudios.NetworkLib.Core.Abstract;
using TriaStudios.NetworkLib.Core.Interfaces;
using TriaStudios.NetworkLib.Core.Middlewares;
using UnityEngine;
using UnityEngine.Events;

namespace Network
{
    public class TcpClient : MonoBehaviour
    {
        public static TcpClient Instance { get; private set; }

        #region Events

        public UnityEvent authUserErrorEvent;
        public UnityEvent authUserDoneEvent;

        public UnityEvent<List<Message>> messagesUpdateEvent;

        public UnityEvent<List<User>> usersUpdateEvent;

        #endregion
        
        public GameSession CurrentSession { get; private set; }
        public IIoCService IoCService { get; private set; }
        
        private NetworkSocket<GameSession> _client;
        private CancellationTokenSource _clientTaskToken;

        private void Awake()
        {
            Instance = this;
            DontDestroyOnLoad(this);
            
            _client = NetworkSocket<GameSession>.Builder()
                .BindAddress(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 1234))
                .AddLogger((layer, s) => Debug.Log($"[{layer}] {s}"))
                .AddPipeline(builder =>
                {
                    builder.UseEncryption();
                })
                .AddConnectHandler(session => CurrentSession = session)
                .AddDisconnectHandler(_ => CurrentSession = null)
                .BuildClient();

            IoCService = _client.IoCService;

            _clientTaskToken = new CancellationTokenSource();
            _client.RunAsync(_clientTaskToken.Token);
        }

        private void OnDestroy()
        {
            _clientTaskToken.Cancel();
            _client.Dispose();
        }
    }
}
