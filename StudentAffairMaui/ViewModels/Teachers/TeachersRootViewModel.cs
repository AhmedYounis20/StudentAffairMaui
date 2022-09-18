using Microsoft.Toolkit.Mvvm.Input;

namespace StudentAffairMaui.ViewModels;

public partial class TeachersRootViewModel : BaseSettingsRootViewModel<Teacher, TeachersForm>
{

    public TeachersRootViewModel(ITeachersService teachersService) : base(teachersService)
    {
    }
    [ICommand]
    public void GetTeachers() => base.GetEntities();

    [ICommand]
    public async Task AddTeacher() => await base.AddEntity();
   
    [ICommand]
    public async Task Operations(Teacher teahcer) => await base.DisplayOptions(teahcer);

}
