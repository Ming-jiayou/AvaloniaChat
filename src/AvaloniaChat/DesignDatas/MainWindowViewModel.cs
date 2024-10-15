using AvaloniaChat.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Avalonia;
using Microsoft.Extensions.DependencyInjection;
namespace AvaloniaChat.DesignDatas
{
    public static class DesignData
    {
        public static MainViewModel MainWindowViewModel { get; } =
            ((AppWithDI)Application.Current!).AppServiceProvider!.GetRequiredService<MainViewModel>();
    }
}
