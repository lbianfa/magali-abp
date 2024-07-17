using magali.Authors;
using magali.Books.CustomFilters;
using System;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories;

namespace magali.Books
{
    public class BookAppService : CrudAppService<
            Book,
            BookDto,
            Guid,
            BookFilters,
            CreateUpdateBookDto
        >, IBookAppService
    {
        private readonly IRepository<Author, Guid> _authorRepository;

        public BookAppService(IRepository<Book, Guid> repository, IRepository<Author, Guid> authorRepository) : base(repository)
        {
            _authorRepository = authorRepository;
            CreatePolicyName = null;
        }

        private async Task<Author?> GetAuthorAsync(Guid authorId)
        {
            Author? author;

            try
            {
                author = await _authorRepository.GetAsync(authorId);
            }
            catch (EntityNotFoundException)
            {
                throw new EntityNotFoundException($"Author with Id: {authorId} not found");
            }

            return author;
        }

        public override async Task<BookDto> CreateAsync(CreateUpdateBookDto input)
        {
            var author = await GetAuthorAsync(input.AuthorId);

            var newBook = await base.CreateAsync(input);
            newBook.AuthorName = author.Name;

            return newBook;
        }

        public override async Task<BookDto> UpdateAsync(Guid id, CreateUpdateBookDto input)
        {
            var author = await GetAuthorAsync(input.AuthorId);

            var bookUpdated = await base.UpdateAsync(id, input);
            bookUpdated.AuthorName = author.Name;

            return bookUpdated;
        }

        public override async Task<BookDto> GetAsync(Guid id)
        {
            var book = await base.GetAsync(id);

            var author = await GetAuthorAsync(book.AuthorId);

            book.AuthorName = author.Name;

            return book;
        }

        public override async Task<PagedResultDto<BookDto>> GetListAsync(BookFilters input)
        {
            var query = await Repository.GetQueryableAsync();

            // Apply filtering by name
            query = query.WhereIf(!input.Filter.IsNullOrEmpty(), b => b.Name.Contains(input.Filter));

            // Apply filtering by author
            query = query.WhereIf(input.FilterByAuthor != Guid.Empty, b => b.AuthorId.Equals(input.FilterByAuthor));

            // Apply filtering by bookType
            query = query.WhereIf(input.Type.HasValue, b => b.Type.Equals(input.Type));

            // Apply sorting
            query = query.OrderBy(input.Sorting ?? "creationTime desc");

            // Get totalCount before about pagination
            var totalCount = await AsyncExecuter.CountAsync(query);

            // Apply paging
            query = query.PageBy(input.SkipCount, input.MaxResultCount);

            // Execute the query and get the result
            var books = await AsyncExecuter.ToListAsync(query);

            var booksDto = await MapToGetListOutputDtosAsync(books);

            var authorIds = books.Select(b => b.AuthorId).ToList();

            var authors = await _authorRepository.GetListAsync(a => authorIds.Contains(a.Id));

            booksDto = booksDto.Join(
                authors,
                bookDto => bookDto.AuthorId,
                author => author.Id,
                (bookDto, author) =>
                {
                    bookDto.AuthorName = author.Name;
                    return bookDto;
                }
            ).ToList();

            return new PagedResultDto<BookDto>(totalCount, booksDto);

        }
    }
}
