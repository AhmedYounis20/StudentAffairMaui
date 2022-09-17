namespace StudentAffairMaui;

public class ClassRoomsService: BaseSettingService<ClassRoom>, IClassRoomsService
{
    public ClassRoomsService(HttpClient httpClient) : base(httpClient)
    {
    }
}
