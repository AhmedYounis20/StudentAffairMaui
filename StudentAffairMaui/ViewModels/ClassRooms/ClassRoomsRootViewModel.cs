using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace StudentAffairMaui.ViewModels;

public partial class ClassRoomsRootViewModel : BaseSettingsRootViewModel<ClassRoom,ClassRoomsForm>
{
   
    public ClassRoomsRootViewModel(IClassRoomsService teachersService) : base(teachersService)
    {
    }
    [ICommand]
    public void GetClassRooms() => base.GetEntities();

    [ICommand]
    public async Task AddClassRoom() => await base.AddEntity();

    [ICommand]
    public async Task Operations(ClassRoom classRoom) => await base.DisplayOptions(classRoom);
}
