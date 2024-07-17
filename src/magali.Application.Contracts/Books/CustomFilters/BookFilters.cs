using System;
using System.Text.Json.Serialization;

namespace magali.Books.CustomFilters
{
    public class BookFilters : PagedSortedAndFilteredResultRequestDto
    {
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public BookType? Type {  get; set; }

        public Guid FilterByAuthor { get; set; } = Guid.Empty;
    }
}
