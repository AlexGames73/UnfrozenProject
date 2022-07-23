using System;
using Acks;
using TriaStudios.NetworkLib.Core.Attributes;
using UnityEngine;
using Utils;

namespace Network.Factories
{
    [Dependency]
    public class AuthUserFactory
    {
        public void Send(string username, Color color)
        {
            TcpClient.Instance.CurrentSession.Send(new AuthUserAck
            {
                Username = username,
                Color = ColorTypeConverter.ToArgb(color),
                TimeZoneMinutesOffset = (int)TimeZoneInfo.Local.BaseUtcOffset.TotalMinutes
            });
        }
    }
}
