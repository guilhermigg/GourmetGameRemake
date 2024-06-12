using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using GourmetGame.App.Messages;
using GourmetGame.App.Services;

namespace GourmetGame.App.ViewModels;

public partial class MainWindowViewModel : ViewModelBase 
{
    public MainWindowViewModel(IMessenger messenger)
    {
        GameService gameService = new GameService();

        WeakReferenceMessenger.Default.Register<MainWindowViewModel, string>(this, (_, message) =>
        {
            switch (message) {
                case "Start":
                    gameService.Restart();
                    CurrentPage = new GameViewModel(gameService);
                    break;
                case "Win":
                    CurrentPage = new FirstViewModel();
                    break;
                case "Loss":
                    CurrentPage = new InputFoodViewModel(gameService);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(message), message, null);
            }
        });
    }

    [ObservableProperty]
    private ViewModelBase _currentPage = new FirstViewModel();
}
