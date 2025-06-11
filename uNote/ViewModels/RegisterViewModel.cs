using System.ComponentModel;
using System.Windows.Input;
using uNote.Interfaces;
using uNote.Models;

namespace uNote.ViewModels;

public class RegisterViewModel : INotifyPropertyChanged
{
    private IUserService service;
    private string username;
    private string email;
    private string password;

    public RegisterViewModel(IUserService service)
    {
        this.service = service;

        SaveUserCommand = new Command(SaveUser);
        // DeleteUserCommand = new Command(DeleteUser);
    }

    public ICommand SaveUserCommand { get; set; }
    
    public ICommand DeleteUserCommand { get; set; }

    public string Username
    {
        get => username;
        set
        {
            if (username == value)
            {
                return;
            }

            username = value;
            OnPropertyChanged(nameof(Username));
        }
    }

    public string Email
    {
        get => email;
        set
        {
            if (email == value)
            {
                return;
            }

            email = value;
            OnPropertyChanged(nameof(Email));
        }
    }

    public string Password
    {
        get => password;
        set
        {
            if (password == value)
            {
                return;
            }

            password = value;
            OnPropertyChanged(nameof(Password));
        }
    }

#pragma warning disable CS0108 // O membro oculta o membro herdado; nova palavra-chave ausente
    public event PropertyChangedEventHandler? PropertyChanged;
#pragma warning restore CS0108 // O membro oculta o membro herdado; nova palavra-chave ausente

    protected void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    private async void SaveUser()
    {
        await service.Initialize();

        await service.SaveUserAsync(new User
        {
            Username = Username,
            Email = Email,
            Password = Password,
        });

        Console.WriteLine("Test passed.");
    }

    private async void DeleteUser(User user)
    {
        var res = await Shell.Current.DisplayAlert("Delete", "Confirm delete?", "Yes", "No");

        if (res is true)
        {
            try
            {
                await service.Initialize();
                await service.DeleteUserAsync(user);
                // await LoadUsers();
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", ex.Message, "OK");
            }
        }
    }
}