using magali.Permissions;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace magali.Authors
{
    [Authorize(magaliPermissions.Authors.Default)]
    public class AuthorAppService : CrudAppService<
            Author,
            AuthorDto,
            Guid,
            PagedSortedAndFilteredResultRequestDto,
            CreateUpdateAuthorDto
        >, IAuthorAppService
    {
        private readonly AuthorManager _authorManager;

        public AuthorAppService(IRepository<Author, Guid> repository, AuthorManager authorManager) : base(repository)
        {
            _authorManager = authorManager;
            GetPolicyName = magaliPermissions.Authors.Default;
            GetListPolicyName = magaliPermissions.Authors.Default;
            GetPolicyName = magaliPermissions.Authors.Default;
            CreatePolicyName = magaliPermissions.Authors.Create;
            UpdatePolicyName = magaliPermissions.Authors.Edit;
            DeletePolicyName = magaliPermissions.Authors.Delete;
        }

        public override async Task<AuthorDto> CreateAsync(CreateUpdateAuthorDto input)
        {
            await CheckCreatePolicyAsync();

            var author = await _authorManager.CreateAsync(input.Identification, input.Name, input.BirthDate, input.ShortBio);

            author = await Repository.InsertAsync(author);

            return ObjectMapper.Map<Author, AuthorDto>(author);
        }

        public override async Task<PagedResultDto<AuthorDto>> GetListAsync(PagedSortedAndFilteredResultRequestDto input)
        {
            await CheckGetListPolicyAsync();

            var query = await Repository.GetQueryableAsync();

            // Apply filtering
            query = query.WhereIf(!input.Filter.IsNullOrEmpty(), a => a.Name.ToLower().Contains(input.Filter.ToLower()));

            // Apply sorting
            query = query.OrderBy(input.Sorting ?? "creationTime desc");

            // Get totalCount before about pagination
            var totalCount = await AsyncExecuter.CountAsync(query);

            // Apply paging
            query = query.PageBy(input.SkipCount, input.MaxResultCount);

            // Execute the query and get the result
            var authors = await AsyncExecuter.ToListAsync(query);

            var authorsDtos = ObjectMapper.Map<List<Author>, List<AuthorDto>>(authors).ToList();

            return new PagedResultDto<AuthorDto>(totalCount, authorsDtos);
        }
    }
}
