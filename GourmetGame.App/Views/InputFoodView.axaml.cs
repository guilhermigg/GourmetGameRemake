using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace GourmetGame.App.Views;

public partial class InputFoodView : UserControl
{
    public InputFoodView()
    {
        InitializeComponent();
    }
    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}