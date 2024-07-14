using magali.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace magali.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class magaliController : AbpControllerBase
{
    protected magaliController()
    {
        LocalizationResource = typeof(magaliResource);
    }
}
