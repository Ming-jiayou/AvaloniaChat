using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Data.Core.Plugins;
using System;
using Avalonia.Markup.Xaml;
using AvaloniaChat.ViewModels;
using AvaloniaChat.Views;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using AvaloniaChat.Common.Options;


namespace AvaloniaChat;

public partial class App : Application
{
    public IServiceProvider ServiceProvider { get; private set; }

    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    //private void ConfigureServices(IServiceCollection services)
    //{
    //    // 创建配置构建器
    //    var builder = new ConfigurationBuilder()
    //        .SetBasePath(AppContext.BaseDirectory)
    //        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

    //    // 构建配置
    //    IConfiguration configuration = builder.Build();

    //    // 直接从配置中读取复杂类型
    //    OpenAIOption openAIOption = configuration.GetSection("OpenAI").Get<OpenAIOption>();

    //    // 注册配置对象到依赖注入容器
    //    services.AddSingleton(openAIOption);

    //    // 注册其他服务和窗口
    //    services.AddSingleton<MainWindow>();
    //    services.AddSingleton<MainViewModel>();
    //}

    //public override void OnFrameworkInitializationCompleted()
    //{
    //    // Line below is needed to remove Avalonia data validation.
    //    // Without this line you will get duplicate validations from both Avalonia and CT
    //    BindingPlugins.DataValidators.RemoveAt(0);

    //    if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
    //    {
    //        //desktop.MainWindow = new MainWindow
    //        //{
    //        //    DataContext = new MainViewModel()
    //        //};
    //        var serviceCollection = new ServiceCollection();
    //        ConfigureServices(serviceCollection);
    //        ServiceProvider = serviceCollection.BuildServiceProvider();

    //         desktop.MainWindow = ServiceProvider.GetRequiredService<MainWindow>();
            

    //    }
    //    else if (ApplicationLifetime is ISingleViewApplicationLifetime singleViewPlatform)
    //    {
    //        singleViewPlatform.MainView = new MainView
    //        {
    //            DataContext = new MainViewModel()
    //        };
    //    }

    //    base.OnFrameworkInitializationCompleted();
    //}
}
