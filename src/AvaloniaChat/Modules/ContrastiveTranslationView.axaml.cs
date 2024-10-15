using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Lemon.ModuleNavigation.Abstracts;

namespace AvaloniaChat;

public partial class ContrastiveTranslationView : UserControl, IView
{
    public ContrastiveTranslationView()
    {
        InitializeComponent();
    }

    public void SetDataContext(IViewModel viewModel)
    {
        DataContext = viewModel;
    }
}