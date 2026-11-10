
using Avalonia;
using Avalonia.Controls;
using SceneSample.Mvvm.ViewModels;

namespace SceneSample.Mvvm.Scenes;

public partial class MainScene : Scene
{
    public MainScene()
    {
        InitializeComponent();

        DataContext = new MainViewModel();
    }
}