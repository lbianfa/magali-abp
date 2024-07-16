using magali.Books.CustomValidations;
using System;
using System.ComponentModel.DataAnnotations;

namespace magali.Books
{
    public class CreateUpdateBookDto
    {
        [Required]
        [StringLength(BookConsts.MaxNameLength)]
        public string Name { get; set; }

        [Required]
        [BookTypeValidation]
        public string Type { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime PublishDate { get; set; }

        [Required]
        public float Price { get; set; }

        [Required]
        public Guid AuthorId { get; set; }
    }
}
