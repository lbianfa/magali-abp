using magali.Samples;
using Xunit;

namespace magali.EntityFrameworkCore.Applications;

[Collection(magaliTestConsts.CollectionDefinitionName)]
public class EfCoreSampleAppServiceTests : SampleAppServiceTests<magaliEntityFrameworkCoreTestModule>
{

}
