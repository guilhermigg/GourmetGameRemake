using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using CommunityToolkit.Mvvm.DependencyInjection;
using CommunityToolkit.Mvvm.Messaging;
using GourmetGame.App.ViewModels;
using GourmetGame.App.Views;
using Microsoft.Extensions.DependencyInjection;
using CommunityToolkit.Extensions.DependencyInjection;

namespace GourmetGame.App;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        var locator = new ViewLocator();
        DataTemplates.Add(locator);

        var services = new ServiceCollection();
        ConfigureViewModels(services);
        ConfigureViews(services);
        services.AddSingleton<IMessenger>(WeakReferenceMessenger.Default);

        var provider = services.BuildServiceProvider();
        Ioc.Default.ConfigureServices(provider);

        var vm = Ioc.Default.GetRequiredService<MainWindowViewModel>();

        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = new MainWindow(vm);
        }

        base.OnFrameworkInitializationCompleted();
    }

    [Singleton(typeof(MainWindowViewModel))]
    [Singleton(typeof(FirstViewModel))]
    [Singleton(typeof(GameViewModel))]
    [Singleton(typeof(InputFoodViewModel))]
    [Singleton(typeof(WinViewModel))]
    internal static partial void ConfigureViewModels(IServiceCollection services);
    
    [Singleton(typeof(MainWindow))]
    [Transient(typeof(FirstView))]
    [Transient(typeof(GameView))]
    [Transient(typeof(InputFoodView))]
    [Transient(typeof(WinView))]
    internal static partial void ConfigureViews(IServiceCollection services);
}