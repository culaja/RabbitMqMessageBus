using System;

namespace Common
{
    public interface IMessage
    {
        DateTime Timestamp { get; }

        byte[] Serialize();
    }
}