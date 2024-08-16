using AvaloniaChat.Common.Options;
using AvaloniaChat.Model;
using Azure;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.SemanticKernel;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;

namespace AvaloniaChat.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    private Kernel _kernel;

    [ObservableProperty]
    private string askText;

    [ObservableProperty]
    private string responseText;

    [ObservableProperty]
    private string selectedLanguage;

    public string[] Languages { get; set; }

    public MainViewModel()
    {        
        var handler = new OpenAIHttpClientHandler();
        var builder = Kernel.CreateBuilder()
        .AddOpenAIChatCompletion(
           modelId: OpenAIOption.ChatModel,
           apiKey: OpenAIOption.Key,
           httpClient: new HttpClient(handler));
        _kernel = builder.Build();
        AskText = " ";
        ResponseText = " ";
        SelectedLanguage = " ";
        Languages = new string[] { "中文","英文"};
    }

    [RelayCommand]
    private async Task Ask()
    {   
        if(ResponseText != "")
        {
            ResponseText = "";
        }
        await foreach (var update in _kernel.InvokePromptStreamingAsync(AskText))
        {
            ResponseText += update.ToString();         
        }     
    }

    [RelayCommand]
    private async Task Translate()
    {
        string skPrompt =   """
                            {{$input}}

                            将上面的输入翻译成{{$language}}，无需任何其他内容
                            """;
    
        if (ResponseText != "")
        {
            ResponseText = "";
        }
        await foreach (var update in _kernel.InvokePromptStreamingAsync(skPrompt, new() { ["input"] = AskText,["language"] = SelectedLanguage }))
        {
            ResponseText += update.ToString();
        }
    }
}
