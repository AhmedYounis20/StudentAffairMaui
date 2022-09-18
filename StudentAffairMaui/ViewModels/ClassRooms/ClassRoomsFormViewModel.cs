using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Net.Http.Json;

namespace StudentAffairMaui.ViewModels;
[QueryProperty(nameof(ClassRoomDetails), "EntityDetails")]
[QueryProperty(nameof(Operation), "Operation")]
public partial class ClassRoomsFormViewModel : BaseSettingsFormViewModel<ClassRoom>
{
    private readonly IClassRoomsService _classRoomsService;
    private readonly ITeachersService _teachersService;
    public ObservableCollection<Teacher> Teachers { get; set; } = new ObservableCollection<Teacher>();
    public ObservableCollection<Subject> Subjects { get; set; } = new ObservableCollection<Subject>();
    private HttpClient _httpClient;

    [ObservableProperty]
    private ClassRoom _classRoomDetails;
    [ObservableProperty]
    private string _operation="Add";
    [ObservableProperty]
    private Subject _selectedSubject; 
    [ObservableProperty]
    private Teacher _selectedTeacher;


    public ClassRoomsFormViewModel(IClassRoomsService classRoomsService,ITeachersService teachersService,HttpClient httpClient) : base(classRoomsService) {
        _classRoomsService= classRoomsService;
        _teachersService = teachersService;
        _httpClient = httpClient;
    }

    public async Task<ObservableCollection<Teacher>> GetTeachers()
    {
        List<Teacher> teachers = await _teachersService.Get();
        foreach (Teacher t in teachers)
            Teachers.Add(t);
        return Teachers;
    }
    public async Task<ObservableCollection<Subject>> GetSubjects()
    {
        List<Subject> subjects = await _httpClient.GetFromJsonAsync<List<Subject>>("api/Subject");
        foreach (Subject t in subjects)
            Subjects.Add(t);
        return Subjects;
    }
    public override async Task AddEntity()
    {
        if (Internet.CheckInternet())
        {
            try
            {
                if (SelectedSubject.Id != Guid.Empty && ClassRoomDetails.SubjectId == Guid.Empty)
                    ClassRoomDetails.SubjectId = SelectedSubject.Id; 
                if (SelectedTeacher.Id != Guid.Empty && ClassRoomDetails.TeacherId == Guid.Empty)
                    ClassRoomDetails.TeacherId = SelectedTeacher.Id;
                ClassRoom student = await _classRoomsService.Create(new ClassRoom
                {
                    Name = ClassRoomDetails.Name,
                    TeacherId= ClassRoomDetails.SubjectId,
                    SubjectId= ClassRoomDetails.TeacherId
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
        {
            ClassRoomDetails.TeacherId = SelectedTeacher.Id;
            ClassRoomDetails.SubjectId = SelectedSubject.Id;
            await base.UpdateEntity(ClassRoomDetails);
        }
        if (Operation == "Details")
        {
            await base.Cancel();
        }
    }
    [ICommand]
    public async Task OnCancel() =>await base.Cancel();
    
}
