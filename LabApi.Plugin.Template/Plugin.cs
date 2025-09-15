using LabApi.Features;
using LabApi.Loader;
using LabApi.Loader.Features.Plugins;
using LabApi.Loader.Features.Plugins.Enums;

namespace LabApi.Plugin.Template;

internal sealed class Plugin : Plugin<Config>
{
    public override string Name { get; } = "LabApi.Plugin.Template";
    public override string Description { get; } = "";
    public override string Author { get; } = "aksueikava";
    public override LoadPriority Priority { get; } = LoadPriority.Medium;
    public override Version Version { get; } = new(1, 0, 0);
    public override Version RequiredApiVersion { get; } = new(LabApiProperties.CompiledVersion);

    public static Plugin? Instance { get; private set; }
    public Translation? Translation { get; private set; }
    private EventHandlers? _handlers;

    public override void Enable()
    {
        Instance = this;
        LoadConfigs();

        _handlers = new EventHandlers();
        // subscribe your event handlers here
    }
    
    public override void LoadConfigs()
    {
        base.LoadConfigs();

        const string translationFile = "translation.yml";
        Translation = this.TryLoadConfig(translationFile, out Translation? loaded) 
            ? loaded : new Translation();
    }

    public override void Disable()
    {
        if (_handlers is null)
            return;

        // unsubscribe your event handlers here
        _handlers = null;

        Instance = null;
    }
}