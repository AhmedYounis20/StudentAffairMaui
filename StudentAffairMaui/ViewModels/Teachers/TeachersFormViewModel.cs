using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;

namespace StudentAffairMaui.ViewModels;

public partial class TeachersFormViewModel : BaseSettingsFormViewModel<Teacher>
{
    private readonly ITeachersService _teachersService;
    public TeachersFormViewModel(ITeachersService teachersService) :base(teachersService) => _teachersService= teachersService;

    [ObservableProperty]
    private string _name;
    [ObservableProperty]
    private string _phone;
    [ObservableProperty]
    private DateTime _birthdate;
    public override async Task AddEntity()
    {
        if (Internet.CheckInternet())
        {
            try
            {
                
                Teacher teacher = await _teachersService.Create(new Teacher
                {
                    Name = Name,
                    Phone = Phone,
                    Birthdate = Birthdate,
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
    public async Task AddTeacher()=> await AddEntity();
    [ICommand]
    public new async Task OnCancel() =>await base.Cancel();
    
}
