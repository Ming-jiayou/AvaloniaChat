using AvaloniaChat.ViewModels;
using CommunityToolkit.Mvvm.ComponentModel;
using Lemon.ModuleNavigation.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SemanticKernel;
using AvaloniaChat.Model;
using AvaloniaChat.Common.Options;
using System.Net.Http;
using CommunityToolkit.Mvvm.Input;
using Avalonia;

namespace AvaloniaChat.Modules
{
    public partial class ContrastiveTranslationViewModel : ObservableObject, IViewModel
    {
        private Kernel _kernel;

        [ObservableProperty]
        private string askText;

        [ObservableProperty]
        private string responseText;

        [ObservableProperty]
        private string selectedLanguage;

        public string[] Languages { get; set; }

        public ContrastiveTranslationViewModel()
        {
            var handler = new OpenAIHttpClientHandler();
            var builder = Kernel.CreateBuilder()
            .AddOpenAIChatCompletion(
               modelId: OpenAIOption.ChatModel,
               apiKey: OpenAIOption.Key,
               httpClient: new HttpClient(handler));
            //var builder = Kernel.CreateBuilder()
            //.AddOpenAIChatCompletion(
            //    modelId: OpenAIOption.ChatModel,
            //    apiKey: OpenAIOption.Key,
            //    endpoint: new Uri(OpenAIOption.Endpoint));

            _kernel = builder.Build();
            AskText = " ";
            ResponseText = " ";
            SelectedLanguage = " ";
            Languages = new string[] { "中文", "英文" };
        }

        [RelayCommand]
        private async Task Ask()
        {
            if (ResponseText != "")
            {
                ResponseText = "";
            }
            if (AskText == " ")
            {
                //var mainWindow = (Application.Current.ApplicationLifetime as IClassicDesktopStyleApplicationLifetime)?.MainWindow;
                //var messageWindow = new MessageWindow("输入不能为空，请检查输入是否为空！！");
                //messageWindow.ShowDialog(mainWindow);

            }
            else
            {
                await foreach (var update in _kernel.InvokePromptStreamingAsync(AskText))
                {
                    ResponseText += update.ToString();
                }
            }
        }

        [RelayCommand]
        private async Task Translate()
        {
            string skPrompt = """
                                {{$input}}

                                将上面的输入翻译成{{$language}}，无需任何其他内容
                                """;

            if (ResponseText != "")
            {
                ResponseText = "";
            }
            await foreach (var update in _kernel.InvokePromptStreamingAsync(skPrompt, new() { ["input"] = AskText, ["language"] = SelectedLanguage }))
            {
                ResponseText += update.ToString();
            }
        }

        public virtual void Dispose()
        {

        }
    }
}
