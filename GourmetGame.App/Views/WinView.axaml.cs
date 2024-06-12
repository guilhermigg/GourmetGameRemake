using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace GourmetGame.App.Views;

public partial class WinView : UserControl
{
    public WinView()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}