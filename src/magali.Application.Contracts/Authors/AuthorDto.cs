using System;
using Volo.Abp.Application.Dtos;

namespace magali.Authors
{
    public class AuthorDto : AuditedEntityDto<Guid>
    {
        public uint Identification { get; set; }

        public string Name { get; set; }

        public DateTime BirthDate { get; set; }

        public string? ShortBio { get; set; }
    }
}
