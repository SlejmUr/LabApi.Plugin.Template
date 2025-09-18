using LabApi.Features;
using LabApi.Loader;
using LabApi.Loader.Features.Plugins;
using LabApi.Loader.Features.Plugins.Enums;

namespace Template;

internal sealed class Main
#if (noconfig)
    : Plugin
#else
    : Plugin<Config>
#endif
{
    public override string Name { get; } = "Template";
    public override string Description { get; } = "__description__";
    public override string Author { get; } = "__author__";
    public override LoadPriority Priority { get; } = LoadPriority.Medium;
    public override Version Version { get; } = new(1, 0, 0);
    public override Version RequiredApiVersion { get; } = new(LabApiProperties.CompiledVersion);

    public static Main? Instance { get; private set; }
#if (includetranslation)
    public Translation? Translation { get; private set; }
#endif

    public override void Enable()
    {
        Instance = this;
    }
#if (includetranslation)
    public override void LoadConfigs()
    {
        base.LoadConfigs();

        const string translationFile = "translation.yml";
        Translation = this.TryLoadConfig(translationFile, out Translation? loaded) 
            ? loaded : new Translation();
    }
#endif
    public override void Disable()
    {
        Instance = null;
    }
}