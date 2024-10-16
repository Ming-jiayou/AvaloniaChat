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
}
