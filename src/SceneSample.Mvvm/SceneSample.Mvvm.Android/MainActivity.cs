using Android.App;
using Android.Content.PM;
using Avalonia.Android.Scene;
using SceneSample.Mvvm.Scenes;

namespace SceneSample.Mvvm.Android;

[Activity(
    Label = "SceneSample.Mvvm.Android",
    Theme = "@style/MyTheme.NoActionBar",
    Icon = "@drawable/icon",
    MainLauncher = true,
    ConfigurationChanges = ConfigChanges.Orientation | ConfigChanges.ScreenSize | ConfigChanges.UiMode)]
public class MainActivity : SceneActivity<MainScene>
{


    public static void RegisterInManager()
    {
        RegisterInManager<MainScene>(typeof(MainActivity));
    }
}
