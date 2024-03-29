﻿namespace crgolden.Abstractions
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Threading;
    using System.Threading.Tasks;
    using MediatR;
    using Microsoft.Extensions.Logging;
    using Shared;

    [ExcludeFromCodeCoverage]
    public abstract class UpdateRangeNotificationHandler<TNotification, TModel> : INotificationHandler<TNotification>
        where TNotification : UpdateRangeNotification<TModel>
    {
        private readonly ILogger<UpdateRangeNotificationHandler<TNotification, TModel>> _logger;

        protected UpdateRangeNotificationHandler(ILogger<UpdateRangeNotificationHandler<TNotification, TModel>> logger)
        {
            _logger = logger;
        }

        public virtual Task Handle(TNotification notification, CancellationToken token)
        {
            var eventId = new EventId((int)notification.EventId, $"{notification.EventId}");
            switch (notification.EventId)
            {
                case EventIds.UpdateRangeStart:
                    _logger.LogInformation(
                        eventId: eventId,
                        message: "Updating model(s) {@Models} at {@Time}",
                        args: new object[] { notification.Models, DateTime.UtcNow });
                    break;
                case EventIds.UpdateRangeEnd:
                    _logger.LogInformation(
                        eventId: eventId,
                        message: "Updated model(s) {@Models} at {@Time}",
                        args: new object[] { notification.Models, DateTime.UtcNow });
                    break;
                case EventIds.UpdateRangeError:
                    _logger.LogError(
                        eventId: eventId,
                        exception: notification.Exception,
                        message: "Error updating model(s) {@Models} at {@Time}",
                        args: new object[] { notification.Models, DateTime.UtcNow });
                    break;
            }

            return Task.CompletedTask;
        }
    }
}
