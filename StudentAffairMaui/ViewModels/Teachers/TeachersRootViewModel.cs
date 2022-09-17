using Microsoft.Toolkit.Mvvm.Input;

namespace StudentAffairMaui.ViewModels;

public partial class TeachersRootViewModel : BaseRootsViewModel<Teacher, TeachersForm>
{

    public TeachersRootViewModel(ITeachersService teachersService) : base(teachersService)
    {
    }
    [ICommand]
    public void GetTeachers() => base.GetEntities();

    [ICommand]
    public async Task AddTeacher() => await base.AddEntity();
}
