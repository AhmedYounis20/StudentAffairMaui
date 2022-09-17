using StudentAffairMaui.ViewModels;
namespace StudentAffairMaui;

public partial class StudentsRoot : ContentPage
{
    private StudentsRootViewModel _studentsModel;
    public StudentsRoot(StudentsRootViewModel studentsViewModel)
    {
        InitializeComponent();
        _studentsModel = studentsViewModel;
        this.BindingContext = _studentsModel;
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();
        _studentsModel.GetStudentsCommand.Execute(null);
    }
}