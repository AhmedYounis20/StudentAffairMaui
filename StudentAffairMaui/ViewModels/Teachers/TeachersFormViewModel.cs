using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;

namespace StudentAffairMaui.ViewModels;
[QueryProperty(nameof(TeacherDetails), "EntityDetails")]
[QueryProperty(nameof(Operation), "Operation")]
public partial class TeachersFormViewModel : BaseSettingsFormViewModel<Teacher>
{
    private readonly ITeachersService _teachersService;
    public TeachersFormViewModel(ITeachersService teachersService) :base(teachersService) => _teachersService= teachersService;
    [ObservableProperty]
    private Teacher _teacherDetails;
    [ObservableProperty]
    protected string _operation = "Add";
    public override async Task AddEntity()
    {
        if (Internet.CheckInternet())
        {
            try
            {
                
                Teacher teacher = await _teachersService.Create(new Teacher
                {
                    Name = TeacherDetails.Name,
                    Phone = TeacherDetails.Phone,
                    Birthdate = TeacherDetails.Birthdate,
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
        await Cancel();
    }

    [ICommand]
    public async Task SubmitForm()
    {
        if (Operation == "Add")
            await AddEntity();
        if (Operation == "Update")
            await base.UpdateEntity(TeacherDetails);
        if (Operation == "Details")
            await base.Cancel();
    }
    [ICommand]
    public new async Task OnCancel() =>await base.Cancel();
}
