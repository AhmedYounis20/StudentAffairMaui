namespace StudentAffairMaui;

public partial class AppShell : Shell
{
	public AppShell()
	{
        Routing.RegisterRoute(nameof(StudentsForm), typeof(StudentsForm));
        Routing.RegisterRoute(nameof(TeachersForm), typeof(TeachersForm));
        Routing.RegisterRoute(nameof(ClassRoomsForm), typeof(ClassRoomsForm));
        InitializeComponent();
	}
}
