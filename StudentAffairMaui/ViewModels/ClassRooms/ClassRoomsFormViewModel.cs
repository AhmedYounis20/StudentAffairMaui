using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;

namespace StudentAffairMaui.ViewModels;

public partial class ClassRoomsFormViewModel : BaseSettingsFormViewModel<ClassRoom>
{
    private readonly IClassRoomsService _classRoomsService;
    public ClassRoomsFormViewModel(IClassRoomsService classRoomsService) :base(classRoomsService) => _classRoomsService= classRoomsService;

    [ObservableProperty]
    private string _name;
    [ObservableProperty]
    private Guid _subjectId;
    [ObservableProperty]
    private Guid _teacherId;
    public override async Task AddEntity()
    {
        if (Internet.CheckInternet())
        {
            try
            {
                
                ClassRoom student = await _classRoomsService.Create(new ClassRoom
                {
                    Name = Name,
                    TeacherId=TeacherId,
                    SubjectId=SubjectId
                });
                await Shell.Current.DisplayAlert("Seccessed", "Record Saved", "Ok");
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", ex.Message, "Ok");
            }
        }
        else 
            await Shell.Current.DisplayAlert("Netowk Falid", "Please Check Your Wifi or Mobile Data.", "Ok");
        await Shell.Current.DisplayAlert("Netowk Falid", Connectivity.Current.NetworkAccess.ToString(), "Ok");
        await Cancel();
    }
    [ICommand]
    public async Task AddClassRoom()=> await AddEntity();
    [ICommand]
    public async Task OnCancel() =>await base.Cancel();
    
}
