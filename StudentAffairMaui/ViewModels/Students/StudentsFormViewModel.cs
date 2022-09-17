using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;

namespace StudentAffairMaui.ViewModels;

public partial class StudentsFormViewModel : BaseSettingsFormViewModel<Student>
{
    private readonly IStudentsService _studentsService;
    public StudentsFormViewModel(IStudentsService studentsService) :base(studentsService)=> _studentsService = studentsService;

    [ObservableProperty]
    private string _name;
    [ObservableProperty]
    private string _phone;
    [ObservableProperty]
    private DateTime _birthdate;
    [ObservableProperty]
    private string _imagePath;

    public override async Task AddEntity()
    {
        if (Internet.CheckInternet())
        {
            try
            {
                
                Student student = await _studentsService.Create(new Student
                {
                    Name = Name,
                    Phone = Phone,
                    Birthdate = Birthdate,
                    ImagePath = ImagePath
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
    public async Task AddStudent()=> await AddEntity();
    [ICommand]
    public new async Task OnCancel() =>await base.Cancel();
    
}
