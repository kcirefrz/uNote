namespace uNote.Views;

public partial class NotesView : FlyoutPage
{
    public NotesView()
    {
        InitializeComponent();
    }

    private void BackButton_Clicked(object sender, EventArgs e)
    {
        Application.Current.MainPage = new HomeView();
    }
}