using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace magali.Authors
{
    public interface IAuthorAppService : ICrudAppService<
            AuthorDto,
            Guid,
            PagedSortedAndFilteredResultRequestDto,
            CreateUpdateAuthorDto
        >
    {
        Task<PagedResultDto<AuthorLookupDto>> GetAuthorLookup(PagedSortedAndFilteredResultRequestDto input);
    }
}
