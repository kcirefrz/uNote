using System.ComponentModel;
using uNote.Interfaces;

namespace uNote.ViewModels;

public class HomeViewModel : INotifyPropertyChanged
{
    private readonly INoteService service;
    private string username;
    // private string email;
    private string password;

    public HomeViewModel(INoteService service)
    {
        this.service = service;
    }

#pragma warning disable CS0108 // O membro oculta o membro herdado; nova palavra-chave ausente
    public event PropertyChangedEventHandler? PropertyChanged;
#pragma warning restore CS0108 // O membro oculta o membro herdado; nova palavra-chave ausente

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

    // public string Email
    // {
    //     get => email;
    //     set
    //     {
    //         if (email == value)
    //         {
    //             return;
    //         }

    //         email = value;
    //         OnPropertyChanged(nameof(Email));
    //     }
    // }

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

    protected void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    // private async void NavigateResgisterPage()
    // {
    // }
}