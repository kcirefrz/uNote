using System.ComponentModel;
using uNote.Interfaces;
using uNote.ViewModels;

namespace uNote.Views;

public partial class HomeView : ContentPage
{
    private readonly INoteService service;

    public HomeView(INoteService service)
    {
        InitializeComponent();
        this.service = service;
        BindingContext = new HomeViewModel(service);

        UsernameEntry.PropertyChanged += UserEntries_PropertyChanged;
        PasswordEntry.PropertyChanged += UserEntries_PropertyChanged;
    }

    private async void LoginButton_Clicked(object sender, EventArgs e)
    {
        UsernameBorder.Stroke = Color.FromArgb("#CCCCCC");
        PasswordBorder.Stroke = Color.FromArgb("#CCCCCC");
        UsernameEntry.Text = string.Empty;
        PasswordEntry.Text = string.Empty;

        var notesView = Handler.MauiContext.Services.GetService<NotesView>();
        await Navigation.PushModalAsync(notesView);
    }

    private async void RegisterButton_Clicked(object sender, EventArgs e)
    {
        var registerView = Handler.MauiContext.Services.GetService<RegisterView>();
        await Navigation.PushModalAsync(registerView);
    }

    private void Username_Focused(object sender, FocusEventArgs e)
    {
        PasswordBorder.Stroke = Color.FromArgb("#CCCCCC");
        UsernameBorder.Stroke = Color.FromArgb("#bdd6d2");
    }
    
    private void Password_Focused(object sender, FocusEventArgs e)
    {
        UsernameBorder.Stroke = Color.FromArgb("#CCCCCC");
        PasswordBorder.Stroke = Color.FromArgb("#bdd6d2");
    }

    private void UserEntries_PropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        LogInButton.IsEnabled =
            !string.IsNullOrWhiteSpace(UsernameEntry.Text) &&
            !string.IsNullOrWhiteSpace(PasswordEntry.Text);
    }
}
