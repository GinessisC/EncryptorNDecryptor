﻿using EncryptorNDecryptor.Pages.TextEncryption.ViewModels;
using Microsoft.Extensions.Logging;

namespace EncryptorNDecryptor;

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
		builder.Services.AddSingleton<AlgorithmSettingsViewModel>();
		
		return builder.Build();
	}
}