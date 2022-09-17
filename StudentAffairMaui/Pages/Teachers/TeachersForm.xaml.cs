using StudentAffairMaui.ViewModels;

namespace StudentAffairMaui;

public partial class TeachersForm : ContentPage
{
	public TeachersForm(StudentsFormViewModel viewModel)
	{
		InitializeComponent();
		this.BindingContext = viewModel;
	}
}