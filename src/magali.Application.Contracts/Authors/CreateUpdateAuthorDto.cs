using System;
using System.ComponentModel.DataAnnotations;

namespace magali.Authors
{
    public class CreateUpdateAuthorDto
    {
        [Required]
        public uint Identification { get; set; }

        [Required]
        [StringLength(AuthorConsts.MaxNameLength)]
        public string Name { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

        public string? ShortBio { get; set; }
    }
}
