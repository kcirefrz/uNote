using System.ComponentModel;
using System.Windows.Input;
using uNote.Interfaces;
using uNote.Models;

namespace uNote.ViewModels;

public class RegisterViewModel : INotifyPropertyChanged
{
    private IUserService service;
    private string user;
    private string email;
    private string password;
    private List<User> users;

    public RegisterViewModel(IUserService service)
    {
        this.service = service;

        SaveUserCommand = new Command(SaveUser);
        DisplayUsersCommand = new Command(DisplayUsers);
        // DeleteUserCommand = new Command(DeleteUser);

        Users = new List<User>();
        service.GetAllUsersAsync();
    }

    public ICommand SaveUserCommand { get; set; }

    public ICommand DeleteUserCommand { get; set; }

    public ICommand DisplayUsersCommand { get; set; }

    public string User
    {
        get => user;
        set
        {
            if (user == value)
            {
                return;
            }

            user = value;
            OnPropertyChanged(nameof(User));
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

    public List<User> Users
    {
        get => users;
        set
        {
            if (users == value)
            {
                return;
            }

            users = value;
            OnPropertyChanged(nameof(Users));
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
            Username = User,
            Email = Email,
            Password = Password,
        });

        await Refresh(service);
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

    private async void DisplayUsers()
    {
        await service.Initialize();

        await Refresh(service);
    }

    private async Task Refresh(IUserService service)
    {
        Users = await service.GetAllUsersAsync();
    }
}