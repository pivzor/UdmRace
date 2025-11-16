using CommunityToolkit.Mvvm.ComponentModel;
using UdmurtRace.Domain.Abstractions.Repositories;
using UdmurtRace.Domain.Entities;
using UdmurtRaceAvalonia.ViewModels.Clients;

namespace UdmurtRaceAvalonia.ViewModels
{
    public partial class MainWindowViewModel : ViewModelBase
    {
        public string Header { get; } = "Система управления рейсами";

        public ClientListViewModel ClientsVM { get; }

        public MainWindowViewModel(IClientRepository<ClientEntity> clientRepository)
        {
            ClientsVM = new ClientListViewModel(clientRepository);
        }

        public MainWindowViewModel()
        {
            ClientsVM = new ClientListViewModel();
        }
    }
}
