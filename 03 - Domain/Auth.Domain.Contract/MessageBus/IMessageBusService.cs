﻿namespace Auth.Domain.Contract.MessageBus;

public interface IMessageBusService
{
    void Publish(string queue, byte[] message);
}
