using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;

namespace SceneSample.Mvvm.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    [ObservableProperty]
    public partial string Greeting { get; set; } = "Welcome to Avalonia!";

    public async Task ShowSampleView()
    {
        if (App.Current is App app && app.Navigator != null)
        {
            await app.Navigator.NavigateAsync(new SampleViewModel());
        }
    }
}
