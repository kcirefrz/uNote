using uNote.Interfaces;
using uNote.ViewModels;

namespace uNote.Views;

public partial class DataView : ContentPage
{
    private IUserService service;
    private RegisterViewModel viewModel;

    public DataView(IUserService service)
    {
        InitializeComponent();
        this.service = service;

        viewModel = new RegisterViewModel(service);
        BindingContext = viewModel;

        viewModel.DisplayUsersCommand.Execute(null);
    }

     private void BackButton_Clicked(object sender, EventArgs e)
    {
        Navigation.PopModalAsync();
    }
}