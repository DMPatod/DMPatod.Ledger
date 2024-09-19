﻿using DDD.Core.DomainObjects;
using Ledger.Domain.Providers.ValueObjects;
using Ledger.Domain.Tickets;

namespace Ledger.Domain.Providers
{
    public class Provider : AggregateRoot<ProviderId>
    {
        public string Name { get; set; }

        public ICollection<Ticket> Tickets { get; } = [];

        public double TotalSpent { get => Tickets.Sum(t => t.Value); }

        private Provider()
        {
            // For EF Only.
        }

        internal Provider(ProviderId id, string name)
            : base(id)
        {
            Name = name;
        }

        public static Provider Create(string name)
        {
            return new Provider(
                ProviderId.Create(),
                name);
        }
    }
}