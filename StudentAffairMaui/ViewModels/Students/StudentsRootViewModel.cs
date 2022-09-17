using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace StudentAffairMaui.ViewModels;

public partial class StudentsRootViewModel : BaseRootsViewModel<Student, StudentsForm>
{
   
    public StudentsRootViewModel(IStudentsService studentsService) : base(studentsService)
    {
    }
    [ICommand]
    public void GetStudents() => base.GetEntities();

    [ICommand]
    public async Task AddStudent() => await base.AddEntity();
}
