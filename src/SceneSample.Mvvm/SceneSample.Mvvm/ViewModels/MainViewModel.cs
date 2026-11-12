using System.Threading.Tasks;
using Avalonia.Media;
using Avalonia.Media.Imaging;
using Avalonia.Platform.Storage;
using CommunityToolkit.Mvvm.ComponentModel;

namespace SceneSample.Mvvm.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    [ObservableProperty]
    public partial string Greeting { get; set; } = "Welcome to Avalonia!";
    public IStorageProvider? StorageProvider { get; internal set; }

    [ObservableProperty]
    public partial IImage? LoadedImage { get; set; }

    public async Task ShowSampleView()
    {
        if (App.Current is App app && app.Navigator != null)
        {
            await app.Navigator.NavigateAsync(new SampleViewModel());
        }
    }

    public async Task OpenFileSelector()
    {
        if (StorageProvider is { } provider)
        {
            var files = await provider.OpenFilePickerAsync(new FilePickerOpenOptions()
            {
                FileTypeFilter = [FilePickerFileTypes.ImageAll],
                AllowMultiple = false
            });

            if (files.Count > 0 && files[0] is { } file)
            {
                using var stream = await file.OpenReadAsync();

                LoadedImage = new Bitmap(stream);
            }
        }
    }

    public async Task OpenInViewer()
    {
        if (App.Current is App app && app.Navigator != null && LoadedImage is { } image)
        {
            await app.Navigator.NavigateAsync(new SampleViewModel()
            {
                LoadedImage = image
            });
        }
    }
}
