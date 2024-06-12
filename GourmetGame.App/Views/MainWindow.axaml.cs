using Avalonia;
using Avalonia.Controls;
using GourmetGame.App.ViewModels;

namespace GourmetGame.App.Views;

public partial class MainWindow : Window
{
    public MainWindow(MainWindowViewModel vm)
    {
        DataContext = vm;
        InitializeComponent();
    }
}