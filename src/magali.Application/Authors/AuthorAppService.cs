using magali.Permissions;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Threading.Tasks;
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
    }
}
