using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Avalonia.Controls;

namespace SceneSample.Mvvm;

public sealed class ViewNavigator(ViewLocator viewLocator)
{
    [RequiresUnreferencedCode("ViewLocator resolves views using reflection, which may be trimmed away.")]
    public async Task<Control> NavigateAsync(object viewModel)
    {
        ArgumentNullException.ThrowIfNull(viewModel);

        var view = viewLocator.Build(viewModel)
            ?? throw new InvalidOperationException("The view locator did not create a view.");
        view.DataContext = viewModel;

        if (view is Scene scene)
        {
            await scene.ShowAsync();
        }

        return view;
    }
}
