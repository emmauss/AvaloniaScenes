using Avalonia;
using Avalonia.Controls;
using SceneSample.Mvvm.Android;

namespace SceneSample.Mvvm
{
    internal static class SceneAppBuilderExtension
    {
        public static AppBuilder UseScenes(this AppBuilder builder)
        {
            return builder.
                AfterSetup(_ =>
                {
                    MainActivity.RegisterInManager();
                    SampleSceneActivity.RegisterInManager();
                });
        }
    }
}
