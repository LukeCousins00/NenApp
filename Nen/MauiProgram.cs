using Microsoft.Extensions.Logging;
using Nen.Pages;
using Nen.ViewModels;

namespace Nen;

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

		builder.Services.AddTransient<LoginViewModel>();
		builder.Services.AddTransient<LoginPage>((s) => new LoginPage()
		{
			BindingContext = s.GetService<LoginViewModel>()
		});

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
