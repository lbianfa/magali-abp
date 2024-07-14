using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Pages.Abp.MultiTenancy;
using System.Collections.Generic;
using Volo.Abp.AspNetCore.Mvc.ApiExploring;
using Volo.Abp.AspNetCore.Mvc.ApplicationConfigurations;
using Volo.Abp.Identity;

namespace magali
{
    public class ControllerExclusions : IApplicationModelConvention
    {
        public void Apply(ApplicationModel application)
        {
            application.Controllers.RemoveAll(x => x.ControllerType == typeof(AbpApiDefinitionController));
            application.Controllers.RemoveAll(x => x.ControllerType == typeof(AbpApplicationConfigurationController));
            application.Controllers.RemoveAll(x => x.ControllerType == typeof(AbpApplicationLocalizationController));
            application.Controllers.RemoveAll(x => x.ControllerType == typeof(AbpTenantController));
            application.Controllers.RemoveAll(x => x.ControllerType == typeof(IdentityUserLookupController));
        }
    }
}
