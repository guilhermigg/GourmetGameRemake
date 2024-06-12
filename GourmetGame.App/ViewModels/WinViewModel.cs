using Avalonia;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;

namespace GourmetGame.App.ViewModels;

public partial class WinViewModel : ViewModelBase
{
    private readonly WeakReferenceMessenger _messenger;

    public WinViewModel()
    {
        _messenger = WeakReferenceMessenger.Default;
    }

    [RelayCommand]
    private void PlayAgain()
    {
        _messenger.Send("Home");
    }
}
