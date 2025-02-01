using CommunityToolkit.Mvvm.Input;

using LibSvnSharp.Demo.Services;

using System;

namespace LibSvnSharp.Demo.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    private RelayCommand _testConnection;
    public RelayCommand TestConnection => _testConnection ??= new RelayCommand(OnTestConnection);

    private void OnTestConnection()
    {
        var service = new SVNService();
        service.Connect();
    }
}