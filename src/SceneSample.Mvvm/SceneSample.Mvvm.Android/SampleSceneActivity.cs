using Android.App;
using Android.Content.PM;
using Avalonia.Android.Scene;
using SceneSample.Mvvm.Scenes;

namespace SceneSample.Mvvm.Android;

[Activity(
    Label = "Sample Scene",
    Theme = "@style/MyTheme.NoActionBar",
    Icon = "@drawable/icon",
    ConfigurationChanges = ConfigChanges.Orientation | ConfigChanges.ScreenSize | ConfigChanges.UiMode)]
public class SampleSceneActivity : SceneActivity<SampleScene>
{


    public static void RegisterInManager()
    {
        RegisterInManager<SampleScene>(typeof(SampleSceneActivity));
    }
}
