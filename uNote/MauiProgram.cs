using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using uNote.Interfaces;
using uNote.Services;
using uNote.ViewModels;
using uNote.Views;

namespace uNote;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.UseMauiCommunityToolkit()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

#if DEBUG
		builder.Logging.AddDebug();
#endif

		// SERVICES
		builder.Services.AddSingleton<INoteService, NoteService>();
		builder.Services.AddSingleton<IUserService, UserService>();

		// APP SHELL
		builder.Services.AddSingleton<AppShell>();

		// VIEWS
		builder.Services.AddSingleton<HomeView>();
		builder.Services.AddTransient<NotesView>();
		builder.Services.AddTransient<NotePageView>();
		builder.Services.AddTransient<RegisterView>();

		// VIEWMODELS
		builder.Services.AddSingleton<HomeViewModel>();
		builder.Services.AddTransient<NotesViewModel>();
		builder.Services.AddTransient<NotePageViewModel>();
		builder.Services.AddTransient<RegisterViewModel>();

		return builder.Build();
	}
}
