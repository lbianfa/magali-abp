using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace magali;

[Dependency(ReplaceServices = true)]
public class magaliBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "magali";
}
