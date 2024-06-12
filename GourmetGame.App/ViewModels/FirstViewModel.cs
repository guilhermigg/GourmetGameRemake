using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;

namespace GourmetGame.App.ViewModels;

public partial class FirstViewModel : ViewModelBase
{
    private readonly WeakReferenceMessenger _messenger;

    public FirstViewModel()
    {
        _messenger = WeakReferenceMessenger.Default;
    }

    [RelayCommand]
    private void StartGame()
    {
        _messenger.Send("Start");
    }
}
