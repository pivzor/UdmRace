using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using UdmurtRace.Domain.Entities;
using Avalonia.Controls;

namespace UdmurtRace.ViewModels.Clients
{
    public partial class AddEditClientViewModel : ObservableObject
    {
        [ObservableProperty] private ClientEntity client;
        [ObservableProperty] private string windowTitle;
        public bool IsSaved { get; private set; }

        public AddEditClientViewModel(ClientEntity existing = null)
        {
            if (existing == null)
            {
                Client = new ClientEntity();
                WindowTitle = "Добавить клиента";
            }
            else
            {
                Client = new ClientEntity
                {
                    ClientId = existing.ClientId,
                    SurName = existing.SurName,
                    ClientName = existing.ClientName,
                    Patronymic = existing.Patronymic,
                    Email = existing.Email,
                    Address = existing.Address,
                    Phone = existing.Phone
                };
                WindowTitle = "Редактировать клиента";
            }
        }

        [RelayCommand]
        private void Save(Window window)
        {
            IsSaved = true;
            window.Close();
        }

        [RelayCommand]
        private void Cancel(Window window)
        {
            IsSaved = false;
            window.Close();
        }
    }
}
