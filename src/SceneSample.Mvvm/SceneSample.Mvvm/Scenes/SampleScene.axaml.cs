using System;
using System.Collections.Generic;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Interactivity;
using Avalonia.Platform.Storage;
using SceneSample.Mvvm.ViewModels;

namespace SceneSample.Mvvm.Scenes;

[AndroidScene(label: "Sample Image Viewer", androidTheme: "@style/MyTheme.NoActionBar", isExported: true, launchMode: AndroidSceneLaunchMode.SingleTask, isLauncher: false, iconResource: "@drawable/icon", dataMimeTypes: ["image/*"],
   dataSchemes: ["content", "file"], actions: ["android.intent.action.VIEW"], categories: [AndroidSceneCategory.Default, AndroidSceneCategory.Browsable])]
public partial class SampleScene : Scene
{
    private IReadOnlyList<IStorageItem>? _cachedFiles;

    public SampleScene()
    {
        InitializeComponent();

        Activated += SampleScene_Activated;
        Deactivated += SampleScene_Deactivated;
    }

    private void SampleScene_Deactivated(object? sender, ActivatedEventArgs e)
    {
    }

    private void SampleScene_Activated(object? sender, ActivatedEventArgs e)
    {
        if (e.Kind is ActivationKind.File && e is FileActivatedEventArgs fileArgs)
        {
            _cachedFiles = fileArgs.Files;
            if (DataContext is SampleViewModel sampleViewModel && _cachedFiles.Count > 0 && _cachedFiles[0] is { } file)
            {
                sampleViewModel.SetImageFile(file);
            }
        }
    }

    protected override void OnLoaded(RoutedEventArgs e)
    {
        base.OnLoaded(e);

        if (DataContext is not SampleViewModel)
        {
            DataContext = new SampleViewModel();
        }
    }

    protected override void OnDataContextChanged(EventArgs e)
    {
        base.OnDataContextChanged(e);

        if (DataContext is SampleViewModel sampleViewModel && _cachedFiles?.Count > 0 && _cachedFiles[0] is { } file)
        {
            sampleViewModel.SetImageFile(file);
        }
    }

    private void CloseButton_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        this.Close();
    }
}