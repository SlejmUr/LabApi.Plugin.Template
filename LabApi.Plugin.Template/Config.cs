using System.ComponentModel;

namespace LabApi.Plugin.Template;

public class Config
{
    [Description("Whether debug messages should be shown in the console.")]
    public bool Debug { get; set; }
}