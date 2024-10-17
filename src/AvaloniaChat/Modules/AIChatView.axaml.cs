using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Lemon.ModuleNavigation.Abstracts;

namespace AvaloniaChat;

public partial class AIChatView : UserControl, IView
{
    public AIChatView()
    {
        InitializeComponent();
    }

    public void SetDataContext(IViewModel viewModel)
    {
        DataContext = viewModel;
    }
}