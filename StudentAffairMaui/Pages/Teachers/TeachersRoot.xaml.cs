using StudentAffairMaui.ViewModels;
namespace StudentAffairMaui;

public partial class TeachersRoot : ContentPage
{
    private TeachersRootViewModel _teachersModel;
    public TeachersRoot(TeachersRootViewModel teachersModel)
    {
        InitializeComponent();
        this.BindingContext = teachersModel;
        _teachersModel = teachersModel;
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();
        _teachersModel.GetTeachersCommand.Execute(null);
    }
}