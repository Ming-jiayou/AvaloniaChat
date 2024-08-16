using Avalonia.Controls;
using AvaloniaChat.ViewModels;

namespace AvaloniaChat.Views;

public partial class MainWindow : Window
{
    public MainWindow(MainViewModel viewModel)
    {
        this.DataContext = viewModel;
        InitializeComponent();       
    }
}
