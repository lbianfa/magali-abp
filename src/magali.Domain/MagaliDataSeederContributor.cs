using magali.Authors;
using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace magali
{
    public class MagaliDataSeederContributor : IDataSeedContributor, ITransientDependency
    {
        private readonly IRepository<Author, Guid> _authorRepository;
        private readonly AuthorManager _authorManager;

        public MagaliDataSeederContributor(IRepository<Author, Guid> authorRepository, AuthorManager authorManager)
        {
            _authorRepository = authorRepository;
            _authorManager = authorManager;
        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (await  _authorRepository.GetCountAsync() > 0) {
                return;
            }

            await _authorRepository.InsertAsync(
                await _authorManager.CreateAsync(
                    1210,
                    "gabriel garcia marquez",
                    new DateTime(1927, 03, 17),
                    "El mejor escritor del Mundo"
                )
            );

            await _authorRepository.InsertAsync(
                await _authorManager.CreateAsync(
                    1211,
                    "fabian serna",
                    new DateTime(1998, 10, 15),
                    null
                )
            );
        }
    }
}
