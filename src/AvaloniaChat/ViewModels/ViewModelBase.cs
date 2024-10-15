using CommunityToolkit.Mvvm.ComponentModel;
using ReactiveUI;
using System;

namespace AvaloniaChat.ViewModels;

public class ViewModelBase : ReactiveObject, IDisposable
{
    public virtual void Dispose()
    {

    }
}
