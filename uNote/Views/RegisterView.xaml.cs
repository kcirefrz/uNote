using uNote.Interfaces;
using uNote.ViewModels;

namespace uNote.Views;

public partial class RegisterView : ContentPage
{
    private IUserService service;
    private int editUserId;

    public RegisterView(IUserService service)
    {
        InitializeComponent();
        this.service = service;
        
        BindingContext = new RegisterViewModel(service);
    }

    private void Username_Focused(object sender, FocusEventArgs e)
    {
        EmailBorder.Stroke = Color.FromArgb("#CCCCCC");
        PasswordBorder.Stroke = Color.FromArgb("#CCCCCC");
        UsernameBorder.Stroke = Color.FromArgb("#bdd6d2");
    }

    private void Email_Focused(object sender, FocusEventArgs e)
    {
        UsernameBorder.Stroke = Color.FromArgb("#CCCCCC");
        PasswordBorder.Stroke = Color.FromArgb("#CCCCCC");
        EmailBorder.Stroke = Color.FromArgb("#bdd6d2");
    }

    private void Password_Focused(object sender, FocusEventArgs e)
    {
        UsernameBorder.Stroke = Color.FromArgb("#CCCCCC");
        EmailBorder.Stroke = Color.FromArgb("#CCCCCC");
        PasswordBorder.Stroke = Color.FromArgb("#bdd6d2");
    }

    private async void SaveButton_Clicked(object? sender, EventArgs e)
    {
        // if (editUserId == 0)
        // {
        //     // Add User
        //     await service.SaveAsync(new User
        //     {
        //         Username = UsernameEntry.Text,
        //         Email = EmailEntry.Text,
        //         Password = PasswordEntry.Text,
        //     });
        // }
        // else
        // {
        //     // Edit User
        //     await service.SaveAsync(new User
        //     {
        //         UserId = editUserId,
        //         Username = UsernameEntry.Text,
        //         Email = EmailEntry.Text,
        //         Password = PasswordEntry.Text,
        //     });
        // }

        UsernameEntry.Text = string.Empty;
        EmailEntry.Text = string.Empty;
        PasswordEntry.Text = string.Empty;
    }
}