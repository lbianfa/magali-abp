using magali.Authors.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace magali.Authors
{
    public class AuthorManager : DomainService
    {
        private readonly IRepository<Author, Guid> _authorRepository;

        public AuthorManager(IRepository<Author, Guid> authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public async Task<Author> CreateAsync(uint identification, string name, DateTime birthDate, string? shortBio)
        {
            var existingAuthor = await _authorRepository.AnyAsync(a => a.Identification == identification);
            if (existingAuthor)
            {
                throw new AuthorAlreadyExistsOptions(identification);
            }

            return new Author(
                identification,
                name,
                birthDate,
                shortBio
            );
        }
    }
}
