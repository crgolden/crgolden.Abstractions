﻿namespace Clarity.Abstractions
{
    using System;
    using System.Collections.Generic;
    using MediatR;
    using Shared;

    public abstract class ReadRangeNotification<TModel> : INotification
    {
        public EventIds EventId { get; set; }

        public object[][] KeyValues { get; set; }

        public IEnumerable<TModel> Models { get; set; }

        public Exception Exception { get; set; }
    }
}
