﻿namespace crgolden.Abstractions.Fakes
{
    using System.Diagnostics.CodeAnalysis;
    using Microsoft.EntityFrameworkCore;

    [ExcludeFromCodeCoverage]
    internal class FakeContext : Context
    {
        internal FakeContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<FakeEntity>(x =>
            {
                x.HasKey(entity => entity.Id);
                x.Property(entity => entity.Name);
            });
        }
    }
}
