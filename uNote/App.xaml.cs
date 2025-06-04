using uNote.Views;

namespace uNote;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		Shell.SetNavBarIsVisible(this, false);
	}

	protected override Window CreateWindow(IActivationState? activationState)
	{
		return new Window(new HomeView());
	}
}