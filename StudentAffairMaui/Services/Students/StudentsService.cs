using Microsoft.Maui.Layouts;
using System.Net.Http.Json;

namespace StudentAffairMaui;

public class StudentsService : BaseSettingService<Student>,IStudentsService
{
    public StudentsService(HttpClient httpClient) : base(httpClient){}
}
