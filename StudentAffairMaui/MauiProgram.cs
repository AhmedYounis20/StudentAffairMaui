﻿using StudentAffairMaui.ViewModels;

namespace StudentAffairMaui;

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
		builder.Services.AddScoped(e => new HttpClient { BaseAddress= new Uri("https://084a-156-221-115-8.ngrok-free.app") });

		// Services
        builder.Services.AddSingleton<ITeachersService, TeachersService>();
        builder.Services.AddSingleton<IStudentsService, StudentsService>();
        builder.Services.AddSingleton<IClassRoomsService, ClassRoomsService>();

        // views ==> Pages
        builder.Services.AddSingleton<StudentsRoot>();
        builder.Services.AddTransient<StudentsForm>();

        builder.Services.AddSingleton<TeachersRoot>();
        builder.Services.AddTransient<TeachersForm>();

        builder.Services.AddSingleton<ClassRoomsRoot>();
        builder.Services.AddTransient<ClassRoomsForm>();
        // view Model 
        builder.Services.AddSingleton<StudentsRootViewModel>();
        builder.Services.AddTransient<StudentsFormViewModel>();

        builder.Services.AddSingleton<TeachersRootViewModel>();
        builder.Services.AddTransient<TeachersFormViewModel>();

        builder.Services.AddSingleton<ClassRoomsRootViewModel>();
        builder.Services.AddTransient<ClassRoomsFormViewModel>();

        return builder.Build();
	}
}
