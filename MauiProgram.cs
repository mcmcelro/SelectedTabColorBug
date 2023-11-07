using Microsoft.Extensions.Logging;

using SelectedTabColorBug.Handlers.PlatformImplementations;

namespace SelectedTabColorBug;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

#if DEBUG
		builder.Logging.AddDebug();
#endif

		builder.ConfigureMauiHandlers((handlers) =>
		{
			handlers.AddHandler<MainPage, MainPageHandler>();
		});

		return builder.Build();
	}
}