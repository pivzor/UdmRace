using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Linq;
using UdmurtRace.DAL;
using UdmurtRace.Domain.Entities;
using UdmurtRace.ViewModels.Clients;
using UdmurtRace.Views.Clients;

namespace UdmurtRaceAvalonia.ViewModels.Clients
{
    public partial class ClientsViewModel : ObservableObject
    {
        private readonly AppDbContext _context = new();

        [ObservableProperty]
        private ObservableCollection<ClientEntity> clients;

        [ObservableProperty]
        private ClientEntity selectedClient;

        public ClientsViewModel()
        {
            LoadClients();
        }

        private void LoadClients()
        {
            Clients = new ObservableCollection<ClientEntity>(_context.Clients.ToList());
        }

        [RelayCommand]
        private async void AddClient()
        {
            var vm = new AddEditClientViewModel();
            var window = new AddEditClientView { DataContext = vm };
            await window.ShowDialog(App.Current?.ApplicationLifetime as IClassicDesktopStyleApplicationLifetime);

            if (vm.IsSaved)
            {
                _context.Clients.Add(vm.Client);
                _context.SaveChanges();
                LoadClients();
            }
        }

        [RelayCommand]
        private async void EditClient()
        {
            if (SelectedClient == null) return;

            var vm = new AddEditClientViewModel(SelectedClient);
            var window = new AddEditClientView { DataContext = vm };
            await window.ShowDialog(App.Current?.ApplicationLifetime as IClassicDesktopStyleApplicationLifetime);

            if (vm.IsSaved)
            {
                _context.Clients.Update(vm.Client);
                _context.SaveChanges();
                LoadClients();
            }
        }

        [RelayCommand]
        private void DeleteClient()
        {
            if (SelectedClient == null) return;
            _context.Clients.Remove(SelectedClient);
            _context.SaveChanges();
            LoadClients();
        }
    }
}
