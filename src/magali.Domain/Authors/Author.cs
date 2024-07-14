using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace magali.Authors
{
    public class Author : AuditedAggregateRoot<Guid>
    {
        public uint Identification { get; set; }

        public string Name { get; set; } = string.Empty;

        public DateTime BirthDate { get; set; }

        public string? ShortBio { get; set; }

        private Author() { }

        internal Author(uint identification, string name, DateTime birthDate, string? shortBio)
        {
            Identification = identification;
            Name = name;
            BirthDate = birthDate;
            ShortBio = shortBio;
        }
    }
}
