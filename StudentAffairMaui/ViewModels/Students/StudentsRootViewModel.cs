using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;

namespace StudentAffairMaui.ViewModels;

public partial class StudentsRootViewModel : BaseSettingsRootViewModel<Student, StudentsForm>
{
   
    public StudentsRootViewModel(IStudentsService studentsService) : base(studentsService)
    {
    }
    [ICommand]
    public void GetStudents() => base.GetEntities();

    [ICommand]
    public async Task AddStudent() => await base.AddEntity();

    [ICommand]
    public async Task Operations(Student student) => await base.DisplayOptions(student);

}
