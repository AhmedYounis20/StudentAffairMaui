using StudentAffairMaui.ViewModels;

namespace StudentAffairMaui;

public partial class TeachersForm : ContentPage
{
	public TeachersForm(TeachersFormViewModel viewModel)
	{
		InitializeComponent();
		this.BindingContext = viewModel;
	}
}