namespace uNote.Views;

public partial class NenhumView : ContentPage
{
    public NenhumView()
    {
        InitializeComponent();
    }

    public async void BackButton_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}