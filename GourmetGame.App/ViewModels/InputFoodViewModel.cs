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

    [ObservableProperty] public string _firstPageVisibility = "true";
    [ObservableProperty] public string _secondPageVisibility = "false";
    [ObservableProperty] public string _labelSecondPage;

    private readonly WeakReferenceMessenger _messenger;
    private readonly GameService _gameService;

    public InputFoodViewModel(GameService gameService)
    {
        _messenger = WeakReferenceMessenger.Default;
        _gameService = gameService;
    }

    private void SwitchPagesVisibility() {
        FirstPageVisibility = FirstPageVisibility == "true" ? "false" : "true";
        SecondPageVisibility = SecondPageVisibility == "true" ? "false" : "true";
    }

    [RelayCommand]
    private void GoToNextPage()
    {
        if(FoodInput != null) {
            string currentFood = _gameService.CurrentNode.Food;
            LabelSecondPage = $"{FoodInput} é ____ mas {currentFood} não é:";
            SwitchPagesVisibility();
        }
    }

    [RelayCommand]
    private void AddFood()
    {
        if(FoodInput != null && SecondFoodInput != null) {
            string foodName = FoodInput.ToString();
            string secondFoodName = SecondFoodInput.ToString();

            _gameService.AddFood(foodName, secondFoodName);
            _messenger.Send("Home");
            SwitchPagesVisibility();
        }
    }
}
