using Volo.Abp.Settings;

namespace magali.Settings;

public class magaliSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(magaliSettings.MySetting1));
    }
}
