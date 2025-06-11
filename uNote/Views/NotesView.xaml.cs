using uNote.Interfaces;
using uNote.ViewModels;

namespace uNote.Views;

public partial class NotesView : FlyoutPage
{
    private INoteService service;
    public NotesView(INoteService service, IUserService userService)
    {
        InitializeComponent();
        this.service = service;
        BindingContext = new NotesViewModel(service, userService);
    }

    private void BackButton_Clicked(object sender, EventArgs e)
    {
        // Application.Current.MainPage = new HomeView();
        Navigation.PopModalAsync();
    }

    private async void OptionItemActions_Clicked(object sender, EventArgs e)
    {
        
    }
}