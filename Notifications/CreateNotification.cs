﻿namespace Clarity.Abstractions
{
    using System;
    using Core;
    using MediatR;

    public abstract class CreateNotification<TModel> : INotification
    {
        public EventIds EventId { get; set; }

        public TModel Model { get; set; }

        public Exception Exception { get; set; }
    }
}