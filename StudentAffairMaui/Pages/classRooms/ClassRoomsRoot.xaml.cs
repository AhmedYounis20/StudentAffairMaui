using StudentAffairMaui.ViewModels;
namespace StudentAffairMaui;

public partial class ClassRoomsRoot : ContentPage
{
    private ClassRoomsRootViewModel _classRoomsModel;
    public ClassRoomsRoot(ClassRoomsRootViewModel classRoomsModel)
    {
        InitializeComponent();
        this.BindingContext = classRoomsModel;
        _classRoomsModel = classRoomsModel;
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();
        _classRoomsModel.GetClassRoomsCommand.Execute(null);
    }
}