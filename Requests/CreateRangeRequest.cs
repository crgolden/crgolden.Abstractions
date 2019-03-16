﻿namespace Clarity.Abstractions
{
    using MediatR;

    public abstract class CreateRangeRequest<TEntity, TModel> : IRequest<TModel[]>
        where TEntity : class
    {
        public readonly TModel[] Models;

        protected CreateRangeRequest(TModel[] models)
        {
            Models = models;
        }
    }
}
