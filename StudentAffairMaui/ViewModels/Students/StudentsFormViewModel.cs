using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;

namespace StudentAffairMaui.ViewModels;
[QueryProperty(nameof(StudentDetails), "EntityDetails")]
[QueryProperty(nameof(Operation), "Operation")]
public partial class StudentsFormViewModel : BaseSettingsFormViewModel<Student>
{
    private readonly IStudentsService _studentsService;
    [ObservableProperty]
    private Student _studentDetails;
    [ObservableProperty]
    protected string _operation = "Add";
    public StudentsFormViewModel(IStudentsService studentsService) : base(studentsService)
    {
        _studentsService = studentsService;
        Shell.Current.DisplayAlert("error", Operation, "cancel");
    }
    public override async Task AddEntity()
    {
        if (Internet.CheckInternet())
        {
            try
            {

                Student student = await _studentsService.Create(new Student
                {
                    Name = StudentDetails.Name,
                    Phone = StudentDetails.Phone,
                    Birthdate = StudentDetails.Birthdate,
                    ImagePath = StudentDetails.ImagePath
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
            await base.UpdateEntity(StudentDetails);
        if (Operation == "Details")
            await base.Cancel();
    }
    [ICommand]
    public new async Task OnCancel() => await base.Cancel();

}
