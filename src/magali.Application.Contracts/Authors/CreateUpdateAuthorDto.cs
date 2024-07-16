using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace magali.Authors
{
    public class CreateUpdateAuthorDto
    {
        private string _name;

        private string _shortBio;

        [Required]
        public uint Identification { get; set; }

        [Required]
        [StringLength(AuthorConsts.MaxNameLength)]
        public string Name
        {
            get => _name;
            set => _name = value.ToLowerInvariant();
        }

        [Required]
        public DateTime BirthDate { get; set; }

        public string? ShortBio { 
            get => _shortBio;
            set => _shortBio = value?.ToLowerInvariant();
        }
    }
}
