using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

namespace AvaloniaChat;

public partial class MessageWindow : Window
{
    public MessageWindow()
    {
        InitializeComponent();
    }
    public MessageWindow(string message) : this()
    {
        MessageTextBlock.Text = message;     
    }

    private void OnOkButtonClick(object sender, RoutedEventArgs e)
    {
        Close();
    }
}