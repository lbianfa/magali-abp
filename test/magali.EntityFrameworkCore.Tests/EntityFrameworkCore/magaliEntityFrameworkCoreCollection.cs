using Xunit;

namespace magali.EntityFrameworkCore;

[CollectionDefinition(magaliTestConsts.CollectionDefinitionName)]
public class magaliEntityFrameworkCoreCollection : ICollectionFixture<magaliEntityFrameworkCoreFixture>
{

}
