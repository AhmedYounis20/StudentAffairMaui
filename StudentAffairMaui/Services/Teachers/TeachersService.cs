namespace StudentAffairMaui;

public class TeachersService : BaseSettingService<Teacher>, ITeachersService
{
    public TeachersService(HttpClient httpClient) : base(httpClient){}
}
