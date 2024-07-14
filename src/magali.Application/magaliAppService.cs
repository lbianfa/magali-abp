using System;
using System.Collections.Generic;
using System.Text;
using magali.Localization;
using Volo.Abp.Application.Services;

namespace magali;

/* Inherit your application services from this class.
 */
public abstract class magaliAppService : ApplicationService
{
    protected magaliAppService()
    {
        LocalizationResource = typeof(magaliResource);
    }
}
