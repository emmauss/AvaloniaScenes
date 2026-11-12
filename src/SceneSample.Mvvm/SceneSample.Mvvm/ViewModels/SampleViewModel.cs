using Avalonia.Media;
using Avalonia.Media.Imaging;
using Avalonia.Platform.Storage;
using CommunityToolkit.Mvvm.ComponentModel;

namespace SceneSample.Mvvm.ViewModels
{
    internal partial class SampleViewModel : ViewModelBase
    {
        public string Content => "Hello, Avalonia. This is a simple sample!";

        [ObservableProperty]
        public partial IImage? LoadedImage { get; set; }

        internal async void SetImageFile(IStorageItem file)
        {
            if (file is IStorageFile fileStorage)
            {
                using var stream = await fileStorage.OpenReadAsync();

                LoadedImage = new Bitmap(stream);
            }
        }
    }
}
