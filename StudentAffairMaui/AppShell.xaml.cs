namespace StudentAffairMaui;

public partial class AppShell : Shell
{
	public AppShell()
	{
        Routing.RegisterRoute(nameof(StudentsForm), typeof(StudentsForm));
        InitializeComponent();
	}
}
