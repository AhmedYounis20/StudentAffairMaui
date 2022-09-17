using Microsoft.Maui.Layouts;
using System.Net.Http.Json;

namespace StudentAffairMaui;

public class StudentsService : BaseSettingService<Student>,IStudentsService
{
    HttpClient _httpClient { get; set; }
    public StudentsService(HttpClient httpClient) : base(httpClient)
    {
        _httpClient=httpClient;
    }

    //public override async Task<List<Student>> Get()
    //{
    //    List<Student> students = new List<Student>();
    //    try
    //    {
    //        students = await _httpClient.GetFromJsonAsync<List<Student>>($"https//www.sdaf.com/api/student");
    //    }
    //    catch (Exception ex)
    //    {
    //        //await Shell.Current.DisplayAlert("Error", ex.Message, "OK");
    //        students = new List<Student>
    //        {
    //             new Student { Name = "Ahmed Younis", Birthdate = new DateTime(2000,2,2) },
    //             new Student { Name = "Omar Sharkawy", Birthdate = new DateTime(2001,4,1) },
    //             new Student { Name = "Ahmed Omran", Birthdate = new DateTime(2005,5,12) }
    //        };
    //    }
    //        return students;
    //}

}
