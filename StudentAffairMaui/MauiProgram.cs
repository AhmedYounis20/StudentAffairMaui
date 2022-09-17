using StudentAffairMaui.ViewModels;

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
		builder.Services.AddScoped(e => new HttpClient());

		// Services
        builder.Services.AddSingleton<ITeachersService, TeachersService>();
        builder.Services.AddSingleton<IStudentsService, StudentsService>();
        builder.Services.AddSingleton<IClassRoomsService, ClassRoomsService>();

        // views ==> Pages
        builder.Services.AddSingleton<StudentsRoot>();
        builder.Services.AddTransient<StudentsForm>();

        builder.Services.AddSingleton<TeachersRoot>();
        builder.Services.AddTransient<TeachersForm>();

        //builder.Services.AddSingleton<ClassRoomsRoot>();
        //builder.Services.AddTransient<ClassRoomsForm>();  
        // view Model 
        builder.Services.AddSingleton<StudentsRootViewModel>();
        builder.Services.AddTransient<StudentsFormViewModel>();

        return builder.Build();
	}
}
