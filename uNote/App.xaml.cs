using uNote.Interfaces;
using uNote.Views;

namespace uNote;

public partial class App : Application
{
	public App(INoteService service)
	{
		InitializeComponent();
		MainPage = new NavigationPage(new HomeView(service));

		Shell.SetNavBarIsVisible(this, false);
	}
}