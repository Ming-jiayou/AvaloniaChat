using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using AvaloniaChat.Modules;
using AvaloniaChat.ViewModels;
using AvaloniaChat.Views;
using Microsoft.Extensions.DependencyInjection;
using System;
using Lemon.ModuleNavigation;
using Microsoft.Extensions.Configuration;
using AvaloniaChat.Common.Options;

namespace AvaloniaChat;

public partial class AppWithDI : Application
{
    private IServiceProvider? _serviceProvider;

    public IServiceProvider? AppServiceProvider
    {
        get
        {
            return _serviceProvider;
        }
    }

    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        var services = new ServiceCollection();
        // 创建配置构建器
        var builder = new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

        // 构建配置
        IConfiguration configuration = builder.Build();

        // 直接从配置中读取复杂类型
        OpenAIOption openAIOption = configuration.GetSection("OpenAI").Get<OpenAIOption>();

        // 注册配置对象到依赖注入容器
        services.AddSingleton(openAIOption);

        services.AddNavigationContext()
                .AddModule<ContrastiveTranslationModule>()               
                .AddSingleton<MainWindow>()
                .AddSingleton<MainView>()
                .AddSingleton<MainViewModel>();

        _serviceProvider = services.BuildServiceProvider();

        var viewModel = _serviceProvider.GetRequiredService<MainViewModel>();

        switch (ApplicationLifetime)
        {
            case IClassicDesktopStyleApplicationLifetime desktop:
                var window = _serviceProvider.GetRequiredService<MainWindow>();
                window.DataContext = viewModel;
                desktop.MainWindow = window;
                break;
            case ISingleViewApplicationLifetime singleView:
                var view = _serviceProvider.GetRequiredService<MainView>();
                view.DataContext = viewModel;
                singleView.MainView = view;
                break;
        }
        base.OnFrameworkInitializationCompleted();
    } 
}