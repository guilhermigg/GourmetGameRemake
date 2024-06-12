using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using GourmetGame.App.Services;

namespace GourmetGame.App.ViewModels;

public partial class GameViewModel: ViewModelBase
{
    [ObservableProperty] private string _currentFood = "Comida";
    //[ObservableProperty] private string _foodInput = "Comida";
    private readonly GameService _gameService;
    private readonly WeakReferenceMessenger _messenger;

    public GameViewModel(GameService gameService)
    {
        _gameService = gameService;
        CurrentFood = _gameService.CurrentNode.Food;
        _messenger = WeakReferenceMessenger.Default;
    }

    [RelayCommand]
    private void Yes()
    {

        var retorno = _gameService.Guess(true);
        if(retorno == null){
            _messenger.Send("Win");
        }
        else {
            CurrentFood = retorno.Food.ToString();
        }
    }

    [RelayCommand]
    private void No()
    {
        var retorno = _gameService.Guess(false);
        if(retorno == null){
            _messenger.Send("Loss");
        } 
        else {
            CurrentFood = retorno.Food.ToString();
        }
    }
}