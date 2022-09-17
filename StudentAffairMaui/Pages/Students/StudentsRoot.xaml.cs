using StudentAffairMaui.ViewModels;
namespace StudentAffairMaui;

public partial class StudentsRoot : ContentPage
{
	public StudentsRoot(StudentsRootViewModel studentsViewModel)
	{
		try
		{
		this.BindingContext = studentsViewModel;
		}
        catch (Exception ex)
		{
			DisplayAlert("error", ex.Message,"Ok");
		}
        InitializeComponent();
	}
} 