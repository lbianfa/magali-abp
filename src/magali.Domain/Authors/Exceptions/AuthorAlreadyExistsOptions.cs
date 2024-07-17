using Volo.Abp;

namespace magali.Authors.Exceptions
{
    public class AuthorAlreadyExistsOptions : BusinessException
    {
        public AuthorAlreadyExistsOptions(uint identification) : base(magaliDomainErrorCodes.AuthorAlreadyExists, $"An author with the identification {identification} already exists.") {
            WithData("identification", identification);
        }
    }
}
