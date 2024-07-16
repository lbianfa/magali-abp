using System;
using Volo.Abp.Application.Dtos;

namespace magali.Books
{
    public class BookDto : AuditedEntityDto<Guid>
    {
        private string _name;

        public string Name { 
            get => _name;
            set => _name = value.ToLowerInvariant(); 
        }

        public string Type { get; set; }

        public DateTime PublishDate { get; set; }

        public float Price { get; set; }

        public Guid AuthorId { get; set; }

        public string AuthorName { get; set; }
    }
}
