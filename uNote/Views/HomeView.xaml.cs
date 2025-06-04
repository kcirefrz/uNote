using System.ComponentModel;
using System.Diagnostics;
using System.Threading.Tasks;

namespace uNote.Views;

public partial class HomeView : FlyoutPage
{
    public HomeView()
    {
        InitializeComponent();

        UsernameEntry.PropertyChanged += UserEntries_PropertyChanged;
        PasswordEntry.PropertyChanged += UserEntries_PropertyChanged;
    }

    private void LoginButton_Clicked(object sender, EventArgs e)
    {
        UsernameBorder.Stroke = Color.FromArgb("#CCCCCC");
        PasswordBorder.Stroke = Color.FromArgb("#CCCCCC");

        Application.Current.MainPage = new NotesView();
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
