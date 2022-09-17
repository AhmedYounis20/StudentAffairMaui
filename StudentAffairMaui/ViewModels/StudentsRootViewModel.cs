using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
namespace StudentAffairMaui.ViewModels;

public partial class StudentsRootViewModel: ObservableObject
{
    [ICommand]
    public async void AddStudent()
    {
        await AppShell.Current.GoToAsync(nameof(StudentsForm));
    }
}
