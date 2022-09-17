using StudentAffairMaui.ViewModels;

namespace StudentAffairMaui;

public partial class ClassRoomsForm : ContentPage
{
	public ClassRoomsForm(ClassRoomsFormViewModel viewModel)
	{
		InitializeComponent();
		this.BindingContext = viewModel;
	}
}