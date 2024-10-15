using Lemon.ModuleNavigation.Abstracts;
using Lemon.ModuleNavigation;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using ReactiveUI;

namespace AvaloniaChat.ViewModels;

#pragma warning disable SKEXP0010
public partial class MainViewModel : ViewModelBase, INavigationContextProvider
{
    public readonly NavigationService _navigationService;
    public MainViewModel(NavigationContext navigationContext,
        IEnumerable<IModule> modules,
        NavigationService navigationService)
        {
            _navigationService = navigationService;
            NavigationContext = navigationContext;
            Modules = new ObservableCollection<IModule>(modules);         
         }
    /// <summary>
    /// For binding
    /// </summary>
    public ObservableCollection<IModule> Modules
    {
        get;
        set;
    }

    private IModule? _selectedModule;
    public IModule? SelectedModule
    {
        get => _selectedModule;
        set
        {
            this.RaiseAndSetIfChanged(ref _selectedModule, value);
            _navigationService.NavigateTo(_selectedModule!);
        }
    }
    public NavigationContext NavigationContext
    {
        get;
    }
    //private Kernel _kernel;

    //[ObservableProperty]
    //private string askText;

    //[ObservableProperty]
    //private string responseText;

    //[ObservableProperty]
    //private string selectedLanguage;

    //public string[] Languages { get; set; }

    //public MainViewModel()
    //{
    //    var handler = new OpenAIHttpClientHandler();
    //    var builder = Kernel.CreateBuilder()
    //    .AddOpenAIChatCompletion(
    //       modelId: OpenAIOption.ChatModel,
    //       apiKey: OpenAIOption.Key,
    //       httpClient: new HttpClient(handler));
    //    //var builder = Kernel.CreateBuilder()
    //    //.AddOpenAIChatCompletion(
    //    //    modelId: OpenAIOption.ChatModel,
    //    //    apiKey: OpenAIOption.Key,
    //    //    endpoint: new Uri(OpenAIOption.Endpoint));

    //    _kernel = builder.Build();
    //    AskText = " ";
    //    ResponseText = " ";
    //    SelectedLanguage = " ";
    //    Languages = new string[] { "中文","英文"};
    //}

    //[RelayCommand]
    //private async Task Ask()
    //{   
    //    if(ResponseText != "")
    //    {
    //        ResponseText = "";
    //    }
    //    if(AskText == " ")
    //    {
    //        var mainWindow = (Application.Current.ApplicationLifetime as IClassicDesktopStyleApplicationLifetime)?.MainWindow;
    //        var messageWindow = new MessageWindow("输入不能为空，请检查输入是否为空！！");
    //        messageWindow.ShowDialog(mainWindow);

    //    }
    //    else
    //    {
    //        await foreach (var update in _kernel.InvokePromptStreamingAsync(AskText))
    //        {
    //            ResponseText += update.ToString();
    //        }
    //    }     
    //}

    //[RelayCommand]
    //private async Task Translate()
    //{
    //    string skPrompt =   """
    //                        {{$input}}

    //                        将上面的输入翻译成{{$language}}，无需任何其他内容
    //                        """;
    
    //    if (ResponseText != "")
    //    {
    //        ResponseText = "";
    //    }
    //    await foreach (var update in _kernel.InvokePromptStreamingAsync(skPrompt, new() { ["input"] = AskText,["language"] = SelectedLanguage }))
    //    {
    //        ResponseText += update.ToString();
    //    }
    //}
}
