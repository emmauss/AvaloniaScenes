
using Avalonia;
using Avalonia.Controls;
using Avalonia.Platform.Storage;
using SceneSample.Mvvm.ViewModels;

namespace SceneSample.Mvvm.Scenes;

[AndroidScene(label: "Sample Image App", androidTheme: "@style/MyTheme.NoActionBar", isExported: true, isLauncher: true, iconResource: "@drawable/icon",
    actions: ["android.intent.action.VIEW"], categories: [AndroidSceneCategory.Launcher, AndroidSceneCategory.LeanbackLauncher])]
public partial class MainScene : Scene
{
    public MainScene()
    {
        InitializeComponent();

        DataContext = new MainViewModel();
    }

    protected override void OnAttachedToVisualTree(VisualTreeAttachmentEventArgs e)
    {
        base.OnAttachedToVisualTree(e);

        if (DataContext is MainViewModel viewModel)
        {
            var filePickerProvider = TopLevel.GetTopLevel(this)?.PlatformImpl?.TryGetFeature<IStorageProvider>();
            viewModel.StorageProvider = filePickerProvider;
        }
    }

    protected override void OnDetachedFromVisualTree(VisualTreeAttachmentEventArgs e)
    {
        base.OnDetachedFromVisualTree(e);

        if (DataContext is MainViewModel viewModel)
        {
            viewModel.StorageProvider = null;
        }
    }
}