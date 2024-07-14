using magali.Samples;
using Xunit;

namespace magali.EntityFrameworkCore.Domains;

[Collection(magaliTestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<magaliEntityFrameworkCoreTestModule>
{

}
