using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using GourmetGame.App.Services;

namespace GourmetGame.App.ViewModels;

public partial class InputFoodViewModel : ViewModelBase
{
    [ObservableProperty] public string _foodInput;
    [ObservableProperty] public string _secondFoodInput;
    private readonly WeakReferenceMessenger _messenger;
    private readonly GameService _gameService;

    public InputFoodViewModel(GameService gameService)
    {
        _messenger = WeakReferenceMessenger.Default;
        _gameService = gameService;
    }

    [RelayCommand]
    private void AddFood()
    {
        if(FoodInput != null && SecondFoodInput != null) {
            // foodInput é mas currentNode não é
            string foodName = FoodInput.ToString();
            string secondFoodName = SecondFoodInput.ToString();

            _gameService.AddFood(foodName, secondFoodName);
            _messenger.Send("Win");
        }
    }
}
