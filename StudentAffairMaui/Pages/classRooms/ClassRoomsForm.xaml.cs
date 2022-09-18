using StudentAffairMaui.ViewModels;
using System.Collections.ObjectModel;

namespace StudentAffairMaui;

public partial class ClassRoomsForm : ContentPage
{
	ClassRoomsFormViewModel _viewModel;
	//ObservableCollection<Teacher> Teachers = new ObservableCollection<Teacher>();

    public ClassRoomsForm(ClassRoomsFormViewModel viewModel)
	{
		InitializeComponent();
		this.BindingContext = viewModel;
		_viewModel = viewModel;
	}
	protected override async void OnAppearing()
	{
		await _viewModel.GetTeachers();
		await _viewModel.GetSubjects();
		base.OnAppearing();
	}
}